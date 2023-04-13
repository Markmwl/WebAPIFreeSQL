using FreeSql;
using Model.Mark;
using Service;

namespace AdminLTE
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// 创建FreeSQL对象
			FreeSQLFactory.CreateFreeSQL();

			Func<IServiceProvider, IFreeSql> fsqlFactory = r =>
			{
				return FreeSQLFactory.freeSql;
			};
			builder.Services.AddSingleton(fsqlFactory);

			builder.Services.AddControllers();

			var app = builder.Build();

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