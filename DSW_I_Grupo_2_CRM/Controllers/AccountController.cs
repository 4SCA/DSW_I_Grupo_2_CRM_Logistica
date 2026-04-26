using DSW_I_Grupo_2_CRM.Data.Repositories;
using DSW_I_Grupo_2_CRM.DTOs;
using DSW_I_Grupo_2_CRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSW_I_Grupo_2_CRM.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _service;

        public AccountController(AccountService service)
        {
            _service = service;
        }

        // ================= LOGIN =================

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var usuario = await _service.LoginAsync(dto);

            if (usuario == null)
            {
                ViewBag.Error = "Correo o contraseña incorrectos";
                return View(dto);
            }

            // Guardar token en sesión (temporal para pruebas)
            HttpContext.Session.SetString("JWT", usuario.Token);

            return RedirectToAction("Index", "Home");
        }

        // ================= REGISTER =================

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _service.RegisterAsync(dto);

            return RedirectToAction("Login");
        }

        // ================= LOGOUT =================

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWT");
            return RedirectToAction("Login");
        }
    }
}
