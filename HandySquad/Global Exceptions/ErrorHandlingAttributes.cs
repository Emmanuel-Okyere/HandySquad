using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HandySquad.Global_Exceptions;

public class ErrorHandlingAttributes : ExceptionFilterAttribute
{
    
    public override void OnException(ExceptionContext context)
    {
        //violated srp
        if (context.Exception is NotFoundException)
        {
            context.Result = new NotFoundObjectResult(new
            {
                StatusCode = 404,
                Message = "Resource not found."
            });
            context.ExceptionHandled = true;
        }
        else if (context.Exception is BadRequestException)
        {
            context.Result = new BadRequestObjectResult(new
            {
                StatusCode = 400,
                Message = "Bad request."
            });
            context.ExceptionHandled = true;
        }
        else if (context.Exception is DuplicateException)
        {
            context.Result = new ConflictObjectResult(new
            {
                StatusCode = 409,
                Message = "Resource already exists."
            });
            context.ExceptionHandled = true;
        }
    }
}

