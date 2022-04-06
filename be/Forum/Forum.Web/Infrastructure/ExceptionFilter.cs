using Forum.Core;
using Forum.Core.Enums;
using Forum.Transfer.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Forum.Web.Infrastructure
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(ForumException) && context.Exception is ForumException forumException)
            {
                context.Result = new BadRequestObjectResult(new ResponseDto<object>
                {
                    Error = new ErrorDto
                    {
                        ForumErrorCode = forumException.ForumErrorCode,
                        Message = forumException.ForumErrorCode.ToString()
                    }
                });
            }
            else
            {
                context.Result = new BadRequestObjectResult(new ResponseDto<object>
                {
                    Error = new ErrorDto()
                    {
                        ForumErrorCode = ForumErrorCode.UnexpectedError,
                        Message = ForumErrorCode.UnexpectedError.ToString()
                    }
                });

            }
        }
    }
}
