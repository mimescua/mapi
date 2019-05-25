using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using GraphQL.Schema;
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
            services.AddScoped<GeoRepository>();

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<mapiQuery>();
            services.AddScoped<FeatureCollectionType>();
            services.AddScoped<FeaturesType>();
            services.AddScoped<CalleGeometryType>();
            services.AddScoped<CallePropertyType>();
            services.AddScoped<LoteGeometryType>();
            services.AddScoped<LotePropertyType>();
            services.AddScoped<ManzanaGeometryType>();
            services.AddScoped<ManzanaPropertyType>();
            services.AddScoped<ParcelaGeometryType>();
            services.AddScoped<ParcelaPropertyType>();
            services.AddScoped<PuebloGeometryType>();
            services.AddScoped<PuebloPropertyType>();
            services.AddScoped<UnidadTGeometryType>();
            services.AddScoped<UnidadTPropertyType>();

            services.AddScoped<mapiSchema>();

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, OracleDbContext dbContext/*IHostingEnvironment env*/)
        {
            app.UseGraphQL<mapiSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            dbContext.Seed();
        }
    }
}
