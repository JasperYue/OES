package com.augmentum.servlet;

import java.io.IOException;
import java.io.InputStream;
import java.io.PrintWriter;
import java.lang.reflect.Method;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebInitParam;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import net.sf.json.JSONObject;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;

import com.augmentum.util.StringUtil;
import common.ActionConfig;
import common.BeanFactory;
import common.ModelAndView;
import common.ResultConfig;
import common.ViewParameterConfig;

@WebServlet(urlPatterns = {"*.action"}, initParams = {
@WebInitParam(name = "suffix", value = ".action")}, loadOnStartup= 1)
public class DispatcherServlet extends HttpServlet{

    private static final long serialVersionUID = 7120289946347072988L;
    private String suffix = ".action";
    private Map<String, ActionConfig> actionConfigs = new ConcurrentHashMap<String, ActionConfig>();

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);
        String suffixFromConfig = config.getInitParameter("suffix");
        suffix = suffixFromConfig != null ? suffixFromConfig : suffix;

        InputStream inputStream = null;
        try {
            inputStream = DispatcherServlet.class.getClassLoader().getResourceAsStream("action.xml");
            DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder documentBuilder = documentBuilderFactory.newDocumentBuilder();
            Document document = documentBuilder.parse(inputStream);
            Element element = document.getDocumentElement();

            /** Load the action node in action.xml */
            NodeList actionNodes = element.getElementsByTagName("action");
            if (actionNodes == null) {
                return;
            }
            for (int i = 0; i < actionNodes.getLength(); i++) {
                Element actionElement = (Element) actionNodes.item(i);

                String name = actionElement.getAttribute("name");
                String className = actionElement.getAttribute("class");
                String methodName = actionElement.getAttribute("method");
                String httpMethod = actionElement.getAttribute("httpMethod");

                if (StringUtil.isEmpty(httpMethod)) {
                    httpMethod = "GET";
                }
                ActionConfig actionConfig = new ActionConfig(name, className, methodName, httpMethod);

                actionConfigs.put(name + suffix + "#" + httpMethod.toUpperCase(), actionConfig);

                /** Load the result node of action in action.xml */
                NodeList resultNodes = actionElement.getElementsByTagName("result");
                if (resultNodes !=null) {
                    for (int j = 0; j < resultNodes.getLength(); j++) {
                        Element resultElement = (Element) resultNodes.item(j);

                        String resultName = resultElement.getAttribute("name");
                        String resulttype = resultElement.getAttribute("type");

                        ResultConfig resultConfig = null;
                        if (!StringUtil.isEquals("json", resulttype)) {
                            String resultView = resultElement.getAttribute("view");
                            String resultRedirect = resultElement.getAttribute("redirect");
                            if (StringUtil.isEmpty(resultRedirect)) {
                                resultRedirect = "false";
                            }
                            if (StringUtil.isEquals("cookie", resulttype)) {
                                resultConfig = new ResultConfig(resultName, resulttype, resultView, Boolean.parseBoolean(resultRedirect));
                            } else {
                                resultConfig = new ResultConfig(resultName, resultView, Boolean.parseBoolean(resultRedirect));
                            }
                        } else {
                            resultConfig = new ResultConfig(resultName, resulttype);
                        }

                        /** Record the parameter when session is invalidate */
                        String viewParameter = resultElement.getAttribute("viewParameter");

                        if (!StringUtil.isEmpty(viewParameter)) {
                            String [] viewParameterArr = viewParameter.split(",");
                            for (String viewParameterItem : viewParameterArr) {
                                String [] viewParameterItemArr = viewParameterItem.split(",");
                                String key = viewParameterItemArr[0].trim();
                                String from = "attribute";
                                if (viewParameterItemArr.length == 2) {
                                    from = viewParameterItemArr[1].trim();
                                }

                                ViewParameterConfig viewParameterConfig = new ViewParameterConfig(key, from);
                                resultConfig.addViewParameterConfig(viewParameterConfig);
                            }
                        }
                        actionConfig.addResult(resultName, resultConfig);
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        String URI = request.getRequestURI();
        String requestedUri = URI.substring(request.getContextPath().length() + 1);
        requestedUri = StringUtil.isEmpty(requestedUri) ? "login" + this.suffix : requestedUri;

        String httpMethod = request.getMethod();

        /** login.action#GET || login.action#POST
         *  same URI but different method
         * */
        ActionConfig actionConfig = actionConfigs.get(requestedUri + "#" + httpMethod.toUpperCase());

        if (actionConfig != null) {
            String className = actionConfig.getClassName();
            try {

                Object controller = BeanFactory.getInstance().get(className);

                String methodName = actionConfig.getMethodName();

                HttpSession session = request.getSession();
                /** Set max life circle */
                session.setMaxInactiveInterval(1200);

                /** Transpot all session attribute in sessionMap */
                Map<String, Object> sessionMap = new HashMap<>();
                Enumeration<String> sessionKey = session.getAttributeNames();
                while (sessionKey.hasMoreElements()) {
                    String sessionAttrName = sessionKey.nextElement();
                    Object sessionAttrVal = session.getAttribute(sessionAttrName);
                    sessionMap.put(sessionAttrName, sessionAttrVal);
                }

                /** Transpot all request parameter in requestMap */
                Map<String, Object> requestMap = new HashMap<>();
                Enumeration<String> requestKey = request.getParameterNames();
                while (requestKey.hasMoreElements()) {
                    String requestParaName = requestKey.nextElement();
                    Object requestParaVal = null;
                    if (StringUtil.isEquals("delMark", requestParaName)) {
                        requestParaVal = request.getParameterValues(requestParaName);
                    } else {
                        requestParaVal = request.getParameter(requestParaName);
                    }
                    requestMap.put(requestParaName, requestParaVal);
                }

                /** Transpot cookies in requestMap */
                //TODO there is no need to transpot every time
                requestMap.put("COOKIES", request.getCookies());

                Class<?>[] paramClass = new Class[2];
                paramClass[0] = Map.class;
                paramClass[1] = Map.class;

                Method method = controller.getClass().getDeclaredMethod(methodName, paramClass);

                ModelAndView modelAndView = (ModelAndView) method.invoke(controller, sessionMap, requestMap);

                /** Set attribute at session scope */
                Map<String, Object> fromControllerSession = modelAndView.getSessionMap();
                Set<String> keys = fromControllerSession.keySet();
                for (String key: keys) {
                    session.setAttribute(key, fromControllerSession.get(key));
                }

                /** Set attribute at request scope */
                Map<String, Object> fromControllerRequest= modelAndView.getRequestMap();
                Set<String> keyRequests = fromControllerRequest.keySet();
                for (String key: keyRequests) {
                    request.setAttribute(key, fromControllerRequest.get(key));
                }

                String view = modelAndView.getView();
                ResultConfig resultConfig = actionConfig.getResult(view);


                if (resultConfig == null) {
                    /** When session invalite, according to record parameter choose which view should be jump */
                    if (modelAndView.isRedirect()) {
                        response.sendRedirect(request.getContextPath() + "/" + view);
                    } else {
                        request.getRequestDispatcher(view).forward(request, response);
                    }
                } else {
                    if (modelAndView.getResponseMap().size() > 0) {
                        Set<Entry<String, Object>> mapSet = modelAndView.getResponseMap().entrySet();
                        Object obj = null;
                        for (Entry<String, Object> o : mapSet) {
                            obj = o.getValue();
                            String resultType = resultConfig.getType();

                            /** If type is json, handle and return [json has no view]
                             *  If type is cookie, handle without return
                             *  */
                            if (StringUtil.isEquals("json", resultType)) {
                                PrintWriter pw = response.getWriter();
                                if (obj instanceof String) {
                                    pw.write((String)obj);
                                } else {
                                    JSONObject json = JSONObject.fromObject(obj);
                                    pw.write(json.toString());
                                }
                                pw.close();
                                return;
                            } else if (StringUtil.isEquals("cookie", resultType)) {
                                response.addCookie((Cookie) obj);
                            }
                        }
                    }

                    String resultView = request.getContextPath() + "/" + resultConfig.getView();
                    if (resultConfig.isRedirect()) {
                        List<ViewParameterConfig> viewParameterConfigs = resultConfig.getViewParameterConfigs();
                        if (viewParameterConfigs == null || viewParameterConfigs.isEmpty()) {
                            response.sendRedirect(resultView);
                        } else {
                            StringBuilder sb = new StringBuilder();
                            for (ViewParameterConfig viewParameterConfig : viewParameterConfigs) {
                                String name = viewParameterConfig.getName();
                                String from = viewParameterConfig.getFrom();
                                String value = "";
                                if ("attribute".equals(from)) {
                                    value = (String)request.getAttribute(name);
                                } else if ("parameter".equals(from)) {
                                    value = request.getParameter(name);
                                }  else if ("session".equals(from)) {
                                    value = (String)request.getSession().getAttribute(name);
                                } else {
                                    value = (String)request.getAttribute(name);
                                }

                                if (!StringUtil.isEmpty(value)) {
                                    sb.append(name + "=" + value + "&");
                                }

                            }

                            if (!StringUtil.isEmpty(sb.toString())) {
                                if (resultView.indexOf("?") > 0) {
                                    resultView = resultView + "&" +sb.toString();
                                } else {
                                    resultView = resultView + "?" +sb.toString();
                                }
                            }
                            response.sendRedirect(resultView);
                        }
                    } else {
                        request.getRequestDispatcher(resultConfig.getView()).forward(request, response);
                    }
                }
            } catch (Exception e) {
                e.printStackTrace();
                response.sendError(500);
            }
        } else {
            response.sendError(404);
        }
    }

}