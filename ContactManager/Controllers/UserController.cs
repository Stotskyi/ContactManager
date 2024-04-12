using ContactManager.DAL.Models;
using ContactManager.Services;
using ContactManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers;

public class UserController(ILogger<HomeController> logger, ICsvService csvService, IUserService userService) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly ICsvService _csvService = csvService;
    private readonly IUserService _userService = userService;

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        var user =  await _csvService.Deserialize(file);
        await  _userService.UploadAsync(user);
        return Ok();
    }

    [HttpGet]
    public Task<IActionResult> Upload()
    {
        return Task.FromResult<IActionResult>(View());
    }

    [HttpGet]
    public async Task<IActionResult> DispalyRecords()
    {
        var users = await _userService.GetAllUsersAsync();
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteUserAsync(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Update(User user)
    {
        await _userService.UpdateUserAsync(user);
        return Ok();
    }

    
}