using GrowthDiary.Model;
using GrowthDiary.Repository;
using Microsoft.Extensions.Configuration;
using System.IO;
using Xunit;

namespace GrowthDiary.Test
{
    public class DataInit
    {
        [Fact]
        public async void Init()
        {
            string path = Directory.GetCurrentDirectory().Replace(".Test\\bin\\Debug\\netcoreapp3.0", "");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json")
                .Build();
            MongoHelper mongoHelper = new MongoHelper(configuration);

            await mongoHelper.InsertOneAsync(new User { UserCode = "001", UserName = "����", Password = "111111", State = 1 });
            await mongoHelper.InsertOneAsync(new User { UserCode = "001", UserName = "����", Password = "111111", State = 1 });

            await mongoHelper.InsertOneAsync(new RecordTypeDefinition { RecordType = RecordType.Height, Name = "���", Unit = "cm", MaxValue = 200, MinValue = 0 });
            await mongoHelper.InsertOneAsync(new RecordTypeDefinition { RecordType = RecordType.Weight, Name = "����", Unit = "kg", MaxValue = 200, MinValue = 0 });
        }
    }
}
