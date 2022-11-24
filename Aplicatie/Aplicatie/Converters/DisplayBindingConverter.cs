using System.Globalization;

namespace Aplicatie.Converters
{
    public class DirectorSelectatBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null || value.ToString().Equals(string.Empty))
                return  "Nu a fost selectat niciun director";
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
                return value.ToString();
            return null;
        }
    }


    public class WhiteOrDarKThemeBindingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is not null)
            {
                switch (value) 
                {
                    case AppTheme.Dark: { return "Dark Theme"; }
                    case AppTheme.Light: { return "Light Theme"; }
                    default: { return "System Theme"; }
                }
            }
            return string.Empty; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SummaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var formattedString = string.Format("$ {0}", value);
            return formattedString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}