using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicaMVC.Data;
using MusicaMVC.Models;
using MusicaMVC.ViewModel;
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
            List<Album> lista = await musicaDBContext.Albumes
                .Include(a => a.ArtistaReferencia)    
                .ToListAsync();
            
            return View(lista);
        }

        public async Task<IActionResult> ListaCanciones(int id)
        {
            var canciones = await musicaDBContext.Canciones
                .Include(c => c.AlbumReferencia)
                .Where(c => c.IdAlbum == id)
                .ToListAsync();

            return View(canciones);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            var viewModel = new AlbumViewModel()
            {
                AlbumVM = new Album(),
                Artistas = musicaDBContext.Artistas.Select(a => new SelectListItem
                {
                    Value = a.IdArtista.ToString(),
                    Text = a.Nombre
                }).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(AlbumViewModel viewModel)
        {
            await musicaDBContext.Albumes.AddAsync(viewModel.AlbumVM);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Album album = await musicaDBContext.Albumes.FirstAsync(a => a.IdAlbum == id);

            var viewModel = new AlbumViewModel()
            { 
                AlbumVM = album,
                Artistas = musicaDBContext.Artistas.Select(a => new SelectListItem
                {
                    Value = a.IdArtista.ToString(),
                    Text = a.Nombre
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(AlbumViewModel viewModel)
        {
            musicaDBContext.Albumes.Update(viewModel.AlbumVM);
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