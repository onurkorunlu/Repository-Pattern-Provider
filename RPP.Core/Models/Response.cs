using System.Collections.Generic;

namespace RPP.Core.Models
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class Response<TEntity> : BaseResponse where TEntity : BaseModel, new()
    {
        public TEntity Entity { get; set; }
    }
    public class ResponseList<TEntity> : BaseResponse where TEntity : BaseModel, new()
    {
        public IEnumerable<TEntity> Result { get; set; }
    }
}
