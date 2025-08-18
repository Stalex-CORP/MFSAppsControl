using MFSAppsControl.Services;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MFSAppsControl.Converters
{
    public class ExeIconToImageSourceConverter : IValueConverter
    {
        private readonly ILoggerService<ExeIconToImageSourceConverter> logger = App.GetRequiredService<ILoggerService<ExeIconToImageSourceConverter>>();


        /// <summary>
        /// Method to convert an executable file icon to an ImageSource.
        /// </summary>
        /// <param name="culture"> The culture information (not used in this converter).</param>
        /// <param name="parameter"> The parameter (not used in this converter).</param>
        /// <param name="targetType"> The target type, expected to be ImageSource.</param>
        /// <param name="value"> The value to convert, expected to be a file path of an executable.</param>
        public object? Convert(object value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string path && File.Exists(path))
            {
                try
                {
                    using var icon = Icon.ExtractAssociatedIcon(path);
                    if (icon != null)
                    {
                        using var bmp = icon.ToBitmap();
                        using var ms = new MemoryStream();
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        ms.Seek(0, SeekOrigin.Begin);

                        var image = new BitmapImage();
                        image.BeginInit();
                        image.StreamSource = ms;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                        image.Freeze();
                        return image;
                    }
                }
                catch(Exception ex) { 
                    logger.Error("Error extracting icon from executable", ex);
                }
            }
            return null;
        }


        /// <summary>
        /// Method to convert back from ImageSource to the original value. (not used)
        /// </summary>
        /// <param name="value"> The value to convert back, expected to be an ImageSource.</param>
        /// <param name="targetType"> The target type, expected to be the original type (not used).</param>
        /// <param name="parameter"> The parameter (not used).</param>
        /// <param name="culture"> The culture information (not used).</param>
        public object? ConvertBack(object value, Type targetType, object? parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}