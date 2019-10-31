// pages/user/user.js
var userCommon = require('../../utils/userCommon.js');
var http = require('../../utils/http.js');
const app = getApp();
var that;
Page({

  /**
   * 页面的初始数据
   */
  data: {
    user: app.globalData.userInfo,
    appVersion: app.globalData.appVersion,
    weatherInfo:null
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
that = this;
    console.log(app.globalData);
    this.setData({ user: app.globalData.userInfo, showSysManage: userCommon.hasSystemManagerRole()}); 
  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {
    that.getWeather();
  },


  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  getWeather:function()
  {
    console.log("res");
    http.httpGet(
      "/api/Weather",
      {},
      function (res) {
        
        if (res.statusCode == 200 && res.data.code == 0) {
          
          that.setData({ weatherInfo:  res.data.data });
          console.log(that.data.weatherInfo);
        }
      }
    );
  }

})


