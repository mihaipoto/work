﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Converters;

public class BoolToObjectConverter<T> : IValueConverter
{
    

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return parameter.Equals(value) ? true : false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
