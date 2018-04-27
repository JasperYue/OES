package com.augmentum.controller;

import java.io.IOException;
import java.util.Map;

import com.augmentum.Constants;
import com.augmentum.exception.BasicException;
import com.augmentum.model.Question;
import com.augmentum.service.QuestionService;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.Page;
import com.augmentum.util.StringUtil;
import common.ModelAndView;

public class QuestionController extends ExceptionHandler{

    private QuestionService questionService;

    public void setQuestionService(QuestionService questionService) {
        this.questionService = questionService;
    }

    public ModelAndView toEdit(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) throws IOException {

        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setView("jsonResult");
        String id = (String) requestMap.get("id");

        if (!StringUtil.isEmpty(id)) {
            Question question = request2Bean(requestMap, Question.class);
            try {
                question = questionService.getQuestion(question);

                modelAndView.setAttrAtResponse("JSON", question);
            } catch (BasicException e) {
                setRequestScopeAttribute(e, modelAndView);
                modelAndView.setAttrAtResponse("STRING", modelAndView.getRequestMap().get(Constants.TIP_MESSAGE));
            }
        }

        return modelAndView;
    }

    public ModelAndView addOrEditQuestion(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) {

        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setView("jsonResult");

        Question question = request2Bean(requestMap, Question.class);
        try {
            if (question.getId() == Constants.STATUS_ZERO) {
                questionService.addQuestion(question);
                /** Add question successfully */
                modelAndView.setAttrAtResponse("STRING", "Add question successfully!");
            } else {
                questionService.editQuestion(question);
                modelAndView.setAttrAtResponse("STRING", "Edit question successfully!");
            }
        } catch (BasicException e) {
            /** Handle all custom exception here*/
            setRequestScopeAttribute(e, modelAndView);
            if (!StringUtil.isEmpty((String) modelAndView.getRequestMap().get(Constants.TIP_MESSAGE))) {
                modelAndView.setAttrAtResponse("STRING", modelAndView.getRequestMap().get(Constants.TIP_MESSAGE));
            } else {
                modelAndView.setAttrAtResponse("JSON", modelAndView.getRequestMap().get(Constants.ERROR_MESSAGE));
            }
        }

        return modelAndView;
    }

    public ModelAndView toQuestionList(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setView("success");
        return modelAndView;
    }

    public ModelAndView queryQuestionList(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) {
        String pageNoStr = (String) requestMap.get("pageNo");
        String title = (String) requestMap.get("titleStr");
        String pageSizeStr = (String) requestMap.get("pageSize");
        String orderField = (String) requestMap.get("orderField");
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setView("jsonResult");

        int pageNo = 1;
        int pageSize = 5;
        try {
            pageNo = Integer.parseInt(pageNoStr);
        } catch (Exception e) {}
        try {
            pageSize = Integer.parseInt(pageSizeStr);
        } catch (Exception e) {}

        try {
            Page<Question> page = new Page<Question>(pageNo, pageSize);
            FuzzyCriterion<Question> fuzzyCriterion = questionService.findQuestionList(new FuzzyCriterion<Question>(orderField, title, page));

            modelAndView.setAttrAtResponse("JSON", fuzzyCriterion);
        } catch (BasicException e) {
            /** Handle all custom exception here*/
            setRequestScopeAttribute(e, modelAndView);
            modelAndView.setAttrAtResponse("STRING", modelAndView.getRequestMap().get(Constants.TIP_MESSAGE));
        }

        return modelAndView;
    }

    public ModelAndView deleteQuestion(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) {

        String[] idArr = (String[]) requestMap.get("delMark");
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setView("jsonResult");
        try {
            questionService.deleteQuestion(idArr);
            modelAndView.setAttrAtResponse("STRING", "Delete successfully!");
        } catch (BasicException e) {
            setRequestScopeAttribute(e, modelAndView);
            modelAndView.setAttrAtResponse("STRING", modelAndView.getRequestMap().get(Constants.TIP_MESSAGE));
        }

        return modelAndView;
    }
}
