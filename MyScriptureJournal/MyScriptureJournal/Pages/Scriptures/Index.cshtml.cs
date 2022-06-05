using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string BookName { get; set; }
        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            //database query to get names of books for selectList
            IQueryable<string> bookQuery = from s in _context.Scripture
                orderby s.Book
                select s.Book;
            
            //gets all scriptures from database
            var scriptures = from s in _context.Scripture
                select s;

            //checks to see if search value has been entered
            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(SearchString));
            }
            
            //checks to see if book is selected from dropdown
            if (!string.IsNullOrEmpty(BookName))
            {
                scriptures = scriptures.Where(x => x.Book == BookName);
            }
            
            //creates select list using previous query
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());

            //variables to hold what is being search and ascending or descending
            BookSort = String.IsNullOrEmpty(sortOrder) ? "book_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            //sorts scriptures according to sort criteria
            switch (sortOrder)
            {
                case "book_desc":
                   scriptures = scriptures.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    scriptures = scriptures.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    scriptures = scriptures.OrderByDescending(s => s.Date);
                    break;
                default:
                    scriptures = scriptures.OrderBy(s => s.Book);
                    break;
            }

            //create list of scriptures that met search criteria and have been sorted
            Scripture = await scriptures.ToListAsync();
        }
    }
}
