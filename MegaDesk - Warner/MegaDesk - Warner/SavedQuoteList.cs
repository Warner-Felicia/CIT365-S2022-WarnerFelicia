using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MegaDesk___Warner
{
    public class SavedQuoteList
    {
        public static List<DeskQuote> SavedQuotes { get; set; }

        public static void LoadSavedQuotes()
        {
            var serializedQuotes = File.ReadAllText("quotes.json");
            SavedQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(serializedQuotes);


        }
    }

    
}
