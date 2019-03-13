namespace ZoDream.Util
{
    /// <summary>
    /// Ajax请求结果
    /// </summary>
    public class JsonResponse
    {
        /// <summary>
        /// 是否成功 200 表示成功
        /// </summary>
        public int code { get; set; } = 200;

        public string status { get; set; } = "sucess";

        /// <summary>
        /// 返回消息
        /// </summary>
        public object messages { get; set; }

        public object errors { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }

        public JsonResponse() { }
        /// <summary>
        /// 成功的简单返回
        /// </summary>
        /// <param name="data"></param>
        public JsonResponse(object data)
        {
            code = 200;
            status = "success";
            this.data = data;
        }
        /// <summary>
        /// 成功的完整返回
        /// </summary>
        /// <param name="data"></param>
        /// <param name="messages"></param>
        public JsonResponse(object data, object messages)
        {
            code = 200;
            status = "success";
            this.data = data;
            this.messages = messages;
        }
        /// <summary>
        /// 失败的简单返回
        /// </summary>
        /// <param name="code"></param>
        /// <param name="errors"></param>
        public JsonResponse(int code, object messages)
        {
            this.code = code;
            if (code == 200)
            {
                status = "success";
                this.messages = messages;
            } else
            {
                status = "failure";
                this.errors = messages;
            }
            
        }

        /// <summary>
        /// 失败的完整返回
        /// </summary>
        /// <param name="code"></param>
        /// <param name="status"></param>
        /// <param name="errors"></param>
        public JsonResponse(int code, string status, object messages)
        {
            this.code = code;
            this.status = status;
            if (code == 200)
            {
                
                this.messages = messages;
            }
            else
            {
                this.errors = messages;
            }
        }

    }
}
