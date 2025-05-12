using Microsoft.AspNetCore.Mvc.Rendering;
using MusicaMVC.Models;

namespace MusicaMVC.ViewModel
{
    public class CancionViewModel
    {
        public Cancion CancionVM { get; set; }
        public IEnumerable<SelectListItem> Albumes { get; set; }
    }
}
