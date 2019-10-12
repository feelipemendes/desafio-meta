using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DesafioMeta.Presentation.Mappings;
using Swashbuckle.AspNetCore.Swagger;
using DesafioMeta.Repository.Contracts;
using DesafioMeta.Repository;

namespace DesafioMeta.Presentation
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
            //mapeamento de injeção de dependência
            services.AddTransient<IContatoRepository, ContatoRepository>
                (cfg => new ContatoRepository
                    (Configuration.GetConnectionString("projeto")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToViewModelMap());
                cfg.AddProfile(new ViewModelToEntityMap());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            //configurando o gerador de documentação
            //da api através do framework SWAGGER
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Title = "Contato",
                    Description = "API para um serviço de gestão de contatos",
                    Version = "v1",
                });
            }
            );

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

            app.UseHttpsRedirection();
            app.UseMvc();

            //registrando o swagger
            app.UseSwagger();
            app.UseSwaggerUI(
                s =>
                {
                    s.SwaggerEndpoint("/swagger/v1/swagger.json", "desafiometa");
                });
        }
    }
}
