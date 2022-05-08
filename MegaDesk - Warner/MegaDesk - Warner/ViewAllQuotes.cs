using System;
using System.Windows.Forms;

namespace MegaDesk___Warner
{
    public partial class ViewAllQuotes : Form
    {
        public ViewAllQuotes()
        {
            InitializeComponent();
        }

        private void mainMenuButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.Show();
        }
    }
}
