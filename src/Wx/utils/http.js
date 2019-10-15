var app = getApp();
const httpGet = function (url, data, success, fail, requireToken = true) {
  //console.log(requireToken);
  wx.request({
    url: app.globalData.server + url,
    data: data,
    header: requestHeader(requireToken),
    success: success,
    fail: fail
  })
}

const httpPost = function (url, data, success, fail, requireToken = true) {
  wx.request({
    url: app.globalData.server + url,
    data: data,
    method: "POST",
    header: requestHeader(requireToken),
    success: success,
    fail: fail
  })
}

const httpPut = function (url, data, success, fail, requireToken = true) {
  wx.request({
    url: app.globalData.server + url,
    data: data,
    method: "PUT",
    header: requestHeader(requireToken),
    success: success,
    fail: fail
  })
}

const uploadFile = function (filePath, formData, success, fail, requireToken = true) {
  wx.uploadFile({
    url: app.globalData.server + "/api/file",
    filePath: filePath,
    name: 'file',
    formData: formData,
    header: fileUploadHeader(requireToken),
    success: success,
    fail: fail
  })
}

const requestHeader = function (requireToken) {
  if (requireToken) {
    console.log(app.globalData.userInfo.loginCode);
    return {
      'content-type': 'application/json',
      'token': app.globalData.userInfo.loginCode
    };

  }
  else {
    return { 'content-type': 'application/json' };
  }
}

const fileUploadHeader = function (requireToken) {
  if (requireToken) {
    return { 'token': app.globalData.userInfo.loginCode };

  }
  else {
    return null;
  }
}


module.exports = {
  httpGet: httpGet,
  httpPost: httpPost,
  httpPut: httpPut,
  uploadFile: uploadFile
}


