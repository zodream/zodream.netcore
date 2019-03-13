using ZoDream.Business.Common;
using ZoDream.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ZoDream.Web
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            BusHelper.HandleException(ex);

            context.Result = new ContentResult { Content = new JsonResponse(400, ex.Message).ToJson() };
        }
    }
}
