using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using RPP.Core.Models;
using RPP.Core.Repository.Abstract;
using RPP.Core.Settings;
using RPP.Mongo.Context;
using RPP.Mongo.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RPP.Mongo.Repository
{
    public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : BaseModel, new()
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<TEntity> _collection;
        public MongoRepositoryBase(IOptions<MongoSettings> settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<TEntity>();
        }
        public ResponseList<TEntity> GetAll()
        {
            var result = new ResponseList<TEntity>();
            try
            {
                var data = _collection.AsQueryable().ToList();
                if (data != null)
                    result.Result = data;
            }
            catch (Exception ex)
            {
                result.Message = $"AsQueryable {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }
        public async Task<ResponseList<TEntity>> GetAllAsync()
        {
            var result = new ResponseList<TEntity>();
            try
            {
                var data = await _collection.AsQueryable().ToListAsync();
                if (data != null)
                    result.Result = data;
            }
            catch (Exception ex)
            {
                result.Message = $"AsQueryable {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }
        public Response<TEntity> DeleteById(string id)
        {
            var result = new Response<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = _collection.FindOneAndDelete(filter);
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"DeleteById {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
        public async Task<Response<TEntity>> DeleteByIdAsync(string id)
        {
            var result = new Response<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = await _collection.FindOneAndDeleteAsync(filter);
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"DeleteById {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
        public void DeleteMany(Expression<Func<TEntity, bool>> filter)
        {
            _collection.DeleteMany(filter);
        }
        public async Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
        {
            await _collection.DeleteManyAsync(filter);
        }
        public Response<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter)
        {
            var result = new Response<TEntity>();
            try
            {
                var deleteDocument = _collection.FindOneAndDelete(filter);
                result.Entity = deleteDocument;
            }
            catch (Exception ex)
            {
                result.Message = $"DeleteOne {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
        public async Task<Response<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = new Response<TEntity>();
            try
            {
                var deleteDocument = await _collection.FindOneAndDeleteAsync(filter);
                result.Entity = deleteDocument;
            }
            catch (Exception ex)
            {
                result.Message = $"DeleteOneAsync {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
        public ResponseList<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            var result = new ResponseList<TEntity>();
            try
            {
                var data = _collection.Find(filter).ToList();
                if (data != null)
                    result.Result = data;
            }
            catch (Exception ex)
            {
                result.Message = $"FilterBy {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }
        public async Task<ResponseList<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result = new ResponseList<TEntity>();
            try
            {
                var data = await _collection.Find(filter).ToListAsync();
                if (data != null)
                    result.Result = data;
            }
            catch (Exception ex)
            {
                result.Message = $"FilterBy {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }
        public Response<TEntity> GetById(string id, string type = "object")
        {
            var result = new Response<TEntity>();
            try
            {
                object objectId = null;
                if (type == "guid")
                    objectId = Guid.Parse(id);
                else
                    objectId = ObjectId.Parse(id);

                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = _collection.Find(filter).FirstOrDefault();
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"GetById {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
        public async Task<Response<TEntity>> GetByIdAsync(string id, string type = "object")
        {
            var result = new Response<TEntity>();
            try
            {
                object objectId = null;
                if (type == "guid")
                    objectId = Guid.Parse(id);
                else
                    objectId = ObjectId.Parse(id);

                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = await _collection.Find(filter).FirstOrDefaultAsync();
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"GetById {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
        public ResponseList<TEntity> InsertMany(ICollection<TEntity> entities)
        {
            var result = new ResponseList<TEntity>();
            try
            {
                _collection.InsertMany(entities);
                result.Result = entities;
            }
            catch (Exception ex)
            {
                result.Message = $"InsertMany {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }
        public async Task<ResponseList<TEntity>> InsertManyAsync(ICollection<TEntity> entities)
        {
            var result = new ResponseList<TEntity>();
            try
            {
                await _collection.InsertManyAsync(entities);
                result.Result = entities;
            }
            catch (Exception ex)
            {
                result.Message = $"InsertManyAsync {ex.Message}";
                result.Success = false;
                result.Result = null;
            }
            return result;
        }
        public Response<TEntity> InsertOne(TEntity entity)
        {
            var result = new Response<TEntity>();
            try
            {
                _collection.InsertOne(entity);
                result.Entity = entity;
            }
            catch (Exception ex)
            {
                result.Message = $"InsertOne {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
        public async Task<Response<TEntity>> InsertOneAsync(TEntity entity)
        {
            var result = new Response<TEntity>();
            try
            {
                await _collection.InsertOneAsync(entity);
                result.Entity = entity;
            }
            catch (Exception ex)
            {
                result.Message = $"InsertOneAsync {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
        public Response<TEntity> ReplaceOne(TEntity entity, string id, string type = "object")
        {
            var result = new Response<TEntity>();
            try
            {
                object objectId = null;
                if (type == "guid")
                    objectId = Guid.Parse(id);
                else
                    objectId = ObjectId.Parse(id);

                if (typeof(TEntity) == typeof(MongoBaseModel))
                {
                    entity.UpdateDate = DateTime.Now;
                }

                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var updatedDocument = _collection.ReplaceOne(filter, entity);
                result.Entity = entity;
            }
            catch (Exception ex)
            {
                result.Message = $"GetById {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
        public async Task<Response<TEntity>> ReplaceOneAsync(TEntity entity, string id, string type = "object")
        {
            var result = new Response<TEntity>();
            try
            {
                object objectId = null;
                if (type == "guid")
                    objectId = Guid.Parse(id);
                else
                    objectId = ObjectId.Parse(id);

                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var updatedDocument = await _collection.ReplaceOneAsync(filter, entity);
                result.Entity = entity;
            }
            catch (Exception ex)
            {
                result.Message = $"GetById {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }
    }
}
