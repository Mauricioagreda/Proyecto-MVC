using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicaMVC.Data;
using MusicaMVC.Migrations;
using MusicaMVC.Models;
using System.Reflection.Metadata.Ecma335;

namespace MusicaMVC.Controllers
{
    public class CancionController : Controller
    {
        private readonly MusicaDBContext musicaDBContext;

        public CancionController(MusicaDBContext _musicaDBContext)
        {
            musicaDBContext = _musicaDBContext;
        }

        public async Task<IActionResult> Lista()
        {
            List<Cancion> lista = await musicaDBContext.Canciones.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(Cancion cancion)
        {
            await musicaDBContext.Canciones.AddAsync(cancion);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Cancion cancion = await musicaDBContext.Canciones.FirstAsync(c => c.IdCancion == id);
            return View(cancion);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Cancion cancion)
        {
            musicaDBContext.Canciones.Update(cancion);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Cancion cancion = await musicaDBContext.Canciones.FirstAsync(c => c.IdCancion == id);

            musicaDBContext.Canciones.Remove(cancion);
            await musicaDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }
    }
}
