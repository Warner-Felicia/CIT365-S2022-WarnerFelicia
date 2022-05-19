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
            PopulateComboBoxes();
            SetDefaultValues();
        }

        private void PopulateComboBoxes()
        {
            materialInput.DataSource = Enum.GetValues(typeof(SurfaceMaterial));
            rushOrderInput.DataSource = Enum.GetValues(typeof(RushOptions));
        }

        private void SetDefaultValues()
        {
            drawersInput.SelectedIndex = 0;
            rushOrderInput.SelectedIndex = 3;
        }

        private void AddNewQuote_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren()) return;
            //getting form inputs
            var name = customerNameInput.Text;
            var width = Convert.ToDouble(widthInput.Value);
            var depth = Convert.ToDouble(depthInput.Value);

            //getting combo-box inputs, 
            int.TryParse(drawersInput.SelectedItem.ToString(), out var drawers);
            Enum.TryParse(materialInput.SelectedItem.ToString(), out SurfaceMaterial surfaceMaterial);
            Enum.TryParse(rushOrderInput.SelectedItem.ToString(), out RushOptions rushOptions);

            //creating desk, quote and saving quote
            var desk = new Desk(width, depth, drawers, surfaceMaterial, rushOptions);
            var quote = new DeskQuote(desk, name);
            DeskQuote.SaveQuote(quote);

            //saving data so it's available in DisplayQuote form
            FormData = quote;

            //navigate to displayQuote form
            this.Hide();
            var displayQuote = new DisplayQuote();
            displayQuote.Show();
        }
            
        //validators
        private void NameInputValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(customerNameInput.Text))
            {
                e.Cancel = true;
                customerNameInput.Focus();
                errorProvider1.SetError(customerNameInput, "Please enter a user name");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(customerNameInput, "");
            }
        }
        private void NumericInput_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var inputName = (NumericUpDown) sender;
            var dimension = inputName.Name.Contains("depth") ? "depth" : "width";
            var min = dimension == "width" ? Desk.WidthMin : Desk.DepthMin; 
            var max = dimension == "width" ? Desk.WidthMax : Desk.DepthMax;
            double number = 0;
            try
            {
                number = decimal.ToDouble(inputName.Value);
            }
            catch (Exception)
            {
                e.Cancel = true;
                inputName.Focus();
                errorProvider1.SetError(inputName, "Please enter a number");
            }
            
            if (number < min || number > max)
            {
                e.Cancel = true;
                inputName.Focus();
                errorProvider1.SetError(inputName,
                    $"Please enter a number between {min} and {max}");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(inputName, "");
            }
        }

        private void ComboBoxInput_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var inputName = (ComboBox)sender;
            if (inputName.SelectedItem == null)
            {
                e.Cancel = true;
                inputName.Focus();
                errorProvider1.SetError(inputName, "Selection is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(inputName, "");
            }
        }
    }
}
