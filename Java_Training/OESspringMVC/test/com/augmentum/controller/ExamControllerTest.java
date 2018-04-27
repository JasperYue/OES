package com.augmentum.controller;

import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Properties;

import javax.servlet.http.HttpSession;

import junit.framework.Assert;

import org.junit.After;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.mock.web.MockHttpSession;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.AbstractTransactionalJUnit4SpringContextTests;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import com.augmentum.Constants;
import com.augmentum.WebContext;
import com.augmentum.listener.LoadResource;
import com.augmentum.model.Exam;
import com.augmentum.model.User;
import com.augmentum.util.FuzzyCriterion;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:applicationContext.xml", "classpath:oes-mvc.xml"})
public class ExamControllerTest extends AbstractTransactionalJUnit4SpringContextTests {

    private ExamController examController;

    @Before
    public void setUp() throws Exception {
        InputStream in = LoadResource.class.getClassLoader().getResourceAsStream(Constants.CONFIG_FILE);
        LoadResource.properties = new Properties();
        LoadResource.properties.load(in);
        User user = new User("Jasper.Yue", "123456");
        HttpSession session = new MockHttpSession();
        session.setAttribute(Constants.USER, user);
        WebContext.getContext().setContextPath("/OES");
        WebContext.getContext().addKeyVal(Constants.APP_CONTEXT_SESSION, session);
        WebContext.getContext().addKeyVal(Constants.APP_CONTEXT_USER, user);
        examController = (ExamController) this.applicationContext.getBean("examController");
    }

    @After
    public void tearDown() throws Exception {
        WebContext.clear();
    }

    @Test
    public void queryExamListSuccessful() {
        Object obj = examController.queryExamList("", "", "", "", "2", "3");
        List<Integer> expectList = new ArrayList<>();
        expectList.add(1);
        expectList.add(6);
        expectList.add(7);
        FuzzyCriterion<Exam> fuzzyCriterion = (FuzzyCriterion<Exam>) obj;
        List<Exam> examList = fuzzyCriterion.getPage().getPageList();
        List<Integer> factList = new ArrayList<>();
        for (Exam exam : examList) {
            factList.add(exam.getId());
        }
        Assert.assertEquals(expectList, factList);
    }

    @Test
    public void addExamValidationFailed() {
        Object obj = examController.addExam("", "", "", "", "", "", "", "", false, "", "");
        Map<String, String> errMsg = (Map<String, String>) obj;
        Assert.assertEquals("Field name for Exam is required.", errMsg.get(Exam.NAME));
        Assert.assertEquals("Time format error, 2016-11-01 11:00 needed.", errMsg.get(Exam.EFFECTIVE_TIME));
        Assert.assertEquals("Field duration for Exam is numberic.", errMsg.get(Exam.DURATION));
        Assert.assertEquals("Field needQuantity for Exam is numberic.", errMsg.get(Exam.NEED_QUANTITY));
        Assert.assertEquals("Field passCriteria for Exam is numberic.", errMsg.get(Exam.PASS_CRITERIA));
        Assert.assertEquals("Field singleScore for Exam is numberic.", errMsg.get(Exam.SINGLE_SCORE));
        Assert.assertEquals("Field totalScore for Exam is numberic.", errMsg.get(Exam.TOTAL_SCORE));
    }

    @Test
    public void addExamValidationLengthFailed() {
        Object obj = examController.addExam("1111111111111111111111111111111111111111111111111111",
                "", "", "", "", "", "", "", false, "", "");
        Map<String, String> errMsg = (Map<String, String>) obj;
        Assert.assertEquals("Data too long for name.", errMsg.get(Exam.NAME));
        Assert.assertEquals("Time format error, 2016-11-01 11:00 needed.", errMsg.get(Exam.EFFECTIVE_TIME));
        Assert.assertEquals("Field duration for Exam is numberic.", errMsg.get(Exam.DURATION));
        Assert.assertEquals("Field needQuantity for Exam is numberic.", errMsg.get(Exam.NEED_QUANTITY));
        Assert.assertEquals("Field passCriteria for Exam is numberic.", errMsg.get(Exam.PASS_CRITERIA));
        Assert.assertEquals("Field singleScore for Exam is numberic.", errMsg.get(Exam.SINGLE_SCORE));
        Assert.assertEquals("Field totalScore for Exam is numberic.", errMsg.get(Exam.TOTAL_SCORE));
    }

    @Test
    public void addExamSaveAsDraft() {
        Object obj = examController.addExam("Test", "", "2016-11-01", "120", "2", "100", "100", "60", false, "11", "00");
        Assert.assertEquals("Sorry, the question is not enough in the system!", obj);
    }

    @Test
    public void addExamAsDraftSuccessful() {
        Object obj = examController.addExam("Test", "", "2016-11-01", "120", "2", "100", "100", "60", true, "11", "00");
        Assert.assertEquals("Add exam successfully!", obj);
    }

    @Test
    public void addExamSuccessful() {
        Object obj = examController.addExam("Test", "", "2016-11-01", "120", "2", "20", "60", "60", false, "11", "00");
        Assert.assertEquals("Add exam successfully!", obj);
    }
}
