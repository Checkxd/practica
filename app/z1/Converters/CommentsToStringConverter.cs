using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using z1.Models;

namespace z1.Converters
{
    public class CommentsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<GradeModel> grades && grades.Any())
            {
                return "Комментарии: " + string.Join("; ", grades.Select(g => g.Comment));
            }
            return "Комментарии отсутствуют";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}