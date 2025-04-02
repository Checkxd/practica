using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GradeJournal.Models
{
    public class Grade : INotifyPropertyChanged
    {
        private int _id;
        private string _studentName;
        private double _value;
        private string _comment;
        private DateTime _date;
        private bool _isPresent;
        private double _averageGrade;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string StudentName
        {
            get => _studentName;
            set { _studentName = value; OnPropertyChanged(); }
        }

        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
                RecalculateAverage(); // Пересчёт среднего балла
            }
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

        public bool IsPresent
        {
            get => _isPresent;
            set { _isPresent = value; OnPropertyChanged(); }
        }

        public double AverageGrade
        {
            get => _averageGrade;
            private set { _averageGrade = value; OnPropertyChanged(); }
        }

        public Grade()
        {
            RecalculateAverage();
        }

        private void RecalculateAverage()
        {
            // Упрощённая логика: средний балл равен текущей оценке
            AverageGrade = Value;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}