﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NewsServiceApi.DAL.Repositories;
using NewsServiceApi.DAL.Repositories.Categories;
using NewsServiceApi.BL.DTO;
using NewsServiceApi.BL.Service;
using NewsServiceApi.DAL.Models;
using AutoMapper;

namespace NewsServiceApi
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
            services.AddMvc();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddAutoMapper();
            services.AddRouting();
            
            //TODO ask how better use mapper

            /*
            var configMapper = new AutoMapper.MapperConfiguration(cfg => { cfg.CreateMap<News, NewsDTO>(); });
            var mapper = configMapper.CreateMapper();*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
