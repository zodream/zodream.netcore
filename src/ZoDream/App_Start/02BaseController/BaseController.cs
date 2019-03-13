using ZoDream.Business.Common;
using ZoDream.Entity.Base_SysManage;
using ZoDream.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Text;

namespace ZoDream.Web
{
    /// <summary>
    /// Mvc基控制器
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 执行前调用
        /// </summary>
        /// <param name="context">请求上下文</param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            //参数映射：支持application/json
            var actionParameters = context.ActionDescriptor.Parameters;
            var allParamters = HttpHelper.GetAllRequestParams(context.HttpContext);
            var actionArguments = context.ActionArguments;
            actionParameters.ForEach(aParamter =>
            {
                string key = aParamter.Name;
                if (allParamters.ContainsKey(key))
                {
                    actionArguments[key] = allParamters[key]?.ToString()?.ChangeType(aParamter.ParameterType);
                }
                else
                {
                    actionArguments[key] = allParamters.ToJson().ToObject(aParamter.ParameterType);
                }
            });
        }

        /// <summary>
        /// 在调用操作方法后调用
        /// </summary>
        /// <param name="filterContext">请求上下文</param>
        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        //    context.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");
        //    context.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE");
        //}

        /// <summary>
        /// 默认返回JSON
        /// </summary>
        /// <param name="content">JSON字符串</param>
        /// <returns></returns>
        public ContentResult Json(string content)
        {
            return base.Content(content, "application/json", Encoding.UTF8);
        }

        public ContentResult Json(JsonResponse content)
        {
            return Json(content.ToJson());
        }
        /// <summary>
        /// 成功请求
        /// </summary>
        /// <returns></returns>
        public ContentResult JsonSuccess()
        {
            return Json(new JsonResponse());
        }
        /// <summary>
        /// 
        /// 成功请求
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ContentResult JsonSuccess(object data)
        {
            return Json(new JsonResponse(data));
        }
        /// <summary>
        /// 成功请求
        /// </summary>
        /// <param name="data"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public ContentResult JsonSuccess(object data, object messages)
        {
            return Json(new JsonResponse(data, messages));
        }
        /// <summary>
        /// 失败请求
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public ContentResult JsonFailure(object errors)
        {
            return Json(new JsonResponse(400, errors));
        }

        /// <summary>
        /// 失败请求
        /// </summary>
        /// <param name="code">不允许设为200</param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public ContentResult JsonFailure(int code, object errors)
        {
            if (code == 200)
            {
                code = 400;
            }
            return Json(new JsonResponse(code, errors));
        }

        /// <summary>
        /// 当前URL是否包含某字符串
        /// 注：忽略大小写
        /// </summary>
        /// <param name="subUrl">包含的字符串</param>
        /// <returns></returns>
        public bool UrlContains(string subUrl)
        {
            return Request.Path.ToString().ToLower().Contains(subUrl.ToLower());
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logContent">日志内容</param>
        /// <param name="logType">日志类型</param>
        public static void WriteSysLog(string logContent, EnumType.LogType logType)
        {
            BusHelper.WriteSysLog(logContent, logType);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logContent">日志内容</param>
        public void WriteSysLog(string logContent)
        {
            WriteSysLog(logContent, LogType);
        }

        /// <summary>
        /// 日志类型
        /// 注：可通过具体控制器重写
        /// </summary>
        public virtual EnumType.LogType LogType
        {
            get
            {
                throw new Exception("请在子类重写日志类型");
            }
        }
    }
}