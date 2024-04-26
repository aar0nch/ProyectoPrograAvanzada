using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCHotel.Models;
using System.Diagnostics;
using System.Security.Claims;
using MVCHotel.CustomFilters;
using Microsoft.AspNetCore.Authorization;

namespace MVCHotel.Controllers
{
    
    public class ApartarController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ApartarController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Productos.Include(h => h.categoriaProducto);
            return View(await applicationDBContext.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Create(int id)
        {
            Apartar apartar = new Apartar();
            apartar.idProducto = id;
            apartar.fechaCompra = DateTime.Now;
            apartar.UserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(apartar);
        }

        [HttpPost]
        [LogActionFilter]
        public async Task<IActionResult> Create(Apartar apartar)
        {
            if (ModelState.IsValid)
            {
                _context.Apartars.Add(apartar);
                _context.SaveChanges();

                TempData["Exito"] = "Se agregó al carrito con Éxito";

                return RedirectToAction(nameof(Index));
            }

            return View(apartar);
        }

        [Authorize]
        public async Task<IActionResult> Carrito()
        {
            string userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var apartars = _context.Apartars.Where(r => r.UserId == userId).ToList();

            return View(apartars);
        }

        public async Task<IActionResult> GetImage(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(h => h.idProducto == id);

            if (producto == null)
            {
                return NotFound();
            }

            return File(producto.imagen, "image/png");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
