// pages/user/user.js
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
    this.setData({ user: app.globalData.userInfo}); 
  }
})