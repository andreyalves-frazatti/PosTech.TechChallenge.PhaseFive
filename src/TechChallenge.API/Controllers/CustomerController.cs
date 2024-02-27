using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechChallenge.API.Models;

namespace TechChallenge.API.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomerController(IMediator mediator)
    : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] CreateCustomerModel model, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(model.MapToCommand(), cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(GetCustomerModel model, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(model.MapToQuery(), cancellationToken);
        return Ok(response);
    }

    [HttpPut("anonymize")]
    public async Task<IActionResult> AnonymizeAsync(AnonymizeCustomerModel model, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(model.MapToCommand(), cancellationToken);
        return Ok(response);
    }
}
