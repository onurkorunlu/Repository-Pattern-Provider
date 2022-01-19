using RPP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RPP.Core.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : BaseModel, new()
    {
        ResponseList<TEntity> GetAll();
        Task<ResponseList<TEntity>> GetAllAsync();
        ResponseList<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);
        Task<ResponseList<TEntity>> FilterByAsync(Expression<Func<TEntity, bool>> filter);
        Response<TEntity> GetById(string id, string type = "object");
        Task<Response<TEntity>> GetByIdAsync(string id, string type = "object");
        Response<TEntity> InsertOne(TEntity entity);
        Task<Response<TEntity>> InsertOneAsync(TEntity entity);
        ResponseList<TEntity> InsertMany(ICollection<TEntity> entities);
        Task<ResponseList<TEntity>> InsertManyAsync(ICollection<TEntity> entities);
        Response<TEntity> ReplaceOne(TEntity entity, string id, string type = "object");
        Task<Response<TEntity>> ReplaceOneAsync(TEntity entity, string id, string type = "object");
        Response<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter);
        Task<Response<TEntity>> DeleteOneAsync(Expression<Func<TEntity, bool>> filter);
        Response<TEntity> DeleteById(string id);
        Task<Response<TEntity>> DeleteByIdAsync(string id);
        void DeleteMany(Expression<Func<TEntity, bool>> filter);
        Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter);
    }
}
