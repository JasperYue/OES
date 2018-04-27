<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
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
                  <input type="hidden" name="pageNo" value="1"/>
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
                              <option value="10" selected>10</option>
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
            <div class="detailPanel">
                <ul class="questionDetailList">
                  <li><label class="questionTitle">QuestionID:</label><p></p></li>
                  <li><label>Question:</label><div></div></li>
                  <li><label id="detailList">Answer:</label><p><i>A</i></p></li>
                  <li><label></label><p><i>B</i></p></li>
                  <li><label></label><p><i>C</i></p></li>
                  <li class="noBottom"><label></label><p><i>D</i></p></li>
                </ul>
                <div class="clearfix">
                  <a class="fl" href="javascript:void(0)" onclick="toEdit()">Edit</a>
                  <!-- cancelToList  -->
                  <a class="fr" href="javascript:void(0)">Delete</a>
                </div>
            </div>
          </article>
        </section>
      </section>
