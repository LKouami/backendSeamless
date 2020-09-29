using Seamless.API.Helpers;
using Seamless.API.PipelineBehaviors;
using Seamless.Data.IRepositories;
using Seamless.Data.Repositories;
using Seamless.Model;
using Seamless.Domain.Dxos;
using Seamless.Service.Services.Helpers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using Seamless.Model.Models;

namespace Seamless.API.App_Start
{
    public static class Dependencies_Start
    {

        /// <summary>
        /// Resolve all the dependencies in the application
        /// </summary>
        /// <param name="services"></param>
        /// <param name="Configuration"></param>
        public static void ResolveDepenciesServices(this IServiceCollection services, IConfiguration Configuration)
        {
            // //Sql server 
            // //master database
            // services.AddDbContext<Seamless_Master_DbContext>(options =>
            // {
            //     options.UseSqlServer(Configuration.GetConnectionString("MasterConnection"),
            //         sqlOptions =>
            //         {
            //             sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30),
            //                 errorNumbersToAdd: null);
            //         });
            // });

            //Add connection string based on the tenant. Pick the tenantid in the header
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<SeamlessContext>((serviceProvider, options) =>
            {
                var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
                var httpRequest = httpContext.Request;
                var connection = GetConnection(httpRequest, Configuration);
                options.UseSqlServer(connection, sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });
            });




            //Add DIs



            //User
            services.AddScoped<ITokenHelper, TokenHelper>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserDxos, UserDxos>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleDxos, RoleDxos>();
            
            services.AddScoped<IAppParameterRepository, AppParameterRepository>();
            services.AddScoped<IAppParameterDxos, AppParameterDxos>();
            
            services.AddScoped< IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IAssignmentDxos, AssignmentDxos>();

            services.AddScoped<IActivityLogRepository, ActivityLogRepository>();
            services.AddScoped<IActivityLogDxos, ActivityLogDxos>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryDxos, CategoryDxos>();

            services.AddScoped<IFaqRepository, FaqRepository>();
            services.AddScoped<IFaqDxos, FaqDxos>();

            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageDxos, MessageDxos>();

            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<INoteDxos, NoteDxos>();

            services.AddScoped<INoteTypeRepository, NoteTypeRepository>();
            services.AddScoped<INoteTypeDxos, NoteTypeDxos>();

            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionDxos, PermissionDxos>();

            services.AddScoped<IPriorityRepository, PriorityRepository>();
            services.AddScoped<IPriorityDxos, PriorityDxos>();

            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketDxos, TicketDxos>();

            services.AddScoped<ITicketFieldRepository, TicketFieldRepository>();
            services.AddScoped<ITicketFieldDxos, TicketFieldDxos>();

            services.AddScoped<ITicketStatusRepository, TicketStatusRepository>();
            services.AddScoped<ITicketStatusDxos, TicketStatusDxos>();


            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        }

        private static string GetConnection(HttpRequest httpRequest, IConfiguration Configuration)
        {
            string tenantId = httpRequest.Headers["TenantId"].ToString();

            Console.WriteLine($"TenantId: {tenantId}");

            if (!string.IsNullOrWhiteSpace(tenantId))
            {
                return Configuration.GetConnectionString("DefaultConnection").Replace("{TenantId}", tenantId);
            }
            else
            {
                return Configuration.GetConnectionString("DefaultConnection").Replace("_{TenantId}", "");
            }


        }
    }
}
