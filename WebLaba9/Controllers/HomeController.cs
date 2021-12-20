using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebLaba9.Models;

namespace WebLaba9.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;
        
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                string id = _userManager.GetUserId(HttpContext.User);
                
                User user = await _userManager.FindByIdAsync(id);

                AllEmailsViewModel model = new AllEmailsViewModel();

                model.EmailsReceived = from e in _db.Emails
                    where e.RecipientEmail == user.Email
                    orderby e.Id
                    select e;
                
                model.EmailsSent = from e in _db.Emails
                    where e.SenderEmail == user.Email
                    orderby e.Id
                    select e;

                return View(model);
            }
            
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _db.Emails.FirstOrDefaultAsync(m => m.Id == id);
            
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User() { Email = model.Username + "@domain.com", UserName = model.Username};
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel() {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "NotValidCredentials");
                }
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                string id = _userManager.GetUserId(HttpContext.User);

                User sender = await _userManager.FindByIdAsync(id);

                User recipient = _db.Users.FirstOrDefaultAsync(m => m.Email == model.SendTo).Result;
                
                Email email = new Email()
                {
                    SenderEmail = sender.Email,
                    SenderId = sender.Id,
                    RecipientEmail = recipient.Email,
                    RecipientId = recipient.Id,
                    Title = model.Title,
                    Message = model.Message,
                    Date = DateTime.Now
                };

                await _db.Emails.AddAsync(email);
                await _db.SaveChangesAsync();

                return Json(new
                    { isValid = true, html = Helper.RenderRazorViewToString(this, "_EmailTables", new AllEmailsViewModel()
                    {
                        EmailsReceived = from e in _db.Emails
                            where e.RecipientId == _userManager.GetUserId(HttpContext.User)
                            orderby e.Id
                            select e,
                        EmailsSent = from e in _db.Emails
                            where e.SenderId == _userManager.GetUserId(HttpContext.User)
                            orderby e.Id
                            select e
                    }) });
            }

            return Json(new {isValid = false, html = Helper.RenderRazorViewToString(this, "SendEmail", model) });
        }
        
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}