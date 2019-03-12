using ZoDream.Util;

namespace ZoDream.Business.Base_SysManage
{
    public interface IHomebusiness
    {
        AjaxResult SubmitLogin(string userName, string password);
    }
}