using FreeSql;
using Model.Mark;
using Service;
using System.Data;
using System.Diagnostics;

namespace WebAPIFreeSQL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            //Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
            //{
            //    IFreeSql fsql = new FreeSql.FreeSqlBuilder()
            //        .UseConnectionString(FreeSql.DataType.Oracle, @"user id=Mark;password=123456; data source=//127.0.0.1:1521/ORCL;Pooling=true;Min Pool Size=1")
            //        .UseMonitorCommand(cmd => Console.WriteLine($"Sql：{cmd.CommandText}"))//监听SQL语句
            //        .UseAutoSyncStructure(true) //自动同步实体结构到数据库，FreeSql不会扫描程序集，只有CRUD时才会生成表。
            //        .Build();
            //    return fsql;
            //};
            //builder.Services.AddSingleton<IFreeSql>(fsqlFactory);



            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(o =>
            {
                var basePah = System.AppDomain.CurrentDomain.BaseDirectory;
                var xmlPath = Path.Combine(basePah, Process.GetCurrentProcess().ProcessName + ".XML");//"WebAPIFreeSQL.XML"
                Console.WriteLine(xmlPath);
                var xmlPathModel = Path.Combine(basePah, "Model.XML");
                Console.WriteLine(xmlPathModel);
                o.IncludeXmlComments(xmlPath);
                o.IncludeXmlComments(xmlPathModel);
            });

            var app = builder.Build();

            ////在项目启动时，从容器中获取IFreeSql实例，并执行一些操作：同步表，种子数据,FluentAPI等
            //using (IServiceScope serviceScope = app.Services.CreateScope())
            //{
            //    var fsql = serviceScope.ServiceProvider.GetRequiredService<IFreeSql>();
            //    //自动同步实体结构到数据库，程序运行中检查实体表是否存在，然后迁移执行创建或修改.此功能默认为开启状态，发布正式环境后，请修改此设置
            //    //fsql.CodeFirst.IsAutoSyncStructure = true;
            //    //注意：只有当 CURD 到此表时，才会自动生成表结构。如需系统运行时迁移表结构，请使用SyncStructure方法
            //    fsql.CodeFirst.SyncStructure(typeof(TEFDEMO));//TEFDEMO 为要同步的实体类
            //    //fsql.CodeFirst.SyncStructure(typeof(用户表));//需将实体类(DisableSyncStructure = true)改为false
            //}

            // 创建FreeSQL对象
            FreeSQLFactory.CreateFreeSQL();

            // Configure the HTTP request pipeline.
            //仅在调试过程中(vs中开启运行)执行的代码（和debug和release无关，若想在两模式中运行代码轻松使用 #if DEBUG #else #endif）
            if (app.Environment.IsDevelopment())
            {
                //在项目启动时，从容器中获取IFreeSql实例，并执行一些操作：同步表，种子数据,FluentAPI等
                FreeSQLFactory.SetCodeFirst();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}