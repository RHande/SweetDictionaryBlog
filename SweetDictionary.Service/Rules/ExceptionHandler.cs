using Core.Entities;
using Core.Exceptions;

namespace SweetDictionary.Service.Rules;

public static class ExceptionHandler<T>
{
    public static ReturnModel<T> HandleException(Exception ex)
    {
        if (ex.GetType() == typeof(NotFoundException))
        {
            return new ReturnModel<T>
            {
                Message = ex.Message,
                Status = 404,
                Success = false
            };
        }

        if (ex.GetType() == typeof(BusinessException))
        {
            return new ReturnModel<T>
            {
                Message = ex.Message,
                Status = 400,
                Success = false
            };
        }
        
        return new ReturnModel<T>
        {
            Message = ex.Message,
            Status = 500,
            Success = false
        };
        
    }
}