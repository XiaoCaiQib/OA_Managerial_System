using Autofac;
using Autofac.Integration.Mvc;
using log4net;
using OA_Managerial_System.BLL;
using OA_Managerial_System.IBLL;
using OA_Managerial_System.Webapp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OA_Managerial_System.Webapp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //读取log4net的配置
            log4net.Config.XmlConfigurator.Configure();
            //Autofuc依赖注入
            //创建autofac管理注册类的容器实例
            var builder = new ContainerBuilder();
            //下面就需要为这个容器注册它可以管理的类型
            //builder的Register方法可以通过多种方式注册类型,之前在控制台程序里面也演示了好几种方式了。
            builder.RegisterType<UserInfoService>().As<IUserinfoService>();
            builder.RegisterType<RoleInfoService>().As<IRoleInfoService>();
            //builder.RegisterType<DefaultController>().InstancePerDependency();
            //使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            //生成具体的实例
            var container = builder.Build();
            //下面就是使用MVC的扩展 更改了MVC中的注入方式.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            string Logfile = Server.MapPath("/Log/");
            ThreadPool.QueueUserWorkItem(a =>
            {
                while (true)
                {
                    if (MyExceptionAttribute.queue.Count() > 0)
                    {
                   Exception dequeue=MyExceptionAttribute.queue.Dequeue();
                        if (dequeue != null) {
                            //string filename = DateTime.Now.ToShortDateString();
                            //File.AppendAllText(Logfile + filename + ".txt", dequeue.ToString(), Encoding.UTF8);
                            ILog logger = LogManager.GetLogger("errormsg");
                            logger.Error(dequeue.ToString());
                        }
                        else {
                            Thread.Sleep(3000);
                        }
                    }
                    else
                    {
                        Thread.Sleep(3000);
                    }
                }
            }, Logfile);
        }
    }
}
