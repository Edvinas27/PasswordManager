using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace PasswordManager.Helpers;

public static class ImageHelper
{
    public static Bitmap LoadImage(Uri resource)
    {
        return new Bitmap(AssetLoader.Open(resource));
    }
}