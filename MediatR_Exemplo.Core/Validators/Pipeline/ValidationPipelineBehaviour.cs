using FluentValidation;
using FluentValidation.Results;
using MediatR;
using MediatR_Exemplo.Shared;
using MediatR_Exemplo.Shared.Exceptions;
using MediatR_Exemplo.Shared.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediatR_Exemplo.Core.Validators.Pipeline
{
    public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IValidatable
    {
        private readonly IValidator<TRequest> _validator;
        private readonly MethodInfo _operationResultError;
        private readonly Type _type = typeof(TResponse);
        private readonly Type _typeOperationResultGeneric = typeof(OperationResult<>);
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            ValidationResult validationResult;
            CustomizedException validationError;

            validationResult = _validator.Validate(request);
            if (validationResult.IsValid)
                return next?.Invoke();

            validationError = new CustomizedException(validationResult.Errors.GroupBy(v => v.PropertyName, v => v.ErrorMessage)
                                                        .ToDictionary(v => v.Key, v => v.Select(y => y)));
            return Task.FromResult((TResponse)Convert.ChangeType(_operationResultError.Invoke(null, new object[] { validationError }), _type));
       }
    }
}
