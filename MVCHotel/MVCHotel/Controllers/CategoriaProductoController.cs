using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCHotel.Models;
using System.Numerics;

namespace MVCHotel.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class CategoriaProductoController : Controller
    {

        private readonly ApplicationDBContext _context;

        public CategoriaProductoController(ApplicationDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CategoriaProducto> categoriaProducto = _context.CategoriasProducto.ToList();
            return View(categoriaProducto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("idCategoria,nombre,descripcion")] CategoriaProducto categoriaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProducto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoriaProducto = await _context.CategoriasProducto.FindAsync(id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }
            return View(categoriaProducto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("idCategoria,nombre,descripcion")] CategoriaProducto categoriaProducto)
        {
            if (id != categoriaProducto.idCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(categoriaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProducto);
        }

        

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoriaProducto = await _context.CategoriasProducto.FirstOrDefaultAsync(m => m.idCategoria == id); /* MODO_CON_LAMBA */
            if (categoriaProducto != null)
            {
                _context.CategoriasProducto.Remove(categoriaProducto);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
