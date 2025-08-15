using Microsoft.AspNetCore.Mvc;
using Supermarket.Business.Services.Interface;

namespace Supermarket.Api.Controllers;

public class ManageController : BaseController
{
    private readonly IAppUserService _appUserService;
    private readonly IProductService _productService;
    private readonly IProductCategoryService _productCategoryService;
    
    public ManageController(IAppUserService appUserService, IProductService productService, IProductCategoryService productCategoryService)
    {
        _appUserService = appUserService;
        _productService = productService;
        _productCategoryService = productCategoryService;
    }
    
    [HttpGet(nameof(GetAllUsers))]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _appUserService.GetAllUsers();
        
        return Ok(result);
    }

    [HttpGet(nameof(GetAllCategories))]
    public async Task<IActionResult> GetAllCategories()
    {
        var result = await _productCategoryService.GetAllCategories();
        return Ok(result);
    }

    [HttpGet(nameof(GetAllProductsForCategory)+ "/{categoryId:int}")]
    public async Task<IActionResult> GetAllProductsForCategory(int categoryId)
    {
        var result = await _productService.GetAllProductsForCategory(categoryId);
        
        return Ok(result);
    }
}
