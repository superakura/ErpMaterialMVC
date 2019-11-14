using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ErpMaterialMVC.Common
{
    public static class ReflectionHelper
    {
        /// <summary>
        ///  获取Asp.Net FrameWork项目所有程序集
        /// </summary>
        /// <returns></returns>
        public static Assembly[] GetAllAssemblies()
        {
            //1.获取当前程序集(Ray.EssayNotes.AutoFac.Infrastructure.Ioc)所有引用程序集
            Assembly executingAssembly = Assembly.GetExecutingAssembly();//当前程序集
            List<Assembly> assemblies = executingAssembly.GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Where(m => m.FullName.Contains("ErpMaterialMVC"))
                .ToList();
            //2.获取程序启动入口程序集（比如Ray.EssayNotes.AutoFac.ConsoleApp）
            Assembly assembly = Assembly.GetEntryAssembly();
            assemblies.Add(assembly);
            return assemblies.ToArray();
        }

        /// <summary>
        ///  获取Asp.Net FrameWork Web项目所有程序集
        /// </summary>
        /// <returns></returns>
        public static Assembly[] GetAllAssembliesWeb()
        {
            Assembly[] assemblies = System.Web.Compilation.BuildManager
                .GetReferencedAssemblies()
                .Cast<Assembly>()
                .Where(x => x.FullName.Contains("ErpMaterialMVC"))
                .ToArray();
            return assemblies;
        }
    }
}
