var http = require('../../utils/http.js')
//获取应用实例
const app = getApp()
var that
Page({
  data: {
    userInfo: app.globalData.userInfo,
    loginState: 0,
    canIUse: wx.canIUse('button.open-type.getUserInfo'),
    message: "",
    showAuth:false
  },
  onLoad: function() {
    var state = 0;
    that = this;
    // 获取用户信息
    wx.getSetting({
      success: res => {
        //是否已授权
        if (res.authSetting['scope.userInfo']) {
          state = that.userLogin({});
        } else {
          that.setState(-1, "");
        }
      }
    })
  },
  userLogin:function(userInfo)
  {
    var state = -8;

    // 已授权后再登录，验证用户信息
    wx.login({
      success: res => {
        userInfo.loginCode =  res.code;
        // 发送 res.code 到后台换取 openId, sessionKey, unionId
        http.httpGet(
          "/api/user",
          userInfo,
          function (res) {
            if (res.statusCode == 200 && res.data.code == 0) {
              app.globalData.userInfo = res.data.data;
              console.log("launch.getRoles", app.globalData.userInfo);
              state = app.globalData.userInfo.state; 
              //state =2
              if (state == 1){
                that.toList();
              }
            }
            that.setState(state, "");
          }, function (res) {
            that.setState(state, "正在连接服务器。。。"); //temp  -16
          }, false
        );        
      }
    })
  },
  getUserInfo: function(e) {
    app.globalData.userInfo = e.detail.userInfo;
    that.setData({
      userInfo: e.detail.userInfo,
    })
    that.userLogin(e.detail.userInfo);
  },
  setState: function(state, msg) {
    //console.log("loginState：" + state);
    app.globalData.loginState = state;
    if (!msg || msg.length == 0) {
      //0： 无状态（默认） 1：已授权  -1：未授权  2：待审核  -2：审核未通过  8：已登录  -8：登录失败
      switch (state) {
        case 2:
          msg = "抱歉，本小程序仅供本人使用，谢谢。";
          break;
        case -2:
          msg = "未通过管理员审核。";
          break;
        case -8:
          msg = "登录失败。";
          break;
        default:
          break;
      };
    }
    that.setData({
      loginState: state,
      message: msg
    });
  },
  toList: function() {
    wx.switchTab({
      url: "/pages/note/index/index"
    })
  },
  inputAuthorizationCode:function()
  {
    if(that.data.loginState == 2){
      that.setData({ showAuth: true });
    }
  },
  sendAuthorizationCode: function () {
    
    if (that.data.loginState == 2) {
      app.globalData.userInfo.loginCode = that.data.auCode;
      http.httpPut(
        "/api/user",
        app.globalData.userInfo,
        function (res) {
          console.log(res);
          if (res.statusCode == 200 && res.data.code == 0) {
            that.userLogin({});
            return;
          }
          else
          {
            wx.showToast({
              title: '授权码验证错误1。',
              icon: 'none'
            })
          }
        }, function (res) {
          wx.showToast({
            title: '授权码验证错误2。',
            icon: 'none'
          })
        }, false
      ); 

     // that.setData({ showAuth: false });
    }
  },
  auCodeInput:function(e){
    that.setData({ auCode:e.detail.value});
  }
})