package com.augmentum.dao;

import java.util.List;

import com.augmentum.model.Exam;
import com.augmentum.model.Question;
import com.augmentum.util.FuzzyCriterion;

public interface QuestionDao {

    /**
     * Add the question
     * @param question
     * @return
     */
    public long addQuestion(Question question);

    /**
     * Edit the question
     * @param question
     * @return
     */
    public boolean editQuestion(Question question);

    /**
     * Batch delete the question
     * @param objArr
     * @return
     */
    public int deleteQuestion(Object[]... objArr);

    /**
     * Get single question
     * @param question
     * @return
     */
    public Question getQuestion(Question question);

    /**
     * Get the question list fit for specific condition
     * @param fuzzyCriterion
     * @return
     */
    public List<Question> findQuestion(FuzzyCriterion<Question> fuzzyCriterion);

    /**
     * Get the record counts in database
     * @param fuzzyCriterion
     * @return
     */
    public int getQuestionCount(FuzzyCriterion<Question> fuzzyCriterion);

    /**
     * Get all question in per exam
     * @param exam
     * @return
     */
    public List<Question> getPaper(Exam exam);

    public List<Question> findQuestionIdList(Exam exam);
    public int batchEditQuestion(Object[]... objArr);

}
