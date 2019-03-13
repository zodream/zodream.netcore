using ZoDream.Business.Common;
using ZoDream.Entity.Base_SysManage;
using ZoDream.Util;
using System.Linq;

namespace ZoDream.Business.Base_SysManage
{
    public class HomeBusiness : BaseBusiness<Base_User>, IHomebusiness
    {
        public JsonResponse SubmitLogin(string userName, string password)
        {
            if (userName.IsNullOrEmpty() || password.IsNullOrEmpty())
                return JsonFailure("账号或密码不能为空！");
            password = password.ToMD5String();
            var theUser = GetIQueryable().Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (theUser != null)
            {
                Operator.Login(theUser.UserId);
                return JsonSuccess();
            }
            else
                return JsonFailure("账号或密码不正确！");
        }
    }
}