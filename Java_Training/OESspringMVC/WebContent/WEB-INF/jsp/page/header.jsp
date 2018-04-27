<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<%@ include file="../common.jsp" %>
<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <title>Online Exam System</title>
    <link href="${applicationScope.STATIC_URL}/css/normalize.css" rel="stylesheet">
    <link href="${applicationScope.STATIC_URL}/css/common.css" rel="stylesheet">
    <link href="${applicationScope.STATIC_URL}/css/style.css" rel="stylesheet">
  </head>
  <body>
    <div class="shade"></div>
    <div class="msgbox">
      <label class="close"></label>
        <h3></h3>
        <div class="btn-group clearfix">
          <input class="fl" type="button" value="Yes" data-item="question" />
          <input class="fr" type="button" value="No" />
        </div>
    </div>
    <div class="alertbox"><h3></h3></div>
    <div class="wrapper">
      <header class="clearfix">
        <img class="fl" src="${applicationScope.STATIC_URL}/images/LOGO_Web_40x240.png">
        <h3 class="fl">Online Exam System</h3>
        <ul class="fr">
          <li>
            <a href="javascript:void(0)">中文</a>
          </li>
          <li><span>${sessionScope.USER.name}</span><a href="page/user/logout">Logout</a></li>
        </ul>
      </header>
      <nav>
        <ul class="clearfix">
          <li class="fl"><a class="panelChecked" href="javascript:void(0)" data-item="questionPanel">Question Management</a></li>
          <li class="fl"><a href="javascript:void(0)" data-item="examPanel">Exam Management</a></li>
        </ul>
      </nav>