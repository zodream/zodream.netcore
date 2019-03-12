using Autofac;

namespace ZoDream.Util
{
    public class AutofacHelper
    {
        public static IContainer Container { get; set; }

        public static T GetService<T>()
        {
            return (T)Container?.Resolve(typeof(T));
        }
    }
}
