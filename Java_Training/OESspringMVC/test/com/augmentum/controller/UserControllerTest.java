package com.augmentum.controller;

import java.io.IOException;
import java.io.InputStream;
import java.util.Map;
import java.util.Properties;

import javax.servlet.ServletException;
import javax.servlet.http.HttpSession;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.mock.web.MockHttpServletResponse;
import org.springframework.mock.web.MockHttpSession;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.AbstractTransactionalJUnit4SpringContextTests;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.view.RedirectView;

import com.augmentum.Constants;
import com.augmentum.WebContext;
import com.augmentum.listener.LoadResource;
import com.augmentum.model.User;
import com.augmentum.util.StringUtil;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:applicationContext.xml", "classpath:oes-mvc.xml"})
public class UserControllerTest extends AbstractTransactionalJUnit4SpringContextTests {

    private UserController userController;

    @Before
    public void setUp() throws Exception {
        InputStream in = LoadResource.class.getClassLoader().getResourceAsStream(Constants.CONFIG_FILE);
        LoadResource.properties = new Properties();
        LoadResource.properties.load(in);
        WebContext.getContext().setContextPath("/OES");
        WebContext.getContext().addKeyVal(Constants.APP_CONTEXT_SESSION, new MockHttpSession());
        userController = (UserController) this.applicationContext.getBean("userController");
    }

    @After
    public void tearDown() throws Exception {
        WebContext.clear();
    }

    /**
     * User login successfully
     * @throws ServletException
     * @throws IOException
     */
    @Test
    public void testLoginSuccessful() throws ServletException, IOException {
        User userRequest = new User("Jasper.Yue", "123456");
        ModelAndView modelAndView = userController.login(userRequest, new MockHttpServletResponse(), "0", "", "", null, null);
        RedirectView redirectView = (RedirectView) modelAndView.getView();
        Assert.assertEquals(StringUtil.getFullPath(Constants.QUESTION_LIST), redirectView.getUrl());
        Assert.assertNotNull(((HttpSession) WebContext.getContext().getVal(Constants.APP_CONTEXT_SESSION)).getAttribute(Constants.APP_CONTEXT_USER));
        Assert.assertNotNull(WebContext.getContext().getVal(Constants.APP_CONTEXT_USER));
    }

    /**
     * User login with invalid data.
     * @throws ServletException
     * @throws IOException
     */
    @Test
    public void testLoginValidationFailed() throws ServletException, IOException {
        User userRequest = new User("", "");
        ModelAndView modelAndView = userController.login(userRequest, new MockHttpServletResponse(), "0", "", "", null, null);
        Assert.assertEquals(Constants.LOGIN_PAGE, modelAndView.getViewName());
        Map<String, Object> map = (Map<String, Object>) modelAndView.getModelMap().get(Constants.ERROR_MESSAGE);
        Assert.assertEquals("Field name for User is required.", map.get("name"));
        Assert.assertEquals("Field password for User is required.", map.get("password"));
    }

    /**
     * User login with incorrect password.
     * @throws ServletException
     * @throws IOException
     */
    @Test
    public void testLoginUnSuccessful() throws ServletException, IOException {
        User userRequest = new User("Jasper.Yue", "123");
        ModelAndView modelAndView = userController.login(userRequest, new MockHttpServletResponse(), "0", "", "", null, null);
        Assert.assertEquals(Constants.LOGIN_PAGE, modelAndView.getViewName());
        Assert.assertEquals("Entity User not found.", modelAndView.getModelMap().get(Constants.TIP_MESSAGE));
    }

}
