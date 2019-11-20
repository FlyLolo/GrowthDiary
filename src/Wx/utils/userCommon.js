const app = getApp();
const hasSystemManagerRole = function () {
  return app.globalData.userInfo != null && app.globalData.userInfo.roles != null && app.globalData.userInfo.roles.indexOf('001') > -1
}
const hasBusinessRole = function () {
  return app.globalData.userInfo != null && app.globalData.userInfo.roles != null && app.globalData.userInfo.roles.indexOf('002') > -1
}
module.exports = {
  hasSystemManagerRole: hasSystemManagerRole,
  hasBusinessRole: hasBusinessRole
}


