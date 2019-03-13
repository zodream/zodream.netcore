﻿using ZoDream.Business.Base_SysManage;
using ZoDream.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZoDream.Web
{
    /// <summary>
    /// 校验用户接口权限
    /// </summary>
    public class CheckUrlPermissionAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// Action执行之前执行
        /// </summary>
        /// <param name="filterContext">过滤器上下文</param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //若为本地测试，则不需要校验
            if (GlobalSwitch.RunModel == RunModel.LocalTest)
            {
                return;
            }
            //判断是否需要校验
            List<string> attrList = FilterHelper.GetFilterList(filterContext);
            bool needCheck = attrList.Contains(typeof(CheckUrlPermissionAttribute).FullName) && !attrList.Contains(typeof(IgnoreUrlPermissionAttribute).FullName);
            if (!needCheck)
                return;

            var allUrlPermissions = UrlPermissionManage.GetAllUrlPermissions();
            string requestUrl = filterContext.HttpContext.Request.Path;
            var thePermission = allUrlPermissions.Where(x => requestUrl.Contains(x.Url.ToLower())).FirstOrDefault();
            if (thePermission == null)
                return;
            string needPermission = thePermission.PermissionValue;
            bool hasPermission = PermissionManage.GetOperatorPermissionValues().Any(x => x.ToLower() == needPermission.ToLower());
            if (hasPermission)
                return;
            else
            {
                JsonResponse res = new JsonResponse(400, "权限不足！无法访问！");
                filterContext.Result = new ContentResult { Content = res.ToJson() };
            }
        }

        /// <summary>
        /// Action执行完毕之后执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}