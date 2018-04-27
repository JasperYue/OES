package com.augmentum.dao;

import java.util.List;

import com.augmentum.model.Exam;
import com.augmentum.model.Question;
import com.augmentum.util.FuzzyCriterion;

public interface QuestionDao {

    /**
     * Add the question.
     * @param question
     * @return primary key
     */
    public long addQuestion(Question question);

    /**
     * Edit the question.
     * @param question
     * @return successful | failed
     */
    public boolean editQuestion(Question question);

    /**
     * Batch delete the question.
     * @param objArr
     * @return number of affected rows
     */
    public int deleteQuestion(Object[]... objArr);

    /**
     * Get single question.
     * @param question
     * @return question
     */
    public Question getQuestion(Question question);

    /**
     * Get the question list fit for specific condition.
     * @param fuzzyCriterion
     * @return question list
     */
    public List<Question> findQuestion(FuzzyCriterion<Question> fuzzyCriterion);

    /**
     * Get the record counts in database.
     * @param fuzzyCriterion
     * @return number of records
     */
    public int getQuestionCount(FuzzyCriterion<Question> fuzzyCriterion);

    /**
     * Find questionList randomly when creating exam.
     * @param exam
     * @return question list
     */
    public List<Question> findQuestionIdList(Exam exam);

    /**
     * Modify question "refer_mark" 0[not refer] -> 1[refer] when the question referred by exam.
     * @param objArr
     * @return number of affected rows
     */
    public int batchEditQuestion(Object[]... objArr);

}
