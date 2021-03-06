﻿using GrowthDiary.IRepository;
using GrowthDiary.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowthDiary.Repository
{
    public class RecordRepository : BaseRepository<Record>, IRecordRepository
    {
        public RecordRepository(MongoHelper mongoHelper)
        {
            _mongoHelper = mongoHelper;
        }
        public async Task<List<Record>> FindAllAsync(RecordSearchModel searchModel)
        {
            var builder = Builders<Record>.Filter;
            var filter = builder.Eq(m => m.State, searchModel.State);
            var list = await _mongoHelper.FindListAsync<Record>(filter);
            searchModel.RecordCount = list.Count;
            if (searchModel.IsPagination)
            {
                return list.OrderByDescending(m => m.CreateTime).Skip((searchModel.PageIndex - 1) * searchModel.PageSize).Take(searchModel.PageSize).ToList();
            }
            return list.OrderByDescending(m => m.CreateTime).ToList();
        }
    }
}
