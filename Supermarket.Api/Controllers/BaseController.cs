using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Supermarket.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    // Common logic that works with type T (e.g., for CRUD operations)
}