using System;
using System.Linq;
using MatchPoint.Core.Models;
using MatchPoint.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MatchPoint.WebApi
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
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                });

            services.AddDbContext<MatchPointContext>(options =>
            {
                options.UseInMemoryDatabase("MatchPoint");
            }, ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitiateDatabase(app);
        }

        private void InitiateDatabase(IApplicationBuilder app)
        {
            using (var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<MatchPointContext>())
            {
                context.Database.EnsureCreated();

                var leo = context.Players.Add(new Player
                {
                    Appellation = "Leo",
                    Registered = Convert.ToDateTime("2019-04-22"),
                });
                var nathon = context.Players.Add(new Player
                {
                    Appellation = "Nathon",
                    Registered = Convert.ToDateTime("2019-04-22"),
                });
                var hivver = context.Players.Add(new Player
                {
                    Appellation = "Hivver",
                    Registered = Convert.ToDateTime("2019-04-22"),
                });
                var frost = context.Players.Add(new Player
                {
                    Appellation = "Frost",
                    Registered = Convert.ToDateTime("2019-04-22"),
                });

                var warcraftTemplate = context.MatchTemplates.Single(t => t.TemplateId == MatchTemplate.Warcraft.TemplateId);

                context.Matches.Add(new Match
                {
                    Started = Convert.ToDateTime("2019-04-22 17:00:00"),
                    Ended = Convert.ToDateTime("2019-04-22 17:36:00"),
                    Template = warcraftTemplate,
                    Participants = new MatchParticipant[] {
                        new MatchParticipant{ Player = leo.Entity.Id, TeamNumber=0, PlayAs=3 },
                        new MatchParticipant{ Player = nathon.Entity.Id, TeamNumber=0, PlayAs=2 },
                        new MatchParticipant{ Player = hivver.Entity.Id, TeamNumber=1, PlayAs=1 },
                        new MatchParticipant{ Player = frost.Entity.Id, TeamNumber=1, PlayAs=4 },
                    },
                    TeamWon = 1
                });

                context.Matches.Add(new Match
                {
                    Started = Convert.ToDateTime("2019-04-22 17:50:00"),
                    Ended = Convert.ToDateTime("2019-04-22 18:24:00"),
                    Template = warcraftTemplate,
                    Participants = new MatchParticipant[] {
                        new MatchParticipant{ Player = leo.Entity.Id, TeamNumber=0, PlayAs=0 },
                        new MatchParticipant{ Player = nathon.Entity.Id, TeamNumber=0, PlayAs=2 },
                        new MatchParticipant{ Player = hivver.Entity.Id, TeamNumber=1, PlayAs=1 },
                        new MatchParticipant{ Player = frost.Entity.Id, TeamNumber=1, PlayAs=1 },
                    },
                    TeamWon = 1
                });

                context.Matches.Add(new Match
                {
                    Started = Convert.ToDateTime("2019-04-22 18:33:00"),
                    Ended = Convert.ToDateTime("2019-04-22 19:14:00"),
                    Template = warcraftTemplate,
                    Participants = new MatchParticipant[] {
                        new MatchParticipant{ Player = leo.Entity.Id, TeamNumber=1, PlayAs=1 },
                        new MatchParticipant{ Player = nathon.Entity.Id, TeamNumber=0, PlayAs=2 },
                        new MatchParticipant{ Player = hivver.Entity.Id, TeamNumber=0, PlayAs=1 },
                        new MatchParticipant{ Player = frost.Entity.Id, TeamNumber=1, PlayAs=2 },
                    },
                    TeamWon = 0
                });
                context.SaveChanges();
            }
        }



    }
}
