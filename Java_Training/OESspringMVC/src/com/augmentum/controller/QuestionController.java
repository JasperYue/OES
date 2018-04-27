package com.augmentum.controller;

import java.io.IOException;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import com.augmentum.Constants;
import com.augmentum.model.Question;
import com.augmentum.service.QuestionService;
import com.augmentum.util.FuzzyCriterion;
import com.augmentum.util.MessageUtil;
import com.augmentum.util.Page;
import com.augmentum.util.StringUtil;

@Controller
@RequestMapping(Constants.APP_URL_QUESTION_PREFIX)
public class QuestionController extends BaseController {

    @Autowired
    private QuestionService questionService;

    public void setQuestionService(QuestionService questionService) {
        this.questionService = questionService;
    }

    @RequestMapping(value = "/toEdit", method = RequestMethod.POST)
    @ResponseBody
    public Object toEdit(
                         @RequestParam(value = Question.ID, defaultValue = "") String id,
                         Question question
                         ) throws IOException {

        if (!StringUtil.isEmpty(id)) {
            try {
                return questionService.getQuestion(question);
            } catch (RuntimeException e) {
                ModelAndView modelAndView = new ModelAndView();
                setRequestScopeAttribute(e, modelAndView);
                return modelAndView.getModelMap().get(Constants.TIP_MESSAGE);
            }
        }
        return MessageUtil.EDIT_QUESTION_DATA_ERROR;

    }

    @RequestMapping(value = "/addOrEditQuestion", method = RequestMethod.POST)
    @ResponseBody
    public Object addOrEditQuestion(Question question) {

        try {
            /**
             * If question has id -> add question
             *              no id -> edit question
             */
            if (question.getId() == null) {
                questionService.addQuestion(question);
                /** Add question successfully */
                return MessageUtil.ADD_QUESTION_SUC;
            } else {
                questionService.editQuestion(question);
                /** Edit question successfully */
                return MessageUtil.EDIT_QUESTION_SUC;
            }
        } catch (RuntimeException e) {
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

    @RequestMapping(value = "/toQuestionList", method = RequestMethod.GET)
    public ModelAndView toQuestionList() {

        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName(Constants.QUESTION_LIST_PAGE);
        return modelAndView;

    }

    @RequestMapping(value = "/queryQuestionList", method = RequestMethod.POST)
    @ResponseBody
    public Object queryQuestionList(
                                    @RequestParam(value = "pageNo", defaultValue = "1") String pageNoStr,
                                    @RequestParam(value = "pageSize", defaultValue = "10") String pageSizeStr,
                                    @RequestParam(value = "titleStr", defaultValue = "") String title,
                                    @RequestParam(value = "orderField", defaultValue = "") String orderField
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
            Page<Question> page = new Page<Question>(pageNo, pageSize);
            FuzzyCriterion<Question> fuzzyCriterion = questionService.findQuestionList(new FuzzyCriterion<Question>(orderField, title, page));
            return fuzzyCriterion;
        } catch (RuntimeException e) {
            /** Handle all custom exception here*/
            ModelAndView modelAndView = new ModelAndView();
            setRequestScopeAttribute(e, modelAndView);
            return modelAndView.getModelMap().get(Constants.TIP_MESSAGE);
        }

    }

    @RequestMapping(value = "/deleteQuestion", method = RequestMethod.POST)
    @ResponseBody
    public Object deleteQuestion(@RequestParam(value = Question.DEL_MARK, required = false) String[] idArr) {

        try {
            questionService.deleteQuestion(idArr);
            return MessageUtil.DELETE_QUESTION_SUC;
        } catch (RuntimeException e) {
            ModelAndView modelAndView = new ModelAndView();
            setRequestScopeAttribute(e, modelAndView);
            return modelAndView.getModelMap().get(Constants.TIP_MESSAGE);
        }

    }
}
