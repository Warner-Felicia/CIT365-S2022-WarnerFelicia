using System;
using System.Windows.Forms;

namespace MegaDesk___Warner
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
            PopulateDateGridView();
        }

        private void mainMenuButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void PopulateDateGridView()
        {
            //getting saved quotes
            var quotes = SavedQuoteList.SavedQuotes;
            
            //looping through quotes and adding new row for each with selected data
            foreach (var quote in quotes)
            {
                quoteResults.Rows.Add(quote.CustomerName, quote.Date.ToString("MM/dd/yyyy"), quote.Desk.Width, quote.Desk.Depth,
                    quote.Desk.Drawers, quote.Desk.SurfaceMaterial, quote.Desk.RushOptions, quote.TotalPrice);
            }
        }
    }
}
