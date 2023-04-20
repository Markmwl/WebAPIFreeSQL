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
            //        .UseMonitorCommand(cmd => Console.WriteLine($"Sql��{cmd.CommandText}"))//����SQL���
            //        .UseAutoSyncStructure(true) //�Զ�ͬ��ʵ��ṹ�����ݿ⣬FreeSql����ɨ����򼯣�ֻ��CRUDʱ�Ż����ɱ�
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

            // ע�����Nacos
            builder.Services.AddNacosAspNet(builder.Configuration, section: "Nacos");
            // �����������
            builder.Configuration.AddNacosV2Configuration(builder.Configuration.GetSection("Nacos"));

            var app = builder.Build();

            ////����Ŀ����ʱ���������л�ȡIFreeSqlʵ������ִ��һЩ������ͬ������������,FluentAPI��
            //using (IServiceScope serviceScope = app.Services.CreateScope())
            //{
            //    var fsql = serviceScope.ServiceProvider.GetRequiredService<IFreeSql>();
            //    //�Զ�ͬ��ʵ��ṹ�����ݿ⣬���������м��ʵ����Ƿ���ڣ�Ȼ��Ǩ��ִ�д������޸�.�˹���Ĭ��Ϊ����״̬��������ʽ���������޸Ĵ�����
            //    //fsql.CodeFirst.IsAutoSyncStructure = true;
            //    //ע�⣺ֻ�е� CURD ���˱�ʱ���Ż��Զ����ɱ�ṹ������ϵͳ����ʱǨ�Ʊ�ṹ����ʹ��SyncStructure����
            //    fsql.CodeFirst.SyncStructure(typeof(TEFDEMO));//TEFDEMO ΪҪͬ����ʵ����
            //    //fsql.CodeFirst.SyncStructure(typeof(�û���));//�轫ʵ����(DisableSyncStructure = true)��Ϊfalse
            //}

            // ����FreeSQL����
            FreeSQLFactory.CreateFreeSQL(app.Configuration.GetSection("DataSource").Get<DataSourceProperty>());

            //����Smtp�ʼ�������
            ServerEmail.smtpEmail = app.Configuration.GetSection("Email").Get<SmtpEmail>();
            Console.WriteLine("�ʼ����������óɹ���");

            if (app.Environment.EnvironmentName == "dev")
            {
                Console.WriteLine("��ǰ����������������");
                //����Ŀ����ʱ���������л�ȡIFreeSqlʵ������ִ��һЩ������ͬ������������,FluentAPI��
                FreeSQLFactory.SetCodeFirst();
            }
            else if (app.Environment.EnvironmentName == "test")
            {
                Console.WriteLine("��ǰ���������Ի�����");
            }
            else if (app.Environment.EnvironmentName == "prod")
            {
                Console.WriteLine("��ǰ����������������");
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}