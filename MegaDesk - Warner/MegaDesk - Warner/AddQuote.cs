using System;
using System.Windows.Forms;

namespace MegaDesk___Warner
{
    public partial class AddQuote : Form
    {
        public static Object FormData;

        public AddQuote()
        {
            InitializeComponent();

            depthInput.KeyPress += new KeyPressEventHandler(keyPressed);
        }

        private void addNewQuote_Click(object sender, EventArgs e)
        {
            //getting form inputs

            var name = customerNameInput.Text;
            var width = Convert.ToDouble(widthInput.Text);
            var depth = Convert.ToDouble(depthInput.Text);

            //getting combo-box inputs, 
            int.TryParse(drawersInput.SelectedItem.ToString(), out var drawers);
            Enum.TryParse(materialInput.SelectedItem.ToString(), out SurfaceMaterial surfaceMaterial);

            //rushOptions combo-box
            Enum.TryParse(rushOrderInput.SelectedItem.ToString(), out RushOptions rushOptions);

            var desk = new Desk(width, depth, drawers, surfaceMaterial, rushOptions);
            var quote = new DeskQuote(desk, name);

            //saving data so it's available in DisplayQuote form
            FormData = quote;

            //navigate to displayQuote form
            this.Hide();
            var displayQuote = new DisplayQuote();
            displayQuote.Show();
        }

        //validators
        private void widthInput_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var isDouble = Double.TryParse(widthInput.Text, out double width);
            if (!isDouble)
            {
                e.Cancel = true;
                widthInput.Focus();
                errorProvider1.SetError(widthInput, "Please enter a number");
            }

            if (width < Desk.WIDTH_MIN || width > Desk.WIDTH_MAX)
            {
                e.Cancel = true;
                widthInput.Focus();
                errorProvider1.SetError(widthInput,
                    $"Please enter a number between {Desk.WIDTH_MIN} and {Desk.WIDTH_MAX}");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(widthInput, "");
            }
        }

        private void depthInput_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var isDouble = Double.TryParse(depthInput.Text, out double depth);
            if (!isDouble)
            {
                e.Cancel = true;
                depthInput.Focus();
                errorProvider1.SetError(depthInput, "Please enter a number");
            }

            if (depth < Desk.DEPTH_MIN || depth > Desk.DEPTH_MAX)
            {
                e.Cancel = true;
                depthInput.Focus();
                errorProvider1.SetError(depthInput,
                    $"Please enter a number between {Desk.DEPTH_MIN} and {Desk.DEPTH_MAX}");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(depthInput, "");
            }
        }
        private void keyPressed(Object o, KeyPressEventArgs e)
        {
            //char character = e.KeyChar;
            if ((char.IsControl(e.KeyChar) || !char.IsDigit(e.KeyChar)) && e.KeyChar != (char)Keys.Back)
            {
                e.KeyChar = (char) 0;
            }
        }
    }
}
