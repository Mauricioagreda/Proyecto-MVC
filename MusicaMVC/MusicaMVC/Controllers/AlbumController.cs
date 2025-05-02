using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MusicaMVC.Data;
using MusicaMVC.Models;
using System.ComponentModel;

namespace MusicaMVC.Controllers
{
    public class AlbumController : Controller
    {
        private readonly MusicaDBContext musicaDBContext;

        public AlbumController(MusicaDBContext _musicaDBContext)
        {
            musicaDBContext = _musicaDBContext;
        }

        public async Task<IActionResult> Lista()
        {
            List<Album> lista = await musicaDBContext.Albumes.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(Album album)
        {
            await musicaDBContext.Albumes.AddAsync(album);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Album album = await musicaDBContext.Albumes.FirstAsync(a => a.IdAlbum == id);

            return View(album);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Album album)
        {
            musicaDBContext.Albumes.Update(album);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Album album = await musicaDBContext.Albumes.FirstAsync(a => a.IdAlbum == id);
            musicaDBContext.Remove(album);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }
    }
}