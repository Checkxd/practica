using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeJournal.Models
{
    public class GradeModel : INotifyPropertyChanged
    {
        private int _id;
        private int _studentId;
        private int _courseId;
        private double _value;
        private bool _isPresent;
        private string _comment;
        private DateTime _date;
        private double _averageGrade;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

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

        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
                RecalculateAverage();
            }
        }

        public bool IsPresent
        {
            get => _isPresent;
            set { _isPresent = value; OnPropertyChanged(); }
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

        public double AverageGrade
        {
            get => _averageGrade;
            private set { _averageGrade = value; OnPropertyChanged(); }
        }

        public GradeModel()
        {
            RecalculateAverage();
        }

        private void RecalculateAverage()
        {
            AverageGrade = Value; // Упрощённая логика
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}