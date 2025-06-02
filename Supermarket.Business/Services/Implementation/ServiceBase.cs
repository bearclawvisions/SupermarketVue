using Microsoft.Extensions.Logging;
using Supermarket.Data.Repository.Interface;
using System.Security.Claims;

namespace Supermarket.Business.Services.Implementation;

public class ServiceBase
{
    private readonly ILogger _logger;
    private readonly ClaimsPrincipal _claimsPrincipal;
    private readonly IUnitOfWork _unitOfWork;
    // private readonly IHttpContextaccessor _httpContextAccessor;
    
    public ServiceBase(ILogger logger, ClaimsPrincipal claimsPrincipal, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _claimsPrincipal = claimsPrincipal;
        _unitOfWork = unitOfWork;
    }
}