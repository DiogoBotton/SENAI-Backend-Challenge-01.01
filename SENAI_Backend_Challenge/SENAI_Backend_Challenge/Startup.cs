using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SENAI_Backend_Challenge.Contexts;
using SENAI_Backend_Challenge.Domains.Event.Interfaces;
using SENAI_Backend_Challenge.Domains.User.Interfaces;
using SENAI_Backend_Challenge.Repositories.EventRepository;
using SENAI_Backend_Challenge.Repositories.UserRepository;

namespace SENAI_Backend_Challenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<SenaiContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();

            // Configurando Autenticação via JWT Bearer
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //Quem esta solicitando
                    ValidateIssuer = true,

                    //Quem esta recebendo
                    ValidateAudience = true,

                    //Valida o tempo de expiração do token
                    ValidateLifetime = true,

                    //Forma da criptografia
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai_backend_challenges-key-auth")),

                    //Tempo de expiração do token
                    ClockSkew = TimeSpan.FromMinutes(30),

                    // Nome da issuer, de onde está vindo
                    ValidIssuer = "SENAI_Backend_Challenge",

                    // Nome da audience, de onde está vindo
                    ValidAudience = "SENAI_Backend_Challenge"
                };
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
