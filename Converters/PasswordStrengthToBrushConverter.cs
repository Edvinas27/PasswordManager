using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Styling;
using PasswordManager.Data;
using PasswordManager.Extensions;

namespace PasswordManager.Converters;

public class PasswordStrengthToBrushConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values[0]?.ToString() == Constants.NoSelection)
        {
            return null;
        }

        if (values[1] is not Label data) return null;

        var content = data.Content?.ToString()?.RemoveSpaces();

        if (Application.Current?.Resources.TryGetResource($"{content}PasswordColour",ThemeVariant.Default , out var resource) == true)
        {
            var brush = resource as IBrush;

            return brush;

        }
        
        return null;
    }
}