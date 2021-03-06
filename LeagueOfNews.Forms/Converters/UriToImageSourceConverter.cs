﻿using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace LeagueOfNews.Forms.Converters
{
    public class UriToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return value;
            }

            if (value is byte[])
            {
                return ImageSource.FromStream(() => new MemoryStream((byte[])value));
            }
            else if (!(value is Uri))
            {
                ImageSource src = value as string;
                return src;
            }

            return ImageSource.FromUri((Uri)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}