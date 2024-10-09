
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using System.Drawing;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.Utilities;

/// <summary>
/// Интерфейс сервиса создания изображений
/// </summary>
public interface IImageCreatorService
{
    /// <summary>
    /// Создаёт Bmp изображение <see cref="Signature"/>
    /// </summary>
    /// <param name="isTransparentBackground">
    /// Указывает будет ли фон прозрачный
    /// </param>
    /// <returns>
    /// Bmp изображение <see cref="Signature"/>
    /// </returns>
    Task<Bitmap> CreateSingatireBmpImage(Guid id, bool isTransparentBackground, CancellationToken token);

    /// <summary>
    /// Создаёт Bmp изображение <see cref="Signature"/>
    /// </summary>
    /// <param name="isTransparentBackground">
    /// Указывает будет ли фон прозрачный
    /// </param>
    /// <returns>
    /// Bmp изображение <see cref="Signature"/>
    /// </returns>
    Task<Bitmap> CreateSingatireBmpImage(Signature signature, bool isTransparentBackground, CancellationToken token);
}
