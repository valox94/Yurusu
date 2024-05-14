using MediatR;
using Occam.UI;

namespace Occam.Application;

public record RunApplication()
{
    public record Request() : IRequest<Response>;
    
    public record Response();
}

public class RunApplicationHandler : IRequestHandler<RunApplication.Request,RunApplication.Response>
{
    private readonly IPlayerInterface _interface;

    public RunApplicationHandler(IPlayerInterface @interface)
    {
        _interface = @interface;
    }

    public async Task<RunApplication.Response> Handle(RunApplication.Request request, CancellationToken cancellationToken)
    {
        await _interface.ShowMessageAsync("Welcome to Occam!");
        await _interface.WaitForPlayerAcknowledgementAsync();
        
        return new RunApplication.Response();
    }
}