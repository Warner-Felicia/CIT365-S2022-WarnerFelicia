using System;
using System.Linq;
using System.Windows.Forms;

namespace MegaDesk___Warner
{
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
            materialInput.DataSource = Enum.GetNames(typeof(SurfaceMaterial));
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //clear data and reset to delete results from previous searches
            quoteSearchResults.Rows.Clear();
            quoteSearchResults.Refresh();
            
            //get selected material
            var material = materialInput.SelectedItem.ToString();
            //loop through the saved quotes to find matches
            foreach (var quote in DeskQuote.AllQuotes.Where(quote => material == quote.Desk.SurfaceMaterial.ToString()))
            {
                //add new row for successful match with required column data
                quoteSearchResults.Rows.Add(quote.CustomerName, quote.Date.ToString("MM/dd/yyyy"), quote.Desk.Width, quote.Desk.Depth,
                    quote.Desk.Drawers, quote.Desk.SurfaceMaterial, quote.Desk.RushOptions, quote.TotalPrice);
            }
            
        }
    }
}
