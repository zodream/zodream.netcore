﻿using ZoDream.DataRepository;
using ZoDream.Entity.Base_SysManage;
using System.Collections.Generic;
using System.Linq;

namespace ZoDream.Business.Cache
{
    class UserRoleCache : BaseCache<List<string>>
    {
        public UserRoleCache()
            : base("UserRoleCache", userId =>
            {
                var list = DbFactory.GetRepository()
                    .GetIQueryable<Base_UserRoleMap>()
                    .Where(x => x.UserId == userId)
                    .Select(x => x.RoleId)
                    .ToList();
                return list;
            })
        {

        }
    }
}
