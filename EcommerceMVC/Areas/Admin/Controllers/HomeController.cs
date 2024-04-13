using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.Helpers;
using EcommerceMVC.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EcommerceMVC.Areas.Admin.ViewModels;

namespace EcommerceMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly Hshop2023Context db;
        private readonly IMapper _mapper;

        public HomeController(Hshop2023Context context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Login
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginAdminVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var admin = db.Admins.SingleOrDefault(kh => kh.UserAdmin == model.UserAdmin);
                if (admin == null)
                {
                    ModelState.AddModelError("loi", "Không có khách hàng này");
                }
                else
                {
                    
                        if (admin.PassAdmin != model.PassAdmin)
                        {
                            ModelState.AddModelError("loi", "Sai thông tin đăng nhập");
                        }
                        else
                        {
                            var claims = new List<Claim> {
                                new Claim(ClaimTypes.Name, admin.UserAdmin),
								//claim - role động
								new Claim(ClaimTypes.Role, "Admin")
                            };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                            await HttpContext.SignInAsync(claimsPrincipal);

                            if (Url.IsLocalUrl(ReturnUrl))
                            {
                                return Redirect(ReturnUrl);
                            }
                            else
                            {
                                return Redirect("Index");
                            }
                        }
                    
                }
            }
            return View();
        }
        #endregion
    }
}
