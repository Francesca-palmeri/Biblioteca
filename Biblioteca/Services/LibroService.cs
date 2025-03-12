using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Biblioteca.Services
{
    public class LibroService
    {

        private readonly BibliotecaDbContext _context;

        public LibroService(BibliotecaDbContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveAsync() //logica per il salvataggio delle modifiche sul db, metodo che va in aiuto al metodo AddLibriAsync
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ListaLibriViewModel> GetAllBooksAsync()
        {
            var listaLibri = new ListaLibriViewModel();

            listaLibri.Libri = await _context.Libri.ToListAsync();

            return listaLibri;
        }

        public async Task<bool> AddLibriAsync(AddLibriViewModel addLibriViewModel)
        {
            var libro = new Libro
            {
                Id = Guid.NewGuid(),
                Titolo = addLibriViewModel.Titolo,
                Autore = addLibriViewModel.Autore,
                Genere = addLibriViewModel.Genere,
                Disponibilità = addLibriViewModel.Disponibilità,
                Copertina = addLibriViewModel.Copertina
            };
            _context.Libri.Add(libro);
           
            return await SaveAsync(); //permette di effettuare la query reale sul database reale 
        }
    }
}
