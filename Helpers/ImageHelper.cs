using System;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace PasswordManager.Helpers;

public static class ImageHelper
{
    /// <summary>
    ///  Loads an image from specified resource URI.
    /// </summary>
    /// <param name="resource">source of image</param>
    public static Bitmap LoadImage(Uri resource)
    {
        return new Bitmap(AssetLoader.Open(resource));
    }
}