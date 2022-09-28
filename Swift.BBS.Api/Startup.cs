using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz.HostedService;
using Swashbuckle.AspNetCore.Filters;
using Swift.BBS.Api.Jobs;
using Swift.BBS.Common.Helper;
using Swift.BBS.Extension;
using Swift.BBS.IRepositories.Base;
using Swift.BBS.IServices;

using Swift.BBS.Repositories.Base;
using Swift.BBS.Repositories.EfContext;
using Swift.BBS.Services;

namespace Swift.BBS.Api
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
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Swift.BBS.Api", Version = "v1"});
                // 开启小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                // 在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {

                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                
                
            });
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(o => {

                
                var audienceConfig = Configuration.GetSection("Audience");
                var symmetricKeyAsBase64 = audienceConfig["Secret"];
                var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
                var signingKey = new SymmetricSecurityKey(keyByteArray);

                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidateIssuer = true,
                    ValidIssuer = audienceConfig["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = audienceConfig["Audience"],
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    RequireExpirationTime = true,
                };
            });

            
            
            services.AddSingleton(new Appsettings(Configuration));
            // services.AddSingleton<IArticleService,ArticleService>();
            // services.AddSingleton<IUserInfoService,UserInfoService>();
            Console.WriteLine("注入tex");
            services.AddSingleton<TexJob>();
         //   services.AddSingleton<TestJob>();

            Console.WriteLine("注入结束tex");

            //注入基础服务仓储
            services.AddSingleton(typeof(IBaseRepository<>),typeof(BaseRepository<>));

       
            services.AddDbContext<SwiftCodeBbsContext>(o=>o.UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=127.0.0.1;Initial Catalog=SwiftCodeBbs6;User ID=sa;Password=qwer1234..."));

            services.AddLogging();
            services.AddAutoMapperSetup();
            services.AddQuartzHostedService(Configuration);
            


        }

        // 注意在Program.CreateHostBuilder，添加Autofac服务工厂
        public void ConfigureContainer(ContainerBuilder builder){
            builder.RegisterModule<AutofacModuleRegister>();
        }
        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swift.BBS.Api v1"));
            }
            
            app.UseHttpsRedirection();
            

            app.UseRouting();
            

            app.UseAuthorization();
            
            app.UseCors(options => options
                .AllowAnyHeader()               // 确保策略允许任何标头
                .AllowAnyMethod()               // 确保策略允许任何方法
                .SetIsOriginAllowed(o => true)  // 设置指定的isOriginAllowed为基础策略
                .AllowCredentials());           // 将策略设置为允许凭据。


            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

          


        }
    }
}