using FreeSql;
using Model.Common;
using Model.Mark;
using Service;

namespace AdminLTE
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
			{
				return FreeSQLFactory.freeSql;
			};
			builder.Services.AddSingleton(fsqlFactory);

			builder.Services.AddControllers();

            // 添加配置中心
            builder.Configuration.AddNacosV2Configuration(builder.Configuration.GetSection("Nacos"));

            var app = builder.Build();

            // 创建FreeSQL对象
            FreeSQLFactory.CreateFreeSQL(app.Configuration.GetSection("DataSource").Get<DataSourceProperty>());


            app.UseAuthorization();

			app.UseFreeAdminLtePreview("/",
  typeof(XXLUSER),
  typeof(TUSER),
  typeof(TRUNLOG)
);

			app.Run();
		}
	}
}