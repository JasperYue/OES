package com.augmentum.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import com.augmentum.Constants;
import com.augmentum.exception.BasicException;
import com.augmentum.model.Exam;
import com.augmentum.service.ExamService;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.MessageUtil;
import com.augmentum.util.Page;
import com.augmentum.util.StringUtil;

@Controller
@RequestMapping(Constants.APP_URL_EXAM_PREFIX)
public class ExamController extends BaseController {

    @Autowired
    private ExamService examService;

    public void setExamService(ExamService examService) {
        this.examService = examService;
    }

    @RequestMapping(value = "/addExam", method = RequestMethod.POST)
    @ResponseBody
    public Object addExam(
                          @RequestParam(value = "name", defaultValue = "") String name,
                          @RequestParam(value = "description", defaultValue = "") String description,
                          @RequestParam(value = "effectiveTime", defaultValue = "") String effectiveTime,
                          @RequestParam(value = "duration", defaultValue = "") String durationStr,
                          @RequestParam(value = "singleScore", defaultValue = "") String singleScoreStr,
                          @RequestParam(value = "needQuantity", defaultValue = "") String needQuantityStr,
                          @RequestParam(value = "totalScore", defaultValue = "") String totalScoreStr,
                          @RequestParam(value = "passCriteria", defaultValue = "") String passCriteriaStr,
                          @RequestParam(value = "saveFlag", defaultValue = "false") Boolean saveFlag,
                          @RequestParam(value = "hour", defaultValue = "") String hour,
                          @RequestParam(value = "min", defaultValue = "") String min
                          ) {

        int duration = 0;
        int needQuantity = 0;
        int passCriteria = 0;
        float singleScore = 0.0f;
        float totalScore = 0.0f;
        try {
            duration = Integer.parseInt(durationStr);
        } catch (Exception e) {}
        try {
            needQuantity = Integer.parseInt(needQuantityStr);
        } catch (Exception e) {}
        try {
            passCriteria = Integer.parseInt(passCriteriaStr);
        } catch (Exception e) {}
        try {
            singleScore = Float.parseFloat(singleScoreStr);
        } catch (Exception e) {}

        try {
            totalScore = Float.parseFloat(totalScoreStr);
        } catch (Exception e) {}


        Exam exam = new Exam(name, description, singleScore, totalScore, passCriteria, needQuantity, effectiveTime, duration);

        exam.setEffectiveTime(exam.getEffectiveTime() + " " + hour + ":" + min);
        exam.setCreator("Jasper.Yue");

        try {
            examService.addExam(exam, saveFlag);
            return MessageUtil.ADD_EXAM_SUC;
        } catch (BasicException e) {
            /** Handle all custom exception here*/
            ModelAndView modelAndView = new ModelAndView();
            setRequestScopeAttribute(e, modelAndView);
            if (!StringUtil.isEmpty((String) modelAndView.getModelMap().get(Constants.TIP_MESSAGE))) {
                return modelAndView.getModelMap().get(Constants.TIP_MESSAGE);
            } else {
                return modelAndView.getModelMap().get(Constants.ERROR_MESSAGE);
            }
        }

    }

    @RequestMapping(value = "/queryExamList", method = RequestMethod.POST)
    @ResponseBody
    public Object queryExamList(
                                @RequestParam(value = "name", defaultValue = "") String name,
                                @RequestParam(value = "timeBegin", defaultValue = "") String timeBegin,
                                @RequestParam(value = "timeEnd", defaultValue = "") String timeEnd,
                                @RequestParam(value = "orderField", defaultValue = "") String orderField,
                                @RequestParam(value = "pageNo", defaultValue = "1") String pageNoStr,
                                @RequestParam(value = "pageSize", defaultValue = "10") String pageSizeStr
                                ) {

        int pageNo = 1;
        int pageSize = 10;

        try {
            pageNo = Integer.parseInt(pageNoStr);
        } catch (Exception e) {}
        try {
            pageSize = Integer.parseInt(pageSizeStr);
        } catch (Exception e) {}

        try {
            Page<Exam> page = new Page<>(pageNo, pageSize);
            FuzzyCriterion<Exam> fuzzyCriterion = examService.findExamList(new FuzzyCriterion<Exam>(page, name, orderField, timeBegin, timeEnd));
            return fuzzyCriterion;
        } catch (BasicException e) {
            /** Handle all custom exception here*/
            ModelAndView modelAndView = new ModelAndView();
            setRequestScopeAttribute(e, modelAndView);
            return modelAndView.getModelMap().get(Constants.TIP_MESSAGE);
        }

    }

}
