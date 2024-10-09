using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Utilities.Image;

/// <summary>
/// Сервис редактора изображений
/// </summary>
public class ImageEditorService : IImageEditorService
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
    /// Указывает нужно ли изменить изображение пропорционально.
    /// если <c>True</c> то стороны изменённого изображения 
    /// будут пропорциональны сторонам исходного изображения
    /// </param>
    /// <returns>Уменьшенное изображение</returns>
    public Task<Bitmap> ReducingTheSizeOfBmpImage(Bitmap source, int newHeight, int newWidth, bool isTransparent, bool isProportional, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

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

        token.ThrowIfCancellationRequested();

        Bitmap resizedImage = new Bitmap((int)newImageWidth, (int)newImageHeight);
        if (isTransparent)
        {
            token.ThrowIfCancellationRequested();

            resizedImage.MakeTransparent();
        }

        token.ThrowIfCancellationRequested();

        Graphics graphic = Graphics.FromImage(resizedImage);
        graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

        token.ThrowIfCancellationRequested();

        graphic.DrawImage(source, 0, 0, newImageWidth, newImageHeight);

        token.ThrowIfCancellationRequested();

        return Task.FromResult(resizedImage);
    }
}
