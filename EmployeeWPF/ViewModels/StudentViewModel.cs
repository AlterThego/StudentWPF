using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using StudentWPF.Models;
using StudentWPF.Commands;
using System.Collections.ObjectModel;
namespace StudentWPF.ViewModels
{
    class StudentViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        StudentService objStudentService;
        public StudentViewModel()
        {
            objStudentService = new StudentService();
            LoadData();
            CurrentStudent = new Student();
            saveCommand = new RelayCommand(Save);
            searchCommand = new RelayCommand(Search);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        private Student currentStudent;
        public Student CurrentStudent
        {
            get { return currentStudent; }
            set { currentStudent = value; OnPropertyChanged("CurrentStudent"); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region DisplayOperation

        private ObservableCollection<Student> studentsList;
        public ObservableCollection<Student> StudentsList
        {
            get { return studentsList; }
            set { studentsList = value; OnPropertyChanged("StudentsList"); }
        }
        private void LoadData()
        {
            StudentsList = new ObservableCollection<Student>(objStudentService.GetAll());
        }
        #endregion

        #region SaveOperation
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var isSaved = objStudentService.Add(currentStudent);
                LoadData();
                CurrentStudent = new Student();
                if (isSaved)
                {
                    Message = "Student saved";
                }
                else
                {
                    Message = "Save operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        #endregion

        #region SearchOperation
        private RelayCommand searchCommand;

        public RelayCommand SearchCommand
        {
            get { return searchCommand; }
        }

        public void Search()
        {
            try
            {
                var objStudent = objStudentService.Search(CurrentStudent.Id);
                if(objStudent != null)
                {
                    CurrentStudent = objStudent;
                    Message = "Student found.";

                }
                else
                {
                    Message = "Student not found.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region updateOperation
        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void Update()
        {
            try
            {
                var isUpdated = objStudentService.Update(CurrentStudent);
                if (isUpdated)
                {
                    Message = "Student Updated";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion

        #region deleteOperation
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var isUpdated = objStudentService.Delete(CurrentStudent.Id);
                if (isUpdated)
                {
                    Message = "Student Deleted";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed.";
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
    }
}
