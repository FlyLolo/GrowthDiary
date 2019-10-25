var util = require('../../../utils/util.js')
var http = require('../../../utils/http.js')

var app = getApp()
var that;
Page({
  data: {
    recordType:[{ code: 1, name: "身高" }, { code: 2, name: "体重" }],
    recordTypeIndex: 0,
  },
  onLoad: function (options) {
    that = this;
  },
  recordTypeChange: function(e) {
    this.setData({
      recordTypeIndex: e.detail.value
    })
  },
  
  //表单提交
  formSubmit: function(e) {
    console.error('form发生了submit事件，携带数据为：', e, that.data.recordType[that.data.recordTypeIndex].code);
    
    http.httpPost(
      "/api/record",
      {
        UserCode: app.globalData.userInfo.userCode,
        UserName: app.globalData.userInfo.userName,
        Value: parseFloat(e.detail.value.value),
        RecordType: that.data.recordType[that.data.recordTypeIndex].code,
        State:1,
      },
      function(res) {
      }
    )

    wx.navigateBack({
      delta: 2
    })

  },
  cancelBtn: function() {
    wx.navigateBack({
      delta: 1
    })
  }


})