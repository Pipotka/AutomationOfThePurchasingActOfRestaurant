using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.Utilities;
using System.Drawing;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Utilities.Image;

/// <summary>
/// Сервис создания изображений
/// </summary>
public class ImageCreatorService : IImageCreatorService
{
    private readonly ISignatureReadRepository signatureReadRepository;

    public ImageCreatorService(ISignatureReadRepository signatureReadRepository)
    {
        this.signatureReadRepository = signatureReadRepository;
    }

    /// <summary>
    /// Создаёт Bmp изображение <see cref="Signature"/>
    /// </summary>
    /// <param name="isTransparentBackground">
    /// Указывает будет ли фон прозрачный
    /// </param>
    /// <returns>
    /// Bmp изображение <see cref="Signature"/>
    /// </returns>
    public async Task<Bitmap> CreateSingatireBmpImage(Guid id, bool isTransparentBackground, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        var signature = await signatureReadRepository.GetAsync(id, token);
        if (signature == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<Signature>(id);
        }

        token.ThrowIfCancellationRequested();

        var width = signature.GetMaxX() - signature.GetMinX() + Signature.PenWidth * 2;
        var height = signature.GetMaxY() - signature.GetMinY() + Signature.PenWidth * 2;
        var xOffset = Signature.PenWidth;
        var yOffset = Signature.PenWidth;

        token.ThrowIfCancellationRequested();

        var signatureImage = new Bitmap(width, height);

        if (isTransparentBackground)
        {
            token.ThrowIfCancellationRequested();

            signatureImage.MakeTransparent();
        }

        token.ThrowIfCancellationRequested();

        var graphic = Graphics.FromImage(signatureImage);
        Signature.DrawSignature(graphic, signature, xOffset, yOffset);

        token.ThrowIfCancellationRequested();

        return await Task.FromResult(signatureImage);
    }

    /// <summary>
    /// Создаёт Bmp изображение <see cref="Signature"/>
    /// </summary>
    /// <param name="isTransparentBackground">
    /// Указывает будет ли фон прозрачный
    /// </param>
    /// <returns>
    /// Bmp изображение <see cref="Signature"/>
    /// </returns>
    public async Task<Bitmap> CreateSingatireBmpImage(Signature signature, bool isTransparentBackground, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();

        var width = signature.GetMaxX() - signature.GetMinX() + Signature.PenWidth * 2;
        var height = signature.GetMaxY() - signature.GetMinY() + Signature.PenWidth * 2;
        var xOffset = Signature.PenWidth;
        var yOffset = Signature.PenWidth;

        token.ThrowIfCancellationRequested();

        var signatureImage = new Bitmap(width, height);

        if (isTransparentBackground)
        {
            token.ThrowIfCancellationRequested();

            signatureImage.MakeTransparent();
        }

        token.ThrowIfCancellationRequested();

        var graphic = Graphics.FromImage(signatureImage);
        Signature.DrawSignature(graphic, signature, xOffset, yOffset);

        token.ThrowIfCancellationRequested();

        return await Task.FromResult(signatureImage);
    }
}
