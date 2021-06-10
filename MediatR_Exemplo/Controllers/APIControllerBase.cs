using MediatR;
using MediatR_Exemplo.Shared;
using MediatR_Exemplo.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR_Exemplo.Controllers
{
    public abstract class APIControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected APIControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<IActionResult> SendCommand<T>(IRequest<OperationResult<T>> request)
        {
            var (isSuccess, result, error) = await _mediator.Send(request).ConfigureAwait(false);

            if (isSuccess)
            {
                return Ok(result);
            }

            if(error is CustomizedException errorValidation)
            {
                return BadRequest(errorValidation.Errors);
            }

            return BadRequest(new System.Exception[] { error });
        }
    }
}
