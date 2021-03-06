﻿using B03.EE.BlanckeK.Api.Repositories;
using B03.EE.BlanckeK.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace B03.EE.BlanckeK.Api
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

            var config = new AutoMapper.MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new AutoMapperConfiguration());
            });
            var mapper = config.CreateMapper();

            services.AddCors();
            services.AddSingleton(mapper);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<QuizContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("QuizService")));
            services.AddScoped<QuestionRepository>();
            services.AddScoped<AnswerRepository>();
            services.AddScoped<QuizRepository>();
            services.AddScoped<UserRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
