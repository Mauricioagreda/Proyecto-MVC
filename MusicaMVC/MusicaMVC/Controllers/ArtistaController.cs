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
            List<Artista> lista = await musicaDBContext.Artistas.ToListAsync();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Artista artista)
        {
            await musicaDBContext.Artistas.AddAsync(artista);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Artista artista = await musicaDBContext.Artistas.FirstAsync(a => a.IdArtista == id);

            return View(artista);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Artista artista)
        {
            musicaDBContext.Artistas.Update(artista);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar (int id)
        {
            Artista artista = await musicaDBContext.Artistas.FirstAsync(a => a.IdArtista == id);
            musicaDBContext.Artistas.Remove(artista);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }
    }
}
