package common;

import java.io.IOException;
import java.io.InputStream;
import java.lang.reflect.Method;
import java.lang.reflect.Proxy;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;

import com.augmentum.util.StringUtil;


public class BeanFactory {

    private static Map<String, BeanConfig> beans = new ConcurrentHashMap<>();

    private static Map<String, Object> objects = new ConcurrentHashMap<>();

    /** Singleton */
    private static BeanFactory INSTANCE = null;

    private BeanFactory() {

    }

    public static BeanFactory getInstance() {
        if (INSTANCE == null) {
            synchronized(BeanFactory.class) {
                if (INSTANCE  == null) {
                    INSTANCE = new BeanFactory();
                    init();
                }
            }
        }
        return INSTANCE;
    }

    /** Load xml configuration */
    private static void init() {

        InputStream inputStream = null;
        try {
            inputStream = BeanFactory.class.getClassLoader().getResourceAsStream("bean.xml");
            DocumentBuilderFactory documentBuilderFactory = DocumentBuilderFactory.newInstance();
            DocumentBuilder documentBuilder = documentBuilderFactory.newDocumentBuilder();
            Document document = documentBuilder.parse(inputStream);
            Element element = document.getDocumentElement();

            NodeList beanNodes = element.getElementsByTagName("bean");

            if (beanNodes == null) {
                return;
            }
            for (int i = 0; i < beanNodes.getLength(); i++) {
                Element beanElement = (Element) beanNodes.item(i);

                String id = beanElement.getAttribute("id");
                String classFullName = beanElement.getAttribute("class");
                String scope = beanElement.getAttribute("scope");

                BeanConfig beanConfig = new BeanConfig(id, classFullName, scope);

                beans.put(id, beanConfig);

                NodeList propertyNode = beanElement.getElementsByTagName("property");

                if (propertyNode != null) {
                    for (int j = 0; j < propertyNode.getLength(); j++) {
                        Element propertyElement = (Element) propertyNode.item(j);
                        String propertyName = propertyElement.getAttribute("name");
                        String propertyRef = propertyElement.getAttribute("ref");

                        BeanProperty beanProperty = new BeanProperty(propertyName, propertyRef);

                        beanConfig.setProperty(beanProperty);
                    }
                }
            }
        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            if (inputStream != null) {
                try {
                    inputStream.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        }
    }

    public Object get(String id) {
        if (beans.containsKey(id)) {
            BeanConfig bean = beans.get(id);
            String scope = bean.getScope();
            if (StringUtil.isEmpty(scope)) {
                scope = "singleton";
            }

            if (scope.equalsIgnoreCase("singleton")) {
                if (objects.containsKey(id)) {
                    return objects.get(id);
                }
            }

            String classFullName = bean.getClassFullName();

            Class<?> clz = null;
            try {
                clz = Class.forName(classFullName);
                Object object = clz.newInstance();

                if ("singleton".equalsIgnoreCase(bean.getScope())) {
                    objects.put(id, object);
                }

                List<BeanProperty> propertiesList = bean.getPropertiesList();

                if (propertiesList != null && propertiesList.size() != 0) {
                    for (BeanProperty property : propertiesList) {
                        String firstChar = property.getName().substring(0, 1);
                        String restChar = property.getName().substring(1);
                        String propertyName = firstChar.toUpperCase() + restChar;

                        Method method = null;
                        Method[] methods = clz.getMethods();

                        for (Method methodInClass : methods) {
                            String methodNameInClass = methodInClass.getName();
                            if (("set" + propertyName).startsWith(methodNameInClass)) {
                                method = methodInClass;
                                break;
                            }
                        }
                        String propertyRef = property.getRef();
                        if (!StringUtil.isEmpty(propertyRef)) {
                            Object refObj = this.get(propertyRef);
                            method.invoke(object, refObj);
                        }

                    }
                }

                if ("com.augmentum.service.impl".equals(object.getClass().getPackage().getName())) {
                    DynamicProxy dynamicProxy = new DynamicProxy(object);

                    Object objProxy = Proxy.newProxyInstance(object.getClass().getClassLoader(),
                            object.getClass().getInterfaces(), dynamicProxy);

                    if ("singleton".equalsIgnoreCase(bean.getScope())) {
                        objects.put(id, objProxy);
                    }

                    return objProxy;
                }

                return object;
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
        return null;
    }
}
