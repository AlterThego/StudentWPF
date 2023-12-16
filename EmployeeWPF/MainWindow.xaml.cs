using System.Windows;

using StudentWPF.ViewModels;
namespace StudentWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new StudentViewModel();
            this.DataContext = viewModel;
        }
    }
}
