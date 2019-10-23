var http = require('../../../utils/http.js')
var app = getApp()
var that
var imageReloadList = []

Page({
  /**
   * 页面的初始数据
   */
  data: {
    list: null,
    pageIndex:0,
    pageSize:9
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    that = this;
  },
  onShow:function()
  {
    that.setList();
  },
  onPullDownRefresh: function () {
    that.setList();
  },
  setList:function()
  {
    http.httpGet(
      "/api/record",
      { UserCode: app.globalData.userInfo.userCode, PageIndex: that.data.pageIndex, PageSize: that.data.pageSize, IsPagination: true, State: 1 }, //
      function(res){
        console.log("---------------", res.data.data);
        if (res.statusCode == 200 && res.data.code == 0) {
          that.setData({ 
            list: res.data.data.items,
            pageIndex: res.data.data.pageSeting.pageIndex,
            pageSize: res.data.data.pageSeting.pageIndex
           });
        }
      },
      function (res) {
        console.log("---------------", res);
      }
    );
  },
  addRecord:function()
  {
    wx.navigateTo({
      url: '/pages/note/noteAdd/noteAdd'
    })
  },
  deleteRecord: function () {
    wx.navigateTo({
      url: '/pages/note/noteAdd/noteAdd'
    })
  }
})