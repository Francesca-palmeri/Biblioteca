using System.Threading.Tasks;
using Biblioteca.Services;
using Biblioteca.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class LibroController : Controller
    {

        private readonly LibroService _libroService;
        public LibroController(LibroService libroService)
        {
            //inietto il servizio all'interno del controller
            _libroService = libroService;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _libroService.GetAllBooksAsync();


            return View(books);
        }

        public IActionResult Add()
            { 
            return View(); 
        
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLibriViewModel addLibriViewModel)
        {
           var result = await _libroService.AddLibriAsync(addLibriViewModel);
            if (!result)
            {
                TempData["Error"] = "Error while saving entity to database";
            }
            return RedirectToAction("Index");
        }
    }
}
