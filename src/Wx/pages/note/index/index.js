var http = require('../../../utils/http.js')
var app = getApp()
var that

Page({
  /**
   * 页面的初始数据
   */
  data: {
    list: [],
    pageIndex:1,
    pageSize:20,
    recordCount: 0
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    that = this;
    let res = wx.getSystemInfoSync();
    let boxHeight = res.windowHeight - 135;
    this.setData({
      'boxHeight': boxHeight
    })
  },
  onShow:function()
  {
    that.setList();
  },
  onPullDownRefresh: function () {
    that.setList();
  },
  scrollToLower: function () {
    if (that.data.pageSize * that.data.pageIndex < that.data.recordCount){
      that.setList(1);
    }
  },
  setList:function(addPage = 0)
  {
    http.httpGet(
      "/api/record",
      { UserCode: app.globalData.userInfo.userCode, PageIndex: that.data.pageIndex + addPage, PageSize: that.data.pageSize, IsPagination: true, State: 1 }, //
      function(res){
        if (res.statusCode == 200 && res.data.code == 0) {
          that.setData({ 
            list: that.data.list.concat(res.data.data.items) ,
            pageIndex: res.data.data.pageIndex,
            recordCount: res.data.data.recordCount
           });
          console.log(that.data.recordCount,that.data.list);
        }
      },
      function (res) {
      }
    );
  },
  addRecord:function()
  {
    wx.navigateTo({
      url: '/pages/note/noteAdd/noteAdd'
    })
  },
  deleteRecord: function (e) {
    
    http.httpPost(
      "/api/record",
      {
        _id: e.currentTarget.dataset.id,
        State: 2,
      },
      function (res) {

      }
    );
    that.data.list.splice(e.currentTarget.dataset.index, 1);
    that.setData({ list: that.data.list }); 
  }
})