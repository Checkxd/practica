using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace z1.Models
{
    public class Enrollment : INotifyPropertyChanged
    {
        private int _studentId;
        private int _courseId;
        private int? _grade;
        private string _comment;
        private DateTime _date;

        public int StudentId
        {
            get => _studentId;
            set { _studentId = value; OnPropertyChanged(); }
        }

        public int CourseId
        {
            get => _courseId;
            set { _courseId = value; OnPropertyChanged(); }
        }

        public int? Grade
        {
            get => _grade;
            set { _grade = value; OnPropertyChanged(); }
        }

        public string Comment
        {
            get => _comment;
            set { _comment = value; OnPropertyChanged(); }
        }

        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public Student Student { get; set; }
        public Course Course { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}