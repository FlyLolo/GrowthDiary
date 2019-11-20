using GrowthDiary.Model;
using GrowthDiary.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace GrowthDiary.Test
{
    public class DataInit
    {
        [Fact]
        public async Task Init()
        {
            string path = Directory.GetCurrentDirectory().Replace(".Test\\bin\\Debug\\netcoreapp3.0", "");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();
            MongoHelper _mongoHelper = new MongoHelper(configuration);

            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 50.2f, CreateTime = DateTime.Now.AddDays(-500), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 55.2f, CreateTime = DateTime.Now.AddDays(-470), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 58.5f, CreateTime = DateTime.Now.AddDays(-440), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 65.2f, CreateTime = DateTime.Now.AddDays(-410), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 67.2f, CreateTime = DateTime.Now.AddDays(-380), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 70.2f, CreateTime = DateTime.Now.AddDays(-350), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 73.2f, CreateTime = DateTime.Now.AddDays(-290), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 76.2f, CreateTime = DateTime.Now.AddDays(-230), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 78.2f, CreateTime = DateTime.Now.AddDays(-170), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 82.2f, CreateTime = DateTime.Now.AddDays(-80), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 85.2f, CreateTime = DateTime.Now.AddDays(-20), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 86.2f, CreateTime = DateTime.Now.AddDays(-10), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 87.2f, CreateTime = DateTime.Now.AddDays(-5), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 88.2f, CreateTime = DateTime.Now.AddDays(-1), RecordType = RecordType.Height, UserCode = "001", UserName = "张三", State = 1 });

            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 3.5f, CreateTime = DateTime.Now.AddDays(-500), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 4.5f, CreateTime = DateTime.Now.AddDays(-473), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 5.4f, CreateTime = DateTime.Now.AddDays(-445), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 6.5f, CreateTime = DateTime.Now.AddDays(-412), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 7.5f, CreateTime = DateTime.Now.AddDays(-386), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 8.0f, CreateTime = DateTime.Now.AddDays(-357), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 8.2f, CreateTime = DateTime.Now.AddDays(-292), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 8.8f, CreateTime = DateTime.Now.AddDays(-238), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 9.5f, CreateTime = DateTime.Now.AddDays(-179), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 10.2f, CreateTime = DateTime.Now.AddDays(-83), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 11.2f, CreateTime = DateTime.Now.AddDays(-22), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 12.2f, CreateTime = DateTime.Now.AddDays(-17), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 12.7f, CreateTime = DateTime.Now.AddDays(-6), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });
            await _mongoHelper.InsertOneAsync(new Model.Record { Value = 13.2f, CreateTime = DateTime.Now.AddDays(-2), RecordType = RecordType.Weight, UserCode = "001", UserName = "张三", State = 1 });

        }
    }
}
