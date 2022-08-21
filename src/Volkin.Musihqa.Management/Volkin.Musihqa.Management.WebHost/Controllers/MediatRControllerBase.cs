using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Volkin.Musihqa.Management.WebHost.Controllers;

public class MediatRControllerBase : ControllerBase
{
    private IMediator Mediator =>
        HttpContext.RequestServices.GetService<IMediator>() 
        ?? throw new InvalidOperationException("Mediator is not registered");
    

    protected Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        => Mediator.Send(request, HttpContext.RequestAborted);

    protected Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken ct)
        => Mediator.Send(request, ct);
}