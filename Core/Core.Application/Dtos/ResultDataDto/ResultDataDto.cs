
using Core.Application.Interfaces.Dtos;
using Core.Domain.Entities;

namespace Core.Application.Dtos.ResultDataDto
{
    public class ResultDataDto<T> : IResultDataDto<T>
    {
        public Guid DataId { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }      
        public IResultDataDto<T> SetData(T entity)
        {
            this.Data = entity;
            return this;
        }
        public IResultDataDto<T> SetMessage(string message)
        {
            this.Message = message;
            return this;
        }
        public IResultDataDto<T> SetSuccess(bool success)
        {
            this.IsSuccess = success;
            return this;
        }
    }
}
