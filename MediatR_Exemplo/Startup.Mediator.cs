using MediatR;
using MediatR_Exemplo.Core.RequestHandlers;
using MediatR_Exemplo.Core.Validators;
using MediatR_Exemplo.Core.Validators.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using FluentValidation.AspNetCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR_Exemplo
{
    public partial class Startup
    {
        private void ConfigureMediator(IServiceCollection services) 
        {
            var mediatorImplementations = new Type[]
            {
                typeof(CreateUserRequestHandler),
            };

            services.AddMediatR(mediatorImplementations, config =>
            {
                config.Using<Mediator>().AsScoped();
            });
        }
        private void ConfigureValidators(IServiceCollection services)
        {
            var transientValidators = new Type[]
            {
                typeof(CreateUserRequestValidator)
            };

            services.AddMvcCore()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateUserRequestValidator>(filter: scan => transientValidators.Contains(scan.ValidatorType), lifetime: ServiceLifetime.Singleton));
        }
    }
}
