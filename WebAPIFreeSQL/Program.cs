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
                var xmlPath = Path.Combine(basePah, Process.GetCurrentProcess().ProcessName + ".XML");//"WebAPIFreeSQL.XML"
                Console.WriteLine(xmlPath);
                var xmlPathModel = Path.Combine(basePah, "Model.XML");
                Console.WriteLine(xmlPathModel);
                o.IncludeXmlComments(xmlPath);
                o.IncludeXmlComments(xmlPathModel);
            });

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
            FreeSQLFactory.CreateFreeSQL();

            // Configure the HTTP request pipeline.
            //���ڵ��Թ�����(vs�п�������)ִ�еĴ��루��debug��release�޹أ���������ģʽ�����д�������ʹ�� #if DEBUG #else #endif��
            if (app.Environment.IsDevelopment())
            {
                //����Ŀ����ʱ���������л�ȡIFreeSqlʵ������ִ��һЩ������ͬ������������,FluentAPI��
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