using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicaMVC.Data;
using MusicaMVC.Models;

namespace MusicaMVC.Controllers
{
    public class ArtistaController : Controller
    {
        private readonly MusicaDBContext musicaDBContext;

        public ArtistaController(MusicaDBContext _musicaDBContext)
        {
            musicaDBContext = _musicaDBContext;
        }

        public async Task<IActionResult> Lista()
        {
            List<Album> lista = await musicaDBContext.Albumes.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo() 
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
        public async Task<IActionResult> Eliminar (int id)
        {
            Album album = await musicaDBContext.Albumes.FirstAsync(a => a.IdAlbum == id);
            musicaDBContext.Albumes.Remove(album);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }
    }
}
