using System.Collections.Generic;

namespace ZoDream.Business.Cache
{
    public interface IBaseCache<T> where T : class
    {
        T GetCache(string idKey);
        void UpdateCache(string idKey);
        void UpdateCache(List<string> idKeys);
    }
}