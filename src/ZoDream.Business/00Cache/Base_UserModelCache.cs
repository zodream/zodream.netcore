using ZoDream.Business.Base_SysManage;
using ZoDream.Util;
using System.Linq;

namespace ZoDream.Business.Cache
{
    public class Base_UserModelCache : BaseCache<Base_UserModel>
    {
        public Base_UserModelCache()
            : base("Base_UserModel", userId =>
            {
                if (userId.IsNullOrEmpty())
                    return null;
                return new Base_UserBusiness().GetDataList("UserId", userId, new Pagination()).FirstOrDefault();
            })
        {

        }
    }
}
