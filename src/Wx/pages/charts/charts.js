import * as echarts from '../../ec-canvas/echarts';
var http = require('../../utils/http.js');
var util = require('../../utils/util.js');
const app = getApp();
var that
var Chart = null;
Page({
  data: {
    ec: {
      lazyLoad: true
    }
  },
  onLoad: function (options) {
    this.echartsComponnet = this.selectComponent('#mychart');
    that = this;
    this.setDataList();

  },
  setDataList: function () {
    http.httpGet(
      "/api/Record",
      { State: 1, IsPagination: false },
      function (res) {
        if (res.statusCode == 200 && res.data.code == 0) {
          console.log("table", res);
          that.setData({ tableRows: res.data.data.items });
          that.setChart();
        }
      }
    );
  },
  setChart: function () {
    //如果是第一次绘制
    if (!Chart) {
      Chart = this.init_echarts(); //初始化图表
    } else {
      this.setOption(Chart); //更新数据
    }
  },
  //初始化图表
  init_echarts: function () {
    this.echartsComponnet.init((canvas, width, height) => {
      // 初始化图表
      Chart = echarts.init(canvas, null, {
        width: width,
        height: height
      });
      // Chart.setOption(this.getOption());
      this.setOption(Chart);
      // 注意这里一定要返回 chart 实例，否则会影响事件处理等
      return Chart;
    });
  },
  setOption: function (Chart, isClear = true) {
    if (isClear) { Chart.clear(); }

    var dataList = [];
    var legend = [];
    var found = false;
    var length = 0;
    for (var i = that.data.tableRows.length - 1; i > -1; i--) {
      length = dataList.length;
      found = false;
      for (var k = 0; k < length; k++) {
        if (dataList[k].name == that.data.tableRows[i].recordType) {
          dataList[k].data.push([that.data.tableRows[i].createTime, that.data.tableRows[i].value]);
          found = true;
          break;
        }
      }

      if (!found) {
        legend.push(that.data.tableRows[i].recordType);
        dataList.push(
          {
            name: that.data.tableRows[i].recordType,
            type: 'line',
            showAllSymbol: true,
            symbolSize: 1,
            data: [[that.data.tableRows[i].createTime, that.data.tableRows[i].value]]
          }
        );
      }
    }

    console.log("dataList", dataList, legend);
 
    Chart.setOption(that.getOption(dataList, legend));  //获取新数据

  },
  getOption: function (dataList, legend) {
    var option = {
      color: ["#FF9900", "#99CC33", "#CCCC33", "#FFFF00", "#CC6699", "#3366CC", "#9933FF", "#FF6666", "#663300", "#993399", "#999966"],
      title: {
        text: '身高体重趋势',
        subtext: '可拖动下面标尺'
      },
      dataZoom: {
        show: true,
        start: 70
      },
      legend: {
        data: legend,
        width: '65%',
        left: '30%'
      },
      grid: {
        y2: 80
      },
      xAxis: [
        {
          type: 'time',
          splitNumber: 5
        }
      ],
      yAxis: [
        {
          type: 'value'
        }
      ],
      series: dataList
    };
    return option;
  },
  onReady() {
  }
});
