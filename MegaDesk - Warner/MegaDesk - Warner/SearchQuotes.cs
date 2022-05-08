using System;
using System.Windows.Forms;

namespace MegaDesk___Warner
{
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();
        }

        private void mainMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
