using AutoMapper;
using FlyLolo.JWT;
using FlyLolo.JWT.API.Authorize;
using GrowthDiary.Common;
using GrowthDiary.IRepository;
using GrowthDiary.IService;
using GrowthDiary.Repository;
using GrowthDiary.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
            services.AddHttpClient();

            // ע�� Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.Configure<WXOptions>("WXOptions", Configuration.GetSection("WX"));
            #region ��ȡ������Ϣ
            services.AddSingleton<ITokenHelper, TokenHelper>();
            services.Configure<JWTConfig>(Configuration.GetSection("JWT"));
            JWTConfig config = new JWTConfig();
            Configuration.GetSection("JWT").Bind(config);
            #endregion


            #region ����JWT��֤
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
            AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = config.Issuer,
                    ValidAudience = config.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.IssuerSigningKey)),
                    //ClockSkew = TimeSpan.FromMinutes(5)
                };
                //ͨ��TokenValidationParameters�Ĺ��췽���鿴������Ĭ��ֵ���£�
                //public TokenValidationParameters()
                //{
                //    RequireExpirationTime = true;
                //    RequireSignedTokens = true;
                //    SaveSigninToken = false;
                //    ValidateActor = false;
                //    ValidateAudience = true;
                //    ValidateIssuer = true;
                //    ValidateIssuerSigningKey = false;
                //    ValidateLifetime = true;
                //    ValidateTokenReplay = false;
                //}
                //DefaultClockSkew = TimeSpan.FromSeconds(300); //��ClockSkew��Ĭ��ֵΪ5����
            });
            #endregion

            #region �Զ�����Ȩ
            services.AddAuthorization(options => options.AddPolicy("Permission", policy => policy.Requirements.Add(new PermissionRequirement())));
            services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            #endregion

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddSingleton<IUserService,UserService>();
            services.AddSingleton<IRecordService,RecordService>();
            services.AddSingleton<IRecordRepository, RecordRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<MongoHelper, MongoHelper>();
            services.AddSingleton<ITokenHelper, TokenHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // ����Swagger�м��
            app.UseSwagger();

            // ����SwaggerUI�м��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
