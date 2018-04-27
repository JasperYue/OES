package com.augmentum.filter;

import java.io.IOException;

import javax.servlet.FilterChain;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebFilter;
import javax.servlet.annotation.WebInitParam;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.augmentum.Constants;
import com.augmentum.WebContext;
import com.augmentum.model.User;
import com.augmentum.util.StringUtil;

@WebFilter(urlPatterns = {"/page/*"}, initParams = {@WebInitParam(name = "noNeedLoginPages",
value = "page/user/login")})
public class LoginFilter extends HttpFilter {

    private String noNeedLoginPages = "page/user/login";
    @Override
    protected void init() {
        noNeedLoginPages = this.getFilterConfig().getInitParameter("noNeedLoginPages");
    }

    @Override
    public void doFilter(HttpServletRequest request, HttpServletResponse response, FilterChain chain)
            throws IOException, ServletException {

        WebContext webContext = WebContext.getContext();
        webContext.setContextPath(request.getContextPath());
        webContext.addKeyVal(Constants.APP_CONTEXT_SESSION, request.getSession());

        String URI = request.getRequestURI();
        String requestedUri = URI.substring(request.getContextPath().length() + 1);

        if (noNeedLoginPages.equals(requestedUri)) {
            chain.doFilter(request, response);
        } else {
            User user = (User) request.getSession().getAttribute(Constants.USER);
            if (user == null){
                if (StringUtil.isEquals("GET", request.getMethod().toUpperCase())) {
                    String queryString = request.getQueryString();
                    if (!StringUtil.isEmpty(queryString)) {
                        requestedUri = requestedUri + "#" + queryString;
                    }
                    response.sendRedirect(request.getContextPath() + Constants.SLASH + noNeedLoginPages +
                            "?go=" + requestedUri);
                } else {
                    response.sendRedirect(request.getContextPath() + Constants.SLASH + noNeedLoginPages);
                }
            } else {
                chain.doFilter(request, response);
            }
        }
    }
}
