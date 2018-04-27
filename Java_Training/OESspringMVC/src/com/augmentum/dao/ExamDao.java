package com.augmentum.dao;

import java.util.List;

import com.augmentum.model.Exam;
import com.augmentum.util.FuzzyCriterion;

public interface ExamDao {

    /**
     * Add exam and return the primary key of this record.
     * @param exam
     * @return primary key
     */
    public long addExam(Exam exam);

    /**
     * Find exam list on specific condition by pagination.
     * @param fuzzyCriterion
     * @return exam list
     */
    public List<Exam> findExamList(FuzzyCriterion<Exam> fuzzyCriterion);

    /**
     * Get the count of exam on specific condition.
     * @param fuzzyCriterion
     * @return number of records
     */
    public int getExamCount(FuzzyCriterion<Exam> fuzzyCriterion);

    /**
     * Insert mapping between exam and questionList to exam_question.
     * @param exam
     * @param questionList
     * @return number of affected rows
     */
    public int batchInsertQuestionToPaper(Exam exam, Object[]... params);

    /**
     * Edit exam's num | id : 10 | num : E000 + id |.
     * @param exam
     * @return successful | failed
     */
    public boolean editExam(Exam exam);

}
