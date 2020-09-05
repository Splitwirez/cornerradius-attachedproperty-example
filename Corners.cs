using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml;

namespace CornerRadiusAttachedPropertyExample
{
    public class Corners : Control
    {
        static Corners()
        {
            AffectsRender<Button>(CornerRadiusProperty);
        }

        public static readonly AttachedProperty<CornerRadius> CornerRadiusProperty =
        AvaloniaProperty.RegisterAttached<Corners, Button, CornerRadius>("CornerRadius", defaultValue: new CornerRadius());

        public static CornerRadius GetCornerRadius(Button element)
        {
            return element.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(Button element, CornerRadius value)
        {
            element.SetValue(CornerRadiusProperty, value);
        }
    }

    public class DoublesToCornerRadiusConverter : IMultiValueConverter
    {
        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            var vals = values.OfType<double>().ToArray();
            return new CornerRadius(vals[0], vals[1], vals[2], vals[3]);
        }
    }
}