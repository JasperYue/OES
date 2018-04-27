package com.augmentum.service;

import com.augmentum.model.Exam;
import com.augmentum.util.FuzzyCriterion;

public interface ExamService {

    /**
     * Transcation
     * Add Exam by get question randomly.
     * 1.if current question bank's stock is no more than the question user needed,
     *   save this exam as a draft.(modify status to 0)
     * 2.if the question user needed is enough, add Exam.(modify status to 1)
     * 3.Put relations between question and exam into exam_question.
     * @param exam
     */
    public void addExam(Exam exam, boolean saveFlag);

    /**
     * Get exam list fit for all conditions by pagination.
     * @param fuzzyCriterion
     * @return page object contains exam list.
     */
    public FuzzyCriterion<Exam> findExamList(FuzzyCriterion<Exam> fuzzyCriterion);
}
