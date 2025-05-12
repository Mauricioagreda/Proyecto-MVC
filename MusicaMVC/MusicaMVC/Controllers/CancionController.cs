using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicaMVC.Data;
using MusicaMVC.Models;
using MusicaMVC.ViewModel;

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
            List<Cancion> lista = await musicaDBContext.Canciones
                .Include(c => c.AlbumReferencia.ArtistaReferencia)
                .ToListAsync();

            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            var viewModel = new CancionViewModel()
            {
                CancionVM = new Cancion(),
                Albumes = musicaDBContext.Albumes.Select(a => new SelectListItem
                {
                    Value = a.IdAlbum.ToString(),
                    Text = a.Nombre
                }).ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Nuevo(CancionViewModel viewModel)
        {
            await musicaDBContext.Canciones.AddAsync(viewModel.CancionVM);
            await musicaDBContext.SaveChangesAsync();

            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Cancion cancion = await musicaDBContext.Canciones.FirstAsync(c => c.IdCancion == id);

            var viewModel = new CancionViewModel()
            {
                CancionVM = cancion,
                Albumes = musicaDBContext.Albumes.Select(a => new SelectListItem
                {
                    Value = a.IdAlbum.ToString(),
                    Text = a.Nombre
                }).ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(CancionViewModel viewModel)
        {
            musicaDBContext.Canciones.Update(viewModel.CancionVM);
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
