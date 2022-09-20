using System;
using System.IO;
using System.Reflection;
using Autofac;

namespace Swift.BBS.Extension
{
    public class AutofacModuleRegister:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            #region 第一种方式

            // //配置服务和仓储的 依赖注入
            // builder.RegisterType<ArticleService>().As<IAriticleService>();
            // //注入泛型使用RegisterGeneric
            // builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();


            //注册job

            #endregion




            #region 第二种方式

            // var assemblysServices = Assembly.Load("Demo.BBS.Services");//要记得!!!这个注入的是实现类层，不是接口层！不是 IServices
            // builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();//指定已扫描程序集中的类型注册为提供所有其实现的接口。
            // var assemblysRepository = Assembly.Load("Demo.BBS.Repoitories");//模式是 Load(解决方案名)
            // builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();

            #endregion


            #region 第三种方式
            var basePath = AppContext.BaseDirectory;
            var servicesDllFile = Path.Combine(basePath, "Swift.BBS.Services.dll");
            var repositoryDllFile = Path.Combine(basePath, "Swift.BBS.Repositories.dll");
            if (!(File.Exists(servicesDllFile) && File.Exists(repositoryDllFile)))
            {
                var msg = "Repositories.dll和Services.dll 丢失。";
                throw new Exception(msg);
            }
            var assemblysServices = Assembly.LoadFrom(servicesDllFile);
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();
            
            var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
            

            #endregion
          

            
        }
    
    }
}