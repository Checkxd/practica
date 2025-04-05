using System;
using System.Globalization;
using System.Windows.Data;
using z1.Models;

namespace z1.Converters
{
    public class LowGradeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double averageGrade)
            {
                return averageGrade > 0 && averageGrade < 3.0;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}