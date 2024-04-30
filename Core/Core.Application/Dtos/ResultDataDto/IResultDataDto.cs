
using Core.Application.Interfaces.Dtos;
using Core.Domain.Entities;

namespace Core.Application.Dtos.ResultDataDto
{
    public interface IResultDataDto<T> 
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IResultDataDto<T> SetData(T entity);
        public IResultDataDto<T> SetMessage(string message);
        public IResultDataDto<T> SetSuccess(bool success);
    }
}
