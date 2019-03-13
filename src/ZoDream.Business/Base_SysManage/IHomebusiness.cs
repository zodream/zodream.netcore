using ZoDream.Util;

namespace ZoDream.Business.Base_SysManage
{
    public interface IHomebusiness
    {
        JsonResponse SubmitLogin(string userName, string password);
    }
}