package com.augmentum.service;

import com.augmentum.model.Question;
import com.augmentum.util.FuzzyCriterion;

public interface QuestionService {

    /**
     * Add question.
     * @param question
     */
    public void addQuestion(Question question);

    /**
     * Edit question.
     * 1.If this question not used by other exam, then modify it.
     * 2.If this question used by other exam.
     *   2.1: delete it in logic way. | delete()
     *   2.2: add a new record. | add()
     * @param question
     */
    public void editQuestion(Question question);


    /**
     * Delete question in logical way.
     * Edit question's status from 1 to 0.
     * @param question
     */
    public void deleteQuestion(String[] idArr);

    /**
     * Get question details.
     * @param question
     * @return if question exits, return question. if not, throw exception.
     */
    public Question getQuestion(Question question);

    /**
     * Fuzzy search question list by pagiantion and conditions.
     * @param fuzzyCriterion
     * @return question list fit for all conditions.
     */
    public FuzzyCriterion<Question> findQuestionList(FuzzyCriterion<Question> fuzzyCriterion);

}
