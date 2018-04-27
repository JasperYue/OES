<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ include file="common.jsp" %>
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>Login</title>
    <link href="${applicationScope.STATIC_URL}/css/normalize.css" rel="stylesheet" />
    <link href="${applicationScope.STATIC_URL}/css/common.css" rel="stylesheet" />
    <link href="${applicationScope.STATIC_URL}/css/login.css" rel="stylesheet" />
  </head>
  <body>
    <div class="wrapper">
      <div class="container clearfix">
        <div class="leftContent fl">
          <img src="${applicationScope.STATIC_URL}/images/LOGO_Web_Login_90x180.png" alt="Logo" />
          <p>Online Exam Web System</p>
        </div>
        <div class="rightContent fl">
          <h3>Welcome to login!</h3>
          <form action="page/user/login" method="post" id="loginForm">
          <ul class="panel fl">
            <li>
            <c:if test="${requestScope.TIP_MESSAGE !=null}">
              <p class="errMsgLoginShow">${requestScope.TIP_MESSAGE}</p>
            </c:if>
            </li>
            <li><i class="user"></i><input type="text" name="name" id="userName" value="${param.name}" placeholder="Username" />
            <c:if test="${requestScope.ERROR_MESSAGE.name !=null}">
                <i class="err"></i>
            </c:if></li>
            <li>
            <c:if test="${requestScope.ERROR_MESSAGE.name !=null}">
              <p class="errMsgLoginShow">${requestScope.ERROR_MESSAGE.name}</p>
            </c:if>
            </li>
            <li><i class="pwd"></i><input type="password" name="password" id="password" value="${param.password}" placeholder="Password" />
            <c:if test="${requestScope.ERROR_MESSAGE.password !=null}">
                <i class="err"></i>
            </c:if></li>
            <li>
            <c:if test="${requestScope.ERROR_MESSAGE.password !=null}">
              <p class="errMsgLoginShow">${requestScope.ERROR_MESSAGE.password}</p>
            </c:if>
            </li>
            <li><input type="button" value="Login" onclick="login()" />
            <li><input type="hidden" name="remember" value="0" />
                <input type="hidden" name="go" value="${requestScope.go }"/>
                <input type="hidden" name="queryString" value=""/>
                <label title="Save Username And Password For 3 Days"></label>
                <span class="rem">Remember me!</span>
                <a href="javascript:void(0)">Forget password?</a>
            </li>
          </ul>
          </form>
        </div>
      </div>
      <div class="footer">
        copyright&copy;2014 Augmentum.Inc. All Rights Reserved
      </div>
    </div>
  </body>
  <script src="${applicationScope.STATIC_URL}/js/jquery-1.10.2.min.js"></script>
  <script src="${applicationScope.STATIC_URL}/js/login.js"></script>
</html>