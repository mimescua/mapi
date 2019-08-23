using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using GraphQL.Schema;
using GraphQL.Schema.InputTypes;
using GraphQL.Schema.Types;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GraphQL.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OracleDbContext>(options => options.UseOracle(Configuration["ConnectionStrings:OracleConnection"]));
            services.AddDbContext<SecurityDbContext>(options => options.UseOracle(Configuration["ConnectionStrings:SecurityConnection"]));
            services.AddScoped<ReadRepository>();
            services.AddScoped<AddRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<mapiSchema>();
            services.AddScoped<mapiQuery>();
            services.AddScoped<mapiMutation>();

            services.AddScoped<FeaturesType>();
            services.AddScoped<FeaturesInscritosType>();
            services.AddScoped<FeaturesMatrizType>();
            services.AddScoped<FeaturesTematicoType>();

            services.AddScoped<CalleGeometryType>();
            services.AddScoped<CallePropertyType>();
            services.AddScoped<LoteGeometryType>();
            services.AddScoped<LotePropertyType>();
            services.AddScoped<ManzanaGeometryType>();
            services.AddScoped<ManzanaPropertyType>();
            services.AddScoped<PuebloGeometryType>();
            services.AddScoped<PuebloPropertyType>();
            services.AddScoped<UnidadTGeometryType>();
            services.AddScoped<UnidadTPropertyType>();

            services.AddScoped<InscritoCalleGeometryType>();
            services.AddScoped<InscritoCallePropertyType>();
            services.AddScoped<InscritoLoteGeometryType>();
            services.AddScoped<InscritoLotePropertyType>();
            services.AddScoped<InscritoManzanaGeometryType>();
            services.AddScoped<InscritoManzanaPropertyType>();
            services.AddScoped<InscritoPuebloGeometryType>();
            services.AddScoped<InscritoPuebloPropertyType>();

            services.AddScoped<MatrizPuebloGeometryType>();
            services.AddScoped<MatrizPuebloPropertyType>();

            services.AddScoped<CentroidePuebloGeometryType>();
            services.AddScoped<CentroidePuebloPropertyType>();
            services.AddScoped<CentroideInscritoPuebloGeometryType>();
            services.AddScoped<CentroideInscritoPuebloPropertyType>();

            services.AddScoped<baseDistritoGeometryType>();
            services.AddScoped<baseProvinciaGeometryType>();
            services.AddScoped<baseRegionGeometryType>();

            services.AddScoped<PuebloUbicacionType>();

            services.AddScoped<UnidadTInputType>();
            services.AddScoped<UnidadTType>();
            
            services.AddScoped<CentroideType>();

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader()
                ;//.addWebSockets();//Persisten comunication for fast conexions

            services.AddCors();//falta configurar para restringir a solo algunas url's
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, OracleDbContext dbContext/*IHostingEnvironment env*/)
        {
            app.UseCors(builder =>
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseGraphQL<mapiSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            dbContext.Seed();
        }
    }
}
