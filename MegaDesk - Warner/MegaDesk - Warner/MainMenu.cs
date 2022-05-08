using System;
using System.Windows.Forms;

namespace MegaDesk___Warner
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void addNewQuote_Click(object sender, EventArgs e)
        {
            this.Hide();
            var addQuoteForm = new AddQuote();
            addQuoteForm.Show();
        }

        private void viewQuotes_Click(object sender, EventArgs e)
        {
            this.Hide();
            var viewAllQuotesForm = new ViewAllQuotes();
            viewAllQuotesForm.Show();
        }

        private void searchQuotes_Click(object sender, EventArgs e)
        {
            this.Hide();
            var searchQuotesForm = new SearchQuotes();
            searchQuotesForm.Show();
        }

        private void exit_Click(object sender, EventArgs e) => 
            Application.Exit();
    }
}
