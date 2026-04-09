using Microsoft.AspNetCore.Mvc;

namespace DSW_I_Grupo_2_CRM.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
