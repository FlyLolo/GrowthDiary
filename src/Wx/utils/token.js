const app = getApp();

const setToken = function(data) {
  app.globalData.userInfo = data.user;
  app.globalData.accessToken = data.accessToken;
  app.globalData.refreshToken = data.refreshToken;
  refreshToke();
}

const refreshToke = function() {
  var datestr = app.globalData.accessToken.expires.replace('T',' ').substr(0,16);

  var times = Date.parse(datestr) - new Date().getTime() - 5 * 60 * 1000;

  setTimeout(getToken, times);
}
const getToken = function() {
  wx.request({
    url: app.globalData.server + "/token",
    data: null,
    header: {
      'Authorization': "bearer " + app.globalData.refreshToken.tokenContent
    },
    success: function(res) {
      if (res.statusCode == 200 && res.data.code == 0) {
        console.log("token", res);
        app.globalData.accessToken = res.data.data;
        refreshToke();
      }
    },
    fail: function(res) {
      wx.navigateTo({
        url: '/pages/launch/launch'
      })
    }
  })
}

module.exports = {
  setToken: setToken
}