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
            MongoHelper mongoHelper = new MongoHelper(configuration);

            //await mongoHelper.InsertOneAsync(new User { UserCode = "001", UserName = "张三", Password = "111111", State = 1 });
            //await mongoHelper.InsertOneAsync(new User { UserCode = "001", UserName = "李四", Password = "111111", State = 1 });

            //await mongoHelper.InsertOneAsync(new RecordTypeDefinition { RecordType = RecordType.Height, Name = "身高", Unit = "cm", MaxValue = 200, MinValue = 0 });
            //await mongoHelper.InsertOneAsync(new RecordTypeDefinition { RecordType = RecordType.Weight, Name = "体重", Unit = "kg", MaxValue = 200, MinValue = 0 });

            Random random = new Random();
            
            for (int i = 0; i < 30; i++)
            {
                await mongoHelper.InsertOneAsync(new Model.Record { RecordType = RecordType.Height, UserCode = "001", UserName = "李四", Value = 100 - i * random.Next(1,2), State = 1,CreateTime = DateTime.Now.AddDays( - 1000 + i * random.Next(1,5)) });
            }

            //for (int i = 0; i < 30; i++)
            //{
            //    await mongoHelper.InsertOneAsync(new Model.Record { RecordType = RecordType.Weight, UserCode = "001", UserName = "李四", Value = random.Next(20, 100), State = 1, CreateTime = DateTime.Now.AddDays(100 - random.Next(2, 100)) });
            //}
        }
    }
}
