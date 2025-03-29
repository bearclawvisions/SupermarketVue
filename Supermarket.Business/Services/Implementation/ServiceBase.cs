using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace Supermarket.Business.Services.Implementation;

public class ServiceBase
{
    private readonly ILogger _logger;
    private readonly ClaimsPrincipal _claimsPrincipal;
    
    public ServiceBase(ILogger logger, ClaimsPrincipal claimsPrincipal)
    {
        _logger = logger;
        _claimsPrincipal = claimsPrincipal;
    }
}