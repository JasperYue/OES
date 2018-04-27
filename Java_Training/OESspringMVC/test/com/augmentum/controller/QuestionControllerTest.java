package com.augmentum.controller;

import java.io.IOException;
import java.io.InputStream;
import java.sql.Timestamp;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Properties;

import javax.servlet.http.HttpSession;

import org.junit.After;
import org.junit.Assert;
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
import com.augmentum.model.Question;
import com.augmentum.model.User;
import com.augmentum.util.FuzzyCriterion;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = {"classpath:applicationContext.xml", "classpath:oes-mvc.xml"})
public class QuestionControllerTest extends AbstractTransactionalJUnit4SpringContextTests {

    private QuestionController questionController;

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
        questionController = (QuestionController) this.applicationContext.getBean("questionController");
    }

    @After
    public void tearDown() throws Exception {
        WebContext.clear();
    }

    /**
     * Add question successfully
     */
    @Test
    public void addQuestionSuccessful() {
        Question question = new Question("123", "123", "1234", "12345", "123456", 1);
        Object obj = questionController.addOrEditQuestion(question);
        Assert.assertEquals("Add question successfully!", obj);
    }

    /**
     * Add question with invalid data.
     */
    @Test()
    public void addQuestionValidationFailed() {
        Question question = new Question("", "", "", "", "", 0);
        Object obj = questionController.addOrEditQuestion(question);
        Map<String, String> errMsg = (Map<String, String>) obj;
        Assert.assertEquals("Field title for Question is required.", errMsg.get(Question.TITLE));
        Assert.assertEquals("Field itemA for Question is required.", errMsg.get(Question.ITEM_A));
        Assert.assertEquals("Field itemB for Question is required.", errMsg.get(Question.ITEM_B));
        Assert.assertEquals("Field itemC for Question is required.", errMsg.get(Question.ITEM_C));
        Assert.assertEquals("Field itemD for Question is required.", errMsg.get(Question.ITEM_D));
    }

    @Test()
    public void addQuestionValidationLengthFailed() {
        Question question = new Question("111111111111111111111111111111111111111111111111111" +
                "1111111111111111111111111111111111111111111111111111111111111111111111111111" +
                "1111111111111111111111111111111111111111111111111111111111111111111111111111" +
                "1111111111111111111111111111111111111111111111111111111111111111111111111111",
                "", "", "", "", 0);
        Object obj = questionController.addOrEditQuestion(question);
        Map<String, String> errMsg = (Map<String, String>) obj;
        Assert.assertEquals("Data too long for title.", errMsg.get(Question.TITLE));
        Assert.assertEquals("Field itemA for Question is required.", errMsg.get(Question.ITEM_A));
        Assert.assertEquals("Field itemB for Question is required.", errMsg.get(Question.ITEM_B));
        Assert.assertEquals("Field itemC for Question is required.", errMsg.get(Question.ITEM_C));
        Assert.assertEquals("Field itemD for Question is required.", errMsg.get(Question.ITEM_D));
    }
    @Test()
    public void addQuestionValidationRepeatFailed() {
        Question question = new Question("1111",
                "123", "123", "3", "4", 0);
        Object obj = questionController.addOrEditQuestion(question);
        Map<String, String> errMsg = (Map<String, String>) obj;
        Assert.assertEquals("Item can not be repeat.", errMsg.get(Question.ITEM_A));
    }

    /** Edit question with invalid data. */
    @Test()
    public void editQuestionValidationFailed() {
        Question question = new Question("", "", "", "", "", 0);
        Object obj = questionController.addOrEditQuestion(question);
        Map<String, String> errMsg = (Map<String, String>) obj;
        Assert.assertEquals("Field title for Question is required.", errMsg.get(Question.TITLE));
        Assert.assertEquals("Field itemA for Question is required.", errMsg.get(Question.ITEM_A));
        Assert.assertEquals("Field itemB for Question is required.", errMsg.get(Question.ITEM_B));
        Assert.assertEquals("Field itemC for Question is required.", errMsg.get(Question.ITEM_C));
        Assert.assertEquals("Field itemD for Question is required.", errMsg.get(Question.ITEM_D));
    }

    /** Question Already deleted */
    @Test
    public void editQuestionDeletedAlready() {
        Question question = new Question("张三", "1", "21", "3", "4", 2);
        question.setId(13);
        question.setNum("Q00013");
        question.setDelMark(1);
        question.setReferMark(0);
        question.setCreateTime(Timestamp.valueOf("2016-10-31 21:02:41"));
        question.setUpdateTime(Timestamp.valueOf("2016-11-05 10:40:35"));
        Object obj = questionController.addOrEditQuestion(question);
        Assert.assertEquals("Entity Question already deleted.", obj);
    }

    /** Edit question not refer successful */
    @Test
    public void editQuestionNotReferSuccessful() {
        Question question = new Question("321", "321", "321321", "45", "667", 2);
        question.setId(2);
        question.setNum("Q0002");
        question.setDelMark(0);
        question.setReferMark(0);
        question.setCreateTime(Timestamp.valueOf("2016-10-28 20:53:40"));
        question.setUpdateTime(Timestamp.valueOf("2016-10-28 21:31:25"));
        Object obj = questionController.addOrEditQuestion(question);
        Assert.assertEquals("Edit question successfully!", obj);
    }

    /** Edit question refer by exam successfully*/
    @Test()
    public void editQuestionReferSuccessful() {
        Question question = new Question("XXXX11", "1", "2", "3", "4", 1);
        question.setId(21);
        question.setNum("Q00021");
        question.setDelMark(0);
        question.setReferMark(1);
        question.setCreateTime(Timestamp.valueOf("2016-10-31 21:51:34"));
        question.setUpdateTime(Timestamp.valueOf("2016-11-05 21:57:16"));
        Object obj = questionController.addOrEditQuestion(question);
        Assert.assertEquals("Edit question successfully!", obj);
    }

    /**
     * Delete question with invalid data.
     */
    @Test()
    public void deleteQuestionValidationFailed() {
        String[] idArr = null;
        Object obj = questionController.deleteQuestion(idArr);
        Assert.assertEquals("No any entity Question selected.", obj);
    }

    /**
     * Delete question partly
     */
    @Test
    public void deleteQuestionFailed() {
        String[] idArr = {"1", "2", "5"};
        Object obj = questionController.deleteQuestion(idArr);
        Assert.assertEquals("Given 3, Finished 2.", obj);
    }

    /**
     * Delete question successfully
     */
    @Test
    public void deleteQuestionSuccessful() {
        String[] idArr = {"2", "5"};
        Object obj = questionController.deleteQuestion(idArr);
        Assert.assertEquals("Delete question successfully!", obj);
    }

    @Test
    public void getQuestionSuccessful() throws IOException, ParseException {
        Question question = new Question("321", "321", "321321", "45", "667", 2);
        question.setId(2);
        Object obj = questionController.toEdit("2", question);
        question.setNum("Q0002");
        question.setDelMark(0);
        question.setReferMark(0);
        question.setCreateTime(Timestamp.valueOf("2016-10-28 20:53:40"));
        question.setUpdateTime(Timestamp.valueOf("2016-10-28 21:31:25"));
        Assert.assertEquals(question, obj);
    }

    @Test
    public void getQuestionValidationFailed1() throws IOException {
        Object obj = questionController.toEdit("2", null);
        Assert.assertEquals("Data validate error.", obj);
    }

    @Test
    public void getQuestionValidationFailed2() throws IOException {
        Question question = new Question("321", "321", "321321", "45", "667", 2);
        question.setId(0);
        Object obj = questionController.toEdit("2", question);
        Assert.assertEquals("Data validate error.", obj);
    }

    @Test
    public void getQuestionUnSuccessful() throws IOException {
        Question question = new Question("321", "321", "321321", "45", "667", 2);
        question.setId(1);
        Object obj = questionController.toEdit("1", question);
        Assert.assertEquals("Entity Question not found.", obj);
    }

    @Test
    public void findQuestionListSuccessful() {
        Object obj = questionController.queryQuestionList("3", "2", "", "");
        List<Integer> factList = new ArrayList<>();
        FuzzyCriterion<Question> fuzzyCriterion = (FuzzyCriterion<Question>) obj;
        List<Question> questionList = fuzzyCriterion.getPage().getPageList();
        for (Question question : questionList) {
            factList.add(question.getId());
        }
        List<Integer> expectList = new ArrayList<>();
        expectList.add(2);
        expectList.add(21);
        Assert.assertEquals(expectList, factList);
    }

}
