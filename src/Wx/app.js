//app.js
App({
  globalData: {
    userInfo: null,
    loginState: 0, //0： 无状态（默认） 1：已授权  -1：未授权  2：待审核  -2：审核未通过  8：已登录  -8：登录失败
    server: "https://hb.flylolo.cn"//server: "http://localhost:61721"//
  }
})