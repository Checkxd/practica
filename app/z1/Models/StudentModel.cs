using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace z1.Models
{
    public class Student : INotifyPropertyChanged
    {
        private int _id;
        private string _lastName;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Enrollment> Enrollments { get; } = new ObservableCollection<Enrollment>();

        public double AverageGrade => Enrollments.Any() ? Enrollments.Average(e => e.Grade ?? 0) : 0;

        public Student()
        {
            Enrollments.CollectionChanged += (s, e) => OnPropertyChanged(nameof(AverageGrade));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}