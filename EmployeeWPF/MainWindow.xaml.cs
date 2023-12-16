using System;
using System.Windows;

namespace StudentWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentInfoClicked(object sender, RoutedEventArgs e)
        {
            // Create a new window
            Window studentWindow = new Window
            {
                Content = new StudentWPF.Views.StudentView(), // Assuming StudentView is the name of your UserControl
                Title = "Student Information",
                Height = 600,
                Width = 800
            };

            // Show the new window
            studentWindow.Show();
        }
    }
}
