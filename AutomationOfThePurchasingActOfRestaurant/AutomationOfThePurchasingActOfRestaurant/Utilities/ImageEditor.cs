using System.Drawing.Drawing2D;
using System.Drawing;

namespace AutomationOfThePurchasingActOfRestaurant.Utilities
{
    /// <summary>
    /// Редактор изображений
    /// </summary>
    public static class ImageEditor
    {
        /// <summary>
        /// Уменьшает размер изображения.
        /// </summary>
        /// <param name="source">Исходное изображение</param>
        /// <param name="newHeight">Новая высота изображения</param>
        /// <param name="newWidth">Новая ширина изображения</param>
        /// <param name="isTransparent">
        /// Указывает на то, нужно ли делать задний фон прозрачным.
        /// если <c>True</c> то фон будет прозрачным.
        /// </param>
        /// <param name="isProportional">
        /// Указывает на то, нужно ли изменить изображение пропорционально.
        /// если <c>True</c> то стороны изменённого изображения 
        /// будут пропорциональны сторонам исходного изображения
        /// </param>
        /// <returns>Уменьшенное изображение</returns>
        static public Bitmap ReducingTheSizeOfBmpImage(Bitmap source,
            int newHeight, int newWidth, bool isTransparent,
            bool isProportional)
        {
            float newImageHeight = newHeight;
            float newImageWidth = newWidth;
            if (isProportional)
            {
                float sourceProportion = (float)source.Width / source.Height;
                float newImageProportion = newImageWidth / newImageHeight;

                // Перерасчёт наименьшей стороны
                if (sourceProportion != newImageProportion)
                {
                    if (newImageWidth > newImageHeight)
                    {
                        newImageHeight = newImageWidth * source.Height / source.Width;
                    }
                    else
                    {
                        newImageWidth = source.Width * newImageHeight / source.Height;
                    }
                }
            }

            Bitmap resizedImage = new Bitmap((int)newImageWidth, (int)newImageHeight);
            if (isTransparent)
            {
                resizedImage.MakeTransparent();
            }

            Graphics graphic = Graphics.FromImage(resizedImage);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(source, 0, 0, newImageWidth, newImageHeight);

            return resizedImage;
        }
    }
}
