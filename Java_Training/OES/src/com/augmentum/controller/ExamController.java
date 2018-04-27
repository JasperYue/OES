package com.augmentum.controller;

import java.util.Map;

import com.augmentum.Constants;
import com.augmentum.exception.BasicException;
import com.augmentum.model.Exam;
import com.augmentum.model.User;
import com.augmentum.service.ExamService;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.Page;
import com.augmentum.util.StringUtil;
import common.ModelAndView;

public class ExamController extends ExceptionHandler{

    private ExamService examService;

    public void setExamService(ExamService examService) {
        this.examService = examService;
    }

    public ModelAndView addExam(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setView("jsonResult");
        User user = (User) sessionMap.get(Constants.USER);
        String saveFlagStr = (String) requestMap.get("saveFlag");
        String hour = (String) requestMap.get("hour");
        String min = (String) requestMap.get("min");
        Exam exam = request2Bean(requestMap, Exam.class);
        exam.setEffectiveTime(exam.getEffectiveTime() + " " + hour + ":" + min);
        exam.setCreator(user.getName());
        boolean saveFlag = false;

        try {
            saveFlag = Boolean.parseBoolean(saveFlagStr);
        } catch (Exception e) {}

        try {
            examService.addExam(exam, saveFlag);

            modelAndView.setAttrAtResponse("STRING", "Add exam successfully");
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

    public ModelAndView queryExamList(Map<String, Object> sessionMap,
            Map<String, Object> requestMap) {
        ModelAndView modelAndView = new ModelAndView();

        String name = (String) requestMap.get("name");
        String timeBegin = (String) requestMap.get("timeBegin");
        String timeEnd = (String) requestMap.get("timeEnd");
        String orderField = (String) requestMap.get("orderField");

        String pageNoStr = (String) requestMap.get("pageNo");
        String pageSizeStr = (String) requestMap.get("pageSize");

        int pageNo = 1;
        int pageSize = 5;
        try {
            pageNo = Integer.parseInt(pageNoStr);
        } catch (Exception e) {}
        try {
            pageSize = Integer.parseInt(pageSizeStr);
        } catch (Exception e) {}

        try {
            Page<Exam> page = new Page<>(pageNo, pageSize);
            FuzzyCriterion<Exam> fuzzyCriterion = examService.findExamList(new FuzzyCriterion<Exam>(page, name, orderField, timeBegin, timeEnd));

            modelAndView.setAttrAtResponse("JSON", fuzzyCriterion);
            modelAndView.setView("jsonResult");
        } catch (BasicException e) {
            /** Handle all custom exception here*/
            setRequestScopeAttribute(e, modelAndView);
            modelAndView.setAttrAtResponse("STRING", requestMap.get(Constants.TIP_MESSAGE));
        }

        return modelAndView;
    }

}
