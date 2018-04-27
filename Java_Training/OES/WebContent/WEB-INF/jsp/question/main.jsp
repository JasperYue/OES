<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@include file="header.jsp" %>
<section class="questionPanel">
        <section class="bread">
          <span>Question Management &gt; </span>
          <span class="nowBread">Question List</span>
        </section>
        <section class="content clearfix">
          <aside class="fl">
            <ul class="tree">
              <li><a class="list selected" href="javascript:void(0)" data-item="listPanel" >Question List</a></li>
              <li><a class="create" href="javascript:void(0)" data-item="addOrEditPanel" >Create Question</a></li>
            </ul>
          </aside>
          <article class="fl">
            <div class="listPanel">
              <form id="questionForm">
                <section class="mainHeader clearfix">
                  <p class="fr clearfix">
                    <input type="text" name="titleStr" placeholder="Please input the keyword" />
                    <input class="search fr" type="button" >
                  </p>
                </section>
                <section class="mainContent">
                  <input type="hidden" name="orderField" />
                  <input type="hidden" name="pageNo" />
                  <table id="questionList">
                    <thead>
                      <tr>
                        <td></td>
                        <td>Num<i class="increase"></i></td>
                        <td>Description</td>
                        <td>Edit</td>
                        <td><input type="checkbox" id="ckAll" class="ckUncheck" /><span class="checkOrNot">All Checked</span></td>
                      </tr>
                    </thead>
                    <tbody>
                    </tbody>
                    <tfoot>
                      <tr>
                        <td colspan="4">
                          <p class="pagination">
                          </p>
                          <p class="toolbar">
                            <select name="pageSize">
                              <option value="5">5</option>
                              <option value="10">10</option>
                            </select>
                            <span class="code">Per page</span>
                            <input type="text" id="questionPageNo">
                            <a href="javascript:void(0)">Go</a>
                          </p>
                        </td>
                        <td><input type="button" value="Delete" onclick="showMsgBox('Are you sure to delete those question?',0)"/></td>
                      </tr>
                    </tfoot>
                  </table>
                </section>
              </form>
            </div>
            <div class="addOrEditPanel">
              <form id="addOrEditForm">
                <input type="hidden" name="id">
                  <ul class="questionUlList">
                    <li></li>
                    <li><label class="questionTitle">Question:</label><textarea class="question_title" name="title"></textarea><span class="areaMsg"></span></li>
                    <li><label id="answerList">Answer:</label><input type="radio" name="answer" value="1"><i>A</i><input class="questionInput" type="text" name="itemA" /><span></span></li>
                    <li><label></label><input type="radio" name="answer" value="2"><i>B</i><input class="questionInput" type="text" name="itemB" /><span></span></li>
                    <li><label></label><input type="radio" name="answer" value="3"><i>C</i><input class="questionInput" type="text" name="itemC" /><span></span></li>
                    <li  class="noBottom"><label></label><input type="radio" name="answer" value="4"><i>D</i><input class="questionInput" type="text" name="itemD" /><span></span></li>
                  </ul>
                  <div class="clearfix">
                    <a class="fl" href="javascript:void(0)" onclick="checkAll()">Save</a>
                    <a class="cancelToList fr" href="javascript:void(0)">Cancel</a>
                  </div>
              </form>
            </div>
          </article>
        </section>
      </section>
      
      
      <section class="examPanel">
        <section class="bread">
          <span>Exam Management &gt; </span>
          <span class="nowBread">Exam List</span>
        </section>
        <section class="content clearfix">
          <aside class="fl">
            <ul class="tree">
              <li><a class="list selected" href="javascript:void(0)" data-item="listPanel" >Exam List</a></li>
              <li><a class="create" href="javascript:void(0)" data-item="addPanel" >Create Exam</a></li>
            </ul>
          </aside>
          <article class="fl">
            <div class="listPanel">
              <form id="examForm">
                <section class="mainHeader clearfix">
                  <p class="fl clearfix">
                    <input type="text" name="name" placeholder="Please input the keyword" />
                    <input class="search fr" type="button" />
                  </p>
                  <p class="fr clearfix">
                    <input type="text" name="timeBegin" placeholder="timeBegin" />
                    <span>—</span>
                    <input type="text" name="timeEnd" placeholder="timeEnd" />
                    <input class="queryDate" type="button" value="Date" />
                  </p>
                </section>
                <section class="mainContent">
                  <input type="hidden" name="orderField" />
                  <input type="hidden" name="pageNo" />
                  <table id="examList">
                    <thead>
                      <tr>
                        <td></td>
                        <td>Num<i class="increase" data-item="num"></i></td>
                        <td>Name<i class="increase"  data-item="name"></i></td>
                        <td>Effective Time<i class="increase"  data-item="effective_time"></i></td>
                        <td>Duration(Mins)</td>
                        <td>Creator</td>
                        <td>status</td>
                      </tr>
                    </thead>
                    <tbody>
                    </tbody>
                    <tfoot>
                      <tr>
                        <td colspan="5">
                          <p class="pagination">
                          </p>
                          <p class="toolbar">
                            <select name="pageSize">
                              <option value="5">5</option>
                              <option value="10">10</option>
                            </select>
                            <span class="code">Per page</span>
                            <input type="text" id="examPageNo" />
                            <a href="javascript:void(0)">Go</a>
                          </p>
                        </td>
                      </tr>
                    </tfoot>
                  </table>
                </section>
              </form>
            </div>
            <div class="addPanel">
              <form id="addForm">
                  <input type="hidden" name="saveFlag" value="false" />
                  <ul class="examUlList">
                      <li><label>Exam Name:<em>*</em></label><input type="text" name="name" /><span></span></li>
                      <li><label>Description:</label><textarea name="description"></textarea><span></span></li>
                      <li>
                          <label>Effective Time:<em>*</em></label><input type="text" name="effectiveTime" placeholder="Select the date" />
                          <input type="text" name="hour" placeholder="00" maxlength="2" />
                          <i>:</i>
                          <input type="text" name="min" placeholder="00" maxlength="2" />
                          <span></span>
                      </li>
                      <li><label>Duration:<em>*</em></label><input type="text" name="duration" />min<span></span></li>
                      <li>
                          <label>Question Setting:<em>*</em></label><p>Question Points:</p><input type="text" name="singleScore"/><p>Question Quantity:</p><input type="text" name="needQuantity"/>
                          <span></span>
                      </li>
                      <li>
                          <label></label><p>Total Score:</p><input type="text" name="totalScore"/><p>Pass Criteria:</p><input type="text" name="passCriteria"/>
                          <span></span>
                      </li>
                  </ul>
                  <div class="clearfix">
                    <a class="fl" href="javascript:void(0)" >Create</a>
                    <a class="cancelToList fr" href="javascript:void(0)">Cancel</a>
                  </div>
              </form>
            </div>
          </article>
        </section>
      </section>
      <%@ include file="footer.jsp"%>