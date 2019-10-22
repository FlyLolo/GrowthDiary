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
    pageSize:9,
    photoWidth: wx.getSystemInfoSync().windowWidth / 5,

    popTop: 0, //弹出点赞评论框的位置
    popWidth: 0, //弹出框宽度
    btnHidden: true,
    
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
        if (res.statusCode == 200 && res.data.code == 0) {
          var list = res.data.data.items;
          for (var i = 0; i < list.length;i++){
            if (list[i].praiseList != null && list[i].praiseList.length > 0){
              list[i].praiseStr = "♡ " + list[i].praiseList.join(", ");
            }
            list[i].canPraise = !(list[i].praiseList != null && list[i].praiseList.indexOf(app.globalData.userInfo.userName) > -1);
            list[i].canDelete = (list[i].userCode == app.globalData.userInfo.userCode);

            if (list[i].imageList != null && list[i].imageList.length > 0)
            {
              for (var k = 0; k < list[i].imageList.length; k++) {
                list[i].imageList[k] = that.data.fileServer + list[i].imageList[k];
              }
            }



          }
          that.setData({ list: list });
          console.log("---------------", list);
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
  
  //点击出现输入框
  showInput: function (e) {
    this.setData({
      showInput: true,
      discussIndex: e.currentTarget.dataset.index
    })
  },
  //隐藏输入框
  onHideInput: function () {
    this.setData({
      showInput: false
    })
    
  },
  bindInputMsg:function(e)
  {
    this.setData({
      discussContent: e.detail.value
    })
  },
  sendDiscuss:function()
  {
    var record = that.data.list[that.data.discussIndex];
    record.changeField = "DiscussList";
    record.discussList = [{ userCode: app.globalData.userInfo.userCode, userName: app.globalData.userInfo.userName, content: that.data.discussContent}             ]
    record.state = 1;
    http.httpPost(
      "/api/record",
      record,
      function (res) {
        wx.showToast({
          title: '点赞成功',
        }),
          that.setList();

      }
    )
  }
})