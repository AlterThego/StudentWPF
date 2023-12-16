using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using StudentWPF.ViewModels;

namespace StudentWPF.Views
{
    public partial class AboutDevelopers : Window
    {
        public ObservableCollection<GroupMemberViewModel> GroupMembers { get; set; }

        public AboutDevelopers()
        {
            InitializeComponent();
            InitializeGroupMembers();
            DataContext = this;
        }

        private void InitializeGroupMembers()
        {
            // Create instances of GroupMemberViewModel for each group member
            GroupMembers = new ObservableCollection<GroupMemberViewModel>
            {
                new GroupMemberViewModel { Name = "Member 1", Role = "Role 1" },
                new GroupMemberViewModel { Name = "Member 2", Role = "Role 2" },
                new GroupMemberViewModel { Name = "Member 3", Role = "Role 3" },
                new GroupMemberViewModel { Name = "Member 4", Role = "Role 4" },
                new GroupMemberViewModel { Name = "Member 5", Role = "Role 5" }
            };
        }
    }
}