package com.augmentum.dao;

import java.util.List;

import com.augmentum.model.Exam;
import com.augmentum.util.FuzzyCriterion;

public interface ExamDao {

    /**
     * Add exam and return the primary key of this item
     * @param exam
     * @return primary key
     */
    public long addExam(Exam exam);

    /**
     * Find exam list on specific condition by pagination
     * @param fuzzyCriterion
     * @return exam list
     */
    public List<Exam> findExamList(FuzzyCriterion<Exam> fuzzyCriterion);

    /**
     * Get the count of exam on specific condition
     * @param fuzzyCriterion
     * @return
     */
    public int getExamCount(FuzzyCriterion<Exam> fuzzyCriterion);

    /**
     * Insert mapping between exam and questionList to exam_question
     * @param exam
     * @param questionList
     * @return
     */
    public int batchInsertQuestionToPaper(Exam exam, Object[]... params);

    /**
     * Edit exam's num | id : 10 | num : E000id |
     * @param exam
     * @return
     */
    public boolean editExam(Exam exam);

}
