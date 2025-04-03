using System;
using System.ComponentModel;

namespace z1.Models
{
    public class GradeModel : INotifyPropertyChanged
    {
        private DateTime _date;
        private int _value;
        private string _comment;


        public DateTime Date
        {
            get => _date;
            set { _date = value; OnPropertyChanged(); }
        }

        public int Value
        {
            get => _value;
            set { _value = value; OnPropertyChanged(); }
        }

        public string Comment
        {
            get => _comment;
            set { _comment = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}