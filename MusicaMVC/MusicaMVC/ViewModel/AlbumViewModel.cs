using Microsoft.AspNetCore.Mvc.Rendering;
using MusicaMVC.Models;

namespace MusicaMVC.ViewModel
{
    public class AlbumViewModel
    {
        public Album AlbumVM { get; set; }
        public IEnumerable<SelectListItem> Artistas { get; set; }
    }
}
