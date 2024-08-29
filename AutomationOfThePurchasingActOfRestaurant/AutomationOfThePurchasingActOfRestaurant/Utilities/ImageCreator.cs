using System.Drawing;
using AutomationOfThePurchasingActOfRestaurant.Models;

namespace AutomationOfThePurchasingActOfRestaurant.Utilities
{
    /// <summary>
    /// Создаватель изображений
    /// </summary>
    public static class ImageCreator
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
        public static Bitmap CreateSingatireBmpImage(
            Signature signature,
            bool isTransparentBackground)
        {
            var width = (signature.GetMaxX() - signature.GetMinX()) + Signature.PenWidth * 2;
            var height = (signature.GetMaxY() - signature.GetMinY()) + Signature.PenWidth * 2;
            var xOffset = Signature.PenWidth;
            var yOffset = Signature.PenWidth;
            var signatureImage = new Bitmap(width, height);
            if (isTransparentBackground)
            {
                signatureImage.MakeTransparent();
            }
            var graphic = Graphics.FromImage(signatureImage);
            Signature.DrawSignature(graphic, signature, xOffset, yOffset);

            return signatureImage;
        }
    }
}
