﻿using ZoDream.Business.Base_SysManage;
using ZoDream.Entity.Base_SysManage;
using ZoDream.Util;
using System;
using System.Threading.Tasks;

namespace ZoDream.Business.Common
{
    static public class BusHelper
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logContent">日志内容</param>
        /// <param name="logType">日志类型</param>
        public static void WriteSysLog(string logContent, EnumType.LogType logType)
        {
            string userName = null;
            try
            {
                userName = Base_UserBusiness.GetCurrentUser().UserName;
            }
            catch
            {

            }
            Base_SysLog newLog = new Base_SysLog
            {
                Id = Guid.NewGuid().ToSequentialGuid(),
                LogType = logType.ToString(),
                LogContent = logContent.Replace("\r\n", "<br />").Replace("  ", "&nbsp;&nbsp;"),
                OpTime = DateTime.Now.ToCstTime(),
                OpUserName = userName
            };
            Task.Run(() =>
            {
                try
                {
                    LoggerFactory.GetLogger().WriteSysLog(newLog);
                }
                catch
                {

                }
            });
        }

        /// <summary>
        /// 处理系统异常
        /// </summary>
        /// <param name="ex">异常对象</param>
        public static void HandleException(Exception ex)
        {
            string msg = ExceptionHelper.GetExceptionAllMsg(ex);
            WriteSysLog(msg, EnumType.LogType.系统异常);
        }
    }
}