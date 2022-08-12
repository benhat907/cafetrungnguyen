using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using cafetrungnguyen.Models;
using System.Data;

namespace cafetrungnguyen.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {

        return View();
    }

    [HttpPost]
    public async Task<JsonResult> LoginMethod(LoginModel log)
    {
        string query = "SELECT Email, UserName, Password From [User] WHERE Email = @Email and Password = @Password";
        DataTable data = DataProvider.ExcuteQuery(query, new Dictionary<string, object>
        {
            {"@Email", log.Email},
            {"@Password", log.Password}     
        });
        if (data.Rows.Count <= 0)
            return Json(new { resault = "Đăng Nhập Thất Bại"} );

        return Json(new { resault = "Đăng Nhập Thành Công" });
    }
    

    public IActionResult Logout()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
