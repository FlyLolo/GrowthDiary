var http = require('../../utils/http.js')
//获取应用实例
const app = getApp()
var that
Page({
  data: {
    userInfo: app.globalData.userInfo,
    loginState: 0,
    canIUse: wx.canIUse('button.open-type.getUserInfo'),
    message: ""
  },
  onLoad: function() {
    var state = 0;
    that = this;
    // 获取用户信息
    wx.getSetting({
      success: res => {
        //是否已授权
        if (res.authSetting['scope.userInfo']) {
          state = this.userLogin({});
        } else {
          that.setState(-1, "");
        }
      }
    })
  },
  userLogin:function(userInfo)
  {
    var state = 1;
console.log("userinfoww",userInfo);
    // 已授权后再登录，验证用户信息
    wx.login({
      success: res => {

        userInfo.loginCode =  res.code;
        // 发送 res.code 到后台换取 openId, sessionKey, unionId
        http.httpGet(
          "/api/Account",
          userInfo,
          function (res) {
            console.log(res);
            if(res.statusCode == 200 && res.data.code == 0){
              app.globalData.userInfo = res.data.data;
              console.log(app.globalData.userInfo);
              that.toList();
            }
            else
            {
              that.setState(-8, " ");
            }
          }, function (res) {
            console.log('mmm');
            that.setState(-8, " "); //temp  -16
          },false
        );
      }
    })
  },
  getUserInfo: function(e) {
    app.globalData.userInfo = e.detail.userInfo;
    this.setData({
      userInfo: e.detail.userInfo,
    })
    this.userLogin(e.detail.userInfo);
  },
  setState: function(state, msg) {
    //console.log("loginState：" + state);
    app.globalData.loginState = state;
    if (!msg || msg.length == 0) {
      //0： 无状态（默认） 1：已授权  -1：未授权  2：待审核  -2：审核未通过  8：已登录  -8：登录失败 -16 连接服务器失败
      switch (state) {
        case 2:
          msg = "已提交申请，请等待管理员审核。";
          break;
        case 3:
          msg = "未通过管理员审核。";
          break;
        case -8:
          msg = "登录失败。";
          break;
        case -16:
          msg = "连接服务器失败。";
          break;
        default:
          break;
      };
    }
    this.setData({
      loginState: state,
      message: msg
    });
  },
  toList: function() {
    wx.switchTab({
      url: "/pages/note/index/index"
    })
  },
  formSubmit:function(e){
    console.log("submit",e.detail.value);
    var userInfo = that.data.userInfo;
    console.log("submit", userInfo);
    Object.assign(userInfo, e.detail.value);
    that.userLogin(userInfo);
  }
})