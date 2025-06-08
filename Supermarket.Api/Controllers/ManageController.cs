using Microsoft.AspNetCore.Mvc;
using Supermarket.Business.Services.Interface;

namespace Supermarket.Api.Controllers;

public class ManageController : BaseController
{
    private readonly IAppUserService _appUserService;
    
    public ManageController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }
    
    [HttpGet(nameof(GetAllUsers))]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _appUserService.GetAllUsers();
        
        return Ok(result);
    }
}
