var util = require('../../../utils/util.js')
var http = require('../../../utils/http.js')
var formatLocation = util.formatLocation
var sourceType = [
  ['camera'],
  ['album'],
  ['camera', 'album']
]
var sizeType = [
  ['compressed'],
  ['original'],
  ['compressed', 'original']
]
var app = getApp()
var that;
Page({
  data: {
    imageList: [],
    sourceTypeIndex: 2,
    sourceType: ['拍照', '相册', '拍照或相册'],
    sizeTypeIndex: 2,
    sizeType: ['压缩', '原图', '压缩或原图'],
    countIndex: 8,
    count: [1, 2, 3, 4, 5, 6, 7, 8, 9],
    hasLocation: false,

  },
  onLoad: function (options) {
    that = this;
  },
  sourceTypeChange: function(e) {
    this.setData({
      sourceTypeIndex: e.detail.value
    })
  },
  sizeTypeChange: function(e) {
    this.setData({
      sizeTypeIndex: e.detail.value
    })
  },
  countChange: function(e) {
    this.setData({
      countIndex: e.detail.value
    })
  },
  chooseImage: function() {

    wx.chooseImage({
      sizeType: sizeType[this.data.sizeTypeIndex],
      count: this.data.count[this.data.countIndex],
      success: function(res) {
        if (res.tempFilePaths && res.tempFilePaths.length > 0) {
          that.setData({
            imageList: res.tempFilePaths
          });
        }
      }
    })
  },
  previewImage: function(e) {
    var current = e.target.dataset.src

    wx.previewImage({
      current: current,
      urls: this.data.imageList
    })
  },
  //位置
  chooseLocation: function() {
    console.log("chooseLocation");
    wx.chooseLocation({
      success: function(res) {
        console.log("Location",res)
        that.setData({
          hasLocation: true,
          location: res,
          locationAddress: res.address
        })
      }
    })
    console.log("chooseLocation2");
  },
  clear: function() {
    this.setData({
      hasLocation: false
    })
  },
  //表单提交
  formSubmit: function(e) {
    console.error('form发生了submit事件，携带数据为：', e);
    var count = that.data.imageList.length;
    if (count == 0 && e.detail.value.textarea.length < 1) {
      //提示无内容
      wx.showToast({
        title: "不能发表空消息。"
      });
      return
    }
    console.log(that.data.location);
    var recordId = "";
    var imagePathList = [];
    for (var i = 0; i < that.data.imageList.length; i++) {
      imagePathList.push(that.data.imageList[i].substring(that.data.imageList[i].lastIndexOf("/") + 1));
    }
    http.httpPost(
      "/api/record",
      {
        Content: e.detail.value.textarea,
        Location: that.data.location,
        ItemCount:count,
        State:-1,
        ImageList: imagePathList
      },
      function(res) {
        const data = res.data
        //do something
        console.log(res);

        recordId = res.data.data;
        console.log("count:" , count);
        if (count > 0) {
          console.log("gogogo");
          for (var i = 0; i < count; i++) {
            console.log("i:" + i);
            http.uploadFile(
              that.data.imageList[i],
              {
                UploadType:"Record",
                RecordId: recordId,
                State:-1
              }
            )
          }
        }

      }
    )
    wx.showLoading({
      title: '上传中',
    })

    setTimeout(function () {
      wx.hideLoading();
        wx.switchTab({
          url: "/pages/note/index/index"
        })
    }, 500 * count)

  },
  cancelBtn: function() {
    wx.navigateBack({
      delta: 1
    })
  }


})