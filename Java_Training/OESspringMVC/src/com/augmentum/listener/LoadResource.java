package com.augmentum.listener;

import java.io.IOException;
import java.io.InputStream;
import java.util.Properties;

import javax.servlet.ServletContextEvent;
import javax.servlet.ServletContextListener;
import javax.servlet.annotation.WebListener;

import com.augmentum.Constants;
import com.augmentum.exception.DBException;
import com.augmentum.exception.ServiceException;
import com.augmentum.util.MessageUtil;

@WebListener
public class LoadResource implements ServletContextListener {

    public static Properties properties = null;

    @Override
    public void contextInitialized(ServletContextEvent sce) {
        // Pass 1: The configuration file load in memory first
        InputStream in = null;
        try {
            in = LoadResource.class.getClassLoader().getResourceAsStream(Constants.CONFIG_FILE);
            properties = new Properties();
            properties.load(in);
        } catch (IOException ioException) {
            throw new ServiceException(MessageUtil.LOAD_PROPERTIES_FILE_FAIL,
                    MessageUtil.buildMessage(MessageUtil.LOAD_PROPERTIES_FILE_FAIL));
        } finally {
            if (in != null) {
                try {
                    in.close();
                } catch (IOException ioException) {
                    throw new DBException(MessageUtil.CLOSE_STREAM_FAIL,
                            MessageUtil.buildMessage(MessageUtil.CLOSE_STREAM_FAIL));
                }
            }
        }

        sce.getServletContext().setAttribute(Constants.STATIC_URL, LoadResource.getProperty(Constants.STATIC_URL));
    }

    public static String getProperty(String key) {
        return properties.getProperty(key);
    }

    @Override
    public void contextDestroyed(ServletContextEvent sce) {
        sce.getServletContext().removeAttribute(Constants.STATIC_URL);
    }

}
