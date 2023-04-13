using Common.Email;
using Model.Common;
using Model.Mark;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// FreeSQL实例工厂
    /// </summary>
    public static class FreeSQLFactory
    {
        /// <summary>
        /// freeSql对象
        /// </summary>
        public static IFreeSql freeSql { get; set; }

        /// <summary>
        /// 获取数据库Connection连接
        /// </summary>
        /// <returns></returns>
        private static string GetCon()
        {
           #if DEBUG
            Console.WriteLine("Debug模式！userName：Mark");
            return @"user id=Mark;password=123456; data source=//127.0.0.1:1521/ORCL;Pooling=true;Min Pool Size=1";
           #else
            Console.WriteLine("Release模式！userName：ZX");
            return @"user id=ZX;password=123456; data source=//127.0.0.1:1521/ORCL;Pooling=true;Min Pool Size=1";
           #endif
        }

        /// <summary>
        /// 创建FreeSql对象
        /// </summary>
        public static void CreateFreeSQL()
        {
            freeSql = new FreeSql.FreeSqlBuilder()
                    .UseConnectionString(FreeSql.DataType.Oracle, GetCon())
                    .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}"))//监听SQL语句
					//.UseAutoSyncStructure(true) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
				    //.UseSlave("connectionString1", "connectionString2") //使用从数据库，支持多个
					.Build();
            Console.WriteLine("创建FreeSQL对象成功！");

			//读【从库】（默认）
			//freeSql.Select<T>().Where(a => a.Id == 1).ToOne();

			//强制读【主库】
			//freeSql.Select<T>().Master().WhereId(a => a.Id == 1).ToOne(); 

			//AOP：面向切面编程(Aspect Oriented Programming) 通过预编译方式和运行期间动态代理实现程序功能的统一维护的一种技术。AOP是OOP的延续
			//CurdBefore 在sql执行前触发，常用于记录日志或开发调试
			freeSql.Aop.CurdBefore += (o, e) =>
            {

            };
            //如果一个sql耗时很高，没有相关审计功能，不好排查，可以使用 CurdAfter(在sql执行完后触发) 事件即可对全局起到作用
            freeSql.Aop.CurdAfter += (o, e) =>
            {
				Console.WriteLine($"ManagedThreadId:{Thread.CurrentThread.ManagedThreadId};" +
                $" FullName:{e.EntityType.FullName} ElapsedMilliseconds:{e.ElapsedMilliseconds}ms, {e.Sql}");
				if (e.ElapsedMilliseconds > 2000)
				{
                    //记录日志
                    Console.WriteLine("记录日志：SQL执行时间大于两秒");
                    //发送短信给负责人
                    Console.WriteLine("发送邮件！");

                    EmailHelper.SendEmail($"报警信息:ManagedThreadId:{Thread.CurrentThread.ManagedThreadId};" +
				$" FullName:{e.EntityType.FullName} ElapsedMilliseconds:{e.ElapsedMilliseconds}ms, {e.Sql}");
				}
			};
        }

        /// <summary>
        /// 自动同步实体结构到数据库
        /// 需将实体类(DisableSyncStructure = true)改为false
        /// </summary>
        public static void SetCodeFirst()
        {
            freeSql.CodeFirst.SyncStructure(typeof(TEFDEMO));
        }
    }
}
