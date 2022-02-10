using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MudBlazor.Services;
using NBG.Visitor.Domain;
using NBG.Visitor.Services.DB;
using System.Threading.Tasks;

namespace NBG.Visitor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Settings

            var oidcOptions = new OpenIdConnectOptions();
            Configuration.GetSection("Oidc").Bind(oidcOptions);
            services.AddSingleton(oidcOptions);

            #endregion Settings

            #region Authentication

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                }).AddCookie(options =>
                {
                    options.LoginPath = "/nbgSignIn";
                    options.LogoutPath = "/nbgSignOut";
                })
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.Authority = oidcOptions.Authority;
                    options.ClientId = oidcOptions.ClientId;
                    options.ClientSecret = oidcOptions.ClientSecret;
                    options.ResponseType = oidcOptions.ResponseType;
                    options.SaveTokens = oidcOptions.SaveTokens;
                    options.UsePkce = oidcOptions.UsePkce;
                    options.GetClaimsFromUserInfoEndpoint = oidcOptions.GetClaimsFromUserInfoEndpoint;
                    options.CorrelationCookie.SameSite = SameSiteMode.None;
                    options.ClaimActions.MapUniqueJsonKey("role", "role");

                    options.Scope.Clear();
                    foreach (var scope in oidcOptions.Scope)
                    {
                        options.Scope.Add(scope);
                    }
                    options.TokenValidationParameters = new TokenValidationParameters { NameClaimType = "name", RoleClaimType = "role", ValidateIssuer = true };

                    options.Events = new OpenIdConnectEvents
                    {
                        OnAccessDenied = context =>
                        {
                            context.HandleResponse();
                            context.Response.Redirect("/");
                            return Task.CompletedTask;
                        }
                    };
                });

            #endregion Authentication

            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizePage("/visitors");
            });
            services.AddServerSideBlazor();
            services.AddSingleton<IVisitService, VisitService>();
            services.AddMudServices();

            services.AddDbContextFactory<VisitContext>(options =>
                options.UseNpgsql("Host=nbg.ftp.sh;Database=nbg;Username=nbg;Password=nbg1234"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
