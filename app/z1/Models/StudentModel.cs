using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace z1.Models
{
    public class StudentModel : INotifyPropertyChanged
    {
        private int _id;
        private string _lastName;

        public int Id
        {
            get => _id;
            set
            {
                if (_id == value) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value) return;
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<GradeModel> Grades { get; } = new ObservableCollection<GradeModel>();

        public double AverageGrade => Grades.Any() ? Grades.Average(g => g.Value) : 0;

        public StudentModel()
        {
            Grades.CollectionChanged += (s, e) => OnPropertyChanged(nameof(AverageGrade));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}