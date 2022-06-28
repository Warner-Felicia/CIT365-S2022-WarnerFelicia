using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Views
{
    public partial class NotesPage : ContentPage
    {
        private string _fileName =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        
        public NotesPage()
        {
            InitializeComponent();

            // Read the file.
            if (File.Exists(_fileName))
            {
                Editor.Text = File.ReadAllText(_fileName);
            }
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            //Save the file
            File.WriteAllText(_fileName, Editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            //Delete the file
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }

            Editor.Text = string.Empty;
        }
    }
}