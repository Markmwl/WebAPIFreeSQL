using Model.Common;
using Nacos.AspNetCore.V2;
using Service;

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
                //var xmlPath = Path.Combine(basePah, Process.GetCurrentProcess().ProcessName + ".XML");//"WebAPIFreeSQL.XML"
                var xmlPath = Path.Combine(basePah, "WebAPIFreeSQL.xml");//"WebAPIFreeSQL.XML"
                Console.WriteLine(xmlPath);
                var xmlPathModel = Path.Combine(basePah, "Model.xml");
                Console.WriteLine(xmlPathModel);
                o.IncludeXmlComments(xmlPath);
                o.IncludeXmlComments(xmlPathModel);
            });

            // 注册服务到Nacos
            builder.Services.AddNacosAspNet(builder.Configuration, section: "Nacos");
            // 添加配置中心
            builder.Configuration.AddNacosV2Configuration(builder.Configuration.GetSection("Nacos"));

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
            FreeSQLFactory.CreateFreeSQL(app.Configuration.GetSection("DataSource").Get<DataSourceProperty>());

            //配置Smtp邮件服务器
            ServerEmail.smtpEmail = app.Configuration.GetSection("Email").Get<SmtpEmail>();
            Console.WriteLine("邮件服务器配置成功！");

            if (app.Environment.EnvironmentName == "dev")
            {
                Console.WriteLine("当前环境：开发环境！");
                //在项目启动时，从容器中获取IFreeSql实例，并执行一些操作：同步表，种子数据,FluentAPI等
                FreeSQLFactory.SetCodeFirst();
            }
            else if (app.Environment.EnvironmentName == "test")
            {
                Console.WriteLine("当前环境：测试环境！");
            }
            else if (app.Environment.EnvironmentName == "prod")
            {
                Console.WriteLine("当前环境：生产环境！");
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}