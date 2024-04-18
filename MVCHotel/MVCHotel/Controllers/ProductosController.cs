using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCHotel.Models;

namespace MVCHotel.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProductosController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Productos.Include(p => p.categoriaProducto);
            return View(await applicationDBContext.ToListAsync());
        }

        public async Task<IActionResult> IndexUsuarios()
        {
            var applicationDBContext = _context.Productos.Include(p => p.categoriaProducto);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.categoriaProducto)
                .FirstOrDefaultAsync(m => m.idProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["idCategoria"] = new SelectList(_context.CategoriasProducto, "idCategoria", "nombre");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idProducto,nombreProducto,descripcionProducto,cantidad,idCategoria,imagen,precioProducto")] Producto producto, IFormFile imagen)
        {
            if (ModelState.IsValid)
            {
                //Esta linea hace que el tipo file de la imagen se copie en la variable memoryStream y se guarde en la BD como texto
                using(var memoryStream = new MemoryStream())
                {
                    imagen.CopyTo(memoryStream);
                    producto.imagen = memoryStream.ToArray();
                }

                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCategoria"] = new SelectList(_context.CategoriasProducto, "idCategoria", "nombre", producto.idCategoria);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["idCategoria"] = new SelectList(_context.CategoriasProducto, "idCategoria", "nombre", producto.idCategoria);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idProducto,nombreProducto,descripcionProducto,cantidad,idCategoria,imagen,precioProducto")] Producto producto, IFormFile imagen)
        {
            if (ModelState.IsValid)
            {
                //Esta linea hace que el tipo file de la imagen se copie en la variable memoryStream y se guarde en la BD como texto
                using (var memoryStream = new MemoryStream())
                {
                    imagen.CopyTo(memoryStream);
                    producto.imagen = memoryStream.ToArray();
                }
            }
                if (id != producto.idProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.idProducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCategoria"] = new SelectList(_context.CategoriasProducto, "idCategoria", "nombre", producto.idCategoria);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.categoriaProducto)
                .FirstOrDefaultAsync(m => m.idProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.idProducto == id);
        }

        public async Task<IActionResult> GetImage(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(p  => p.idProducto == id);

            if(producto == null)
            {
                return NotFound();
            }
            return File(producto.imagen,"image/png");
        }
    }
}
