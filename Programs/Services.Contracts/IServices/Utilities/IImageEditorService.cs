using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.Utilities;

/// <summary>
/// Интерфейс сервиса редактора изображений
/// </summary>
public interface IImageEditorService
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
    Task<Bitmap> ReducingTheSizeOfBmpImage(Bitmap source, int newHeight, int newWidth, bool isTransparent, bool isProportional, CancellationToken token);
}
