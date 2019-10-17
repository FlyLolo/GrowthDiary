using AutoMapper;
using FlyLolo.JWT;
using GrowthDiary.Common;
using GrowthDiary.IRepository;
using GrowthDiary.IService;
using GrowthDiary.Repository;
using GrowthDiary.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GrowthDiary
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // 注册 Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.Configure<WXOptions>("WXOptions", Configuration.GetSection("WX"));
            #region 读取配置信息
            services.AddSingleton<ITokenHelper, TokenHelper>();
            services.Configure<JWTConfig>(Configuration.GetSection("JWT"));
            JWTConfig config = new JWTConfig();
            Configuration.GetSection("JWT").Bind(config);
            #endregion

            #region 启用JWT
            services.AddAuthentication(Options =>
            {
                Options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                Options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
             AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidIssuer = config.Issuer,
                     ValidAudience = config.RefreshTokenAudience,
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.IssuerSigningKey))
                 };
             });
            #endregion

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddSingleton<IUserService,UserService>();
            services.AddSingleton<IRecordService,RecordService>();
            services.AddSingleton<IRecordRepository, RecordRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<MongoHelper, MongoHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 启用Swagger中间件
            app.UseSwagger();

            // 启用SwaggerUI中间件
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
