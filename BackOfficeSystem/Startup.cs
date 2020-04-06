using BackOfficeSystem.BLL;
using BackOfficeSystem.DAL;
using BackOfficeSystem.Entities;
using BackOfficeSystem.Filters;
using BackOfficeSystem.Helpers;
using BackOfficeSystem.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TsvReader.Reader;

namespace BackOfficeSystem
{
	public class Startup
	{
		private const string ClientAppRootPath = "client-app";
		private readonly string ContentRootPath;

		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			ContentRootPath = env.ContentRootPath;
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var filePath = new DataFilesPathOptions();
			Configuration.GetSection("DataFilesPath").Bind(filePath);

			var brandEntityTsvPath = $"{ContentRootPath}{filePath.BrandTsv}";
			var receiptDetailsEntityTsvPath = $"{ContentRootPath}{filePath.BrandQuantityTimeReceivedTsv}";

			services.AddScoped<IBrandService, BrandService>();
			services.AddScoped<IInventoryService, InventoryService>();
			services.AddScoped<IAggregationManagerService, AggregationManagerService>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddTransient<ITsvDataReader<BrandEntity>>(x => new TsvReader<BrandEntity>(brandEntityTsvPath));
			services.AddTransient<ITsvDataReader<ReceiptDetailsEntity>>(x => new TsvReader<ReceiptDetailsEntity>(receiptDetailsEntityTsvPath));

			services.AddDbContext<BrandWarehouseDBContext>(options => 
			{
				options.UseMySQL(Configuration.GetConnectionString("localConnection"));
			});

			services.AddSwaggerDocument();
			services.AddSpaStaticFiles(options => options.RootPath = $"{ClientAppRootPath}/dist");
			services.AddMvc(options => 
			{
				options.RespectBrowserAcceptHeader = true;
				options.Filters.Add(typeof(GlobalCustomExceptonFilterAttribute));
			})
				.AddXmlSerializerFormatters()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseOpenApi();
			app.UseSwaggerUi3();

			app.UseMvc();

			app.UseSpaStaticFiles();
			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = ClientAppRootPath;
				if (env.IsDevelopment())
				{
					spa.UseVueDevelopmentServer();
				}
			});
		}
	}
}
