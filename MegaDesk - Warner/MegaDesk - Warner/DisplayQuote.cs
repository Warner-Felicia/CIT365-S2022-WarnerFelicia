using System;
using System.Globalization;
using System.Windows.Forms;

namespace MegaDesk___Warner
{
    public partial class DisplayQuote : Form
    {
        public DisplayQuote()
        {
            InitializeComponent();
        }

        private void mainMenuButton_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            var mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void ViewDisplayQuote(object sender, EventArgs e)
        {
            var quote = (DeskQuote)AddQuote.FormData;
            quoteDate.Text = quote.Date.ToString("MM/dd/yyyy");
            basePrice.Text = quote.BasePrice.ToString(CultureInfo.CurrentCulture);
            areaPrice.Text = quote.AreaPrice.ToString(CultureInfo.CurrentCulture);
            drawersPrice.Text = quote.DrawersPrice.ToString(CultureInfo.CurrentCulture);
            materialsPrice.Text = quote.MaterialsPrice.ToString(CultureInfo.CurrentCulture);
            rushOrderPrice.Text = quote.RushOrderPrice.ToString(CultureInfo.CurrentCulture);
            totalPrice.Text = quote.TotalPrice.ToString(CultureInfo.CurrentCulture);

        }
    }
}
