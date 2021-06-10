using MediatR;
using MediatR_Exemplo.Shared.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatR_Exemplo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CrudController : APIControllerBase
    {
        public CrudController(IMediator mediator) : base(mediator) { }

        [HttpPost("[action]")]
        public Task<IActionResult> AddUser([FromBody] CreateUserRequest request)
            => SendCommand(request);
    }
}
