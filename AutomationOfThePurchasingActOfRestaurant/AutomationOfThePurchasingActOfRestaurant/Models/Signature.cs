using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Графическая подпись
    /// </summary>
    public sealed class Signature
    {
        /// <summary>
        /// Режим сглаживания <see cref="Graphics.SmoothingMode"/> для рисования подписи
        /// </summary>
        public static SmoothingMode SignatureSmoothingMode = SmoothingMode.AntiAlias;
        /// <summary>
        /// Точка, которая указывает на разрыв линии подписи
        /// </summary>
        public static Point ConnectionBreakpoint = new Point(int.MinValue, int.MinValue);
        /// <summary>
        /// Ширина ручки
        /// </summary>
        public static int PenWidth = 3;
        /// <summary>
        /// Ручка для подписи с шириной <see cref="PenWidth"/>
        /// </summary>
        public static Pen SignaturePen = new Pen(Color.Black, PenWidth);
        /// <summary>
        /// Точки из которых состоит подпись
        /// </summary>
        [Required]
        public readonly Point[] Points;
        /// <summary>
        /// Наименьшая координата Y <see cref="Signature"/>
        /// </summary>
        private int minY = 0;
        /// <summary>
        /// Наибольшая координата Y <see cref="Signature"/>
        /// </summary>
        private int maxY = 0;
        /// <summary>
        /// Наименьшая координата X <see cref="Signature"/>
        /// </summary>
        private int minX = 0;
        /// <summary>
        /// Наибольшая координата X <see cref="Signature"/>
        /// </summary>
        private int maxX = 0;

        /// <summary>
        /// Конструктор <see cref="Signature"/>
        /// </summary>
        /// <param name="points">
        /// <inheritdoc cref="Points" path="/summary"/>
        /// </param>
        public Signature(List<Point> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                // Определение крайних точек
                if (points[i] != ConnectionBreakpoint)
                {
                    if (points[i].X > maxX)
                    {
                        maxX = points[i].X;
                    }
                    else if (points[i].X < minX)
                    {
                        minX = points[i].X;
                    }

                    if (points[i].Y > maxY)
                    {
                        maxY = points[i].Y;
                    }
                    else if (points[i].Y < minY)
                    {
                        minY = points[i].Y;
                    }
                }

                //Удаление повторяющихся точек
                if ((i + 1 < points.Count) && (points[i] == points[i + 1]))
                {
                    points.RemoveAt(i);
                    i--;
                }
            }
            Points = new Point[points.Count];
            points.CopyTo(Points);
        }

        /// <summary>
        /// Рисует <see cref="Signature"/> на <see cref="Graphics"/> используя <see cref="Points"/>
        /// </summary>
        /// <param name="graphics">
        /// <see cref="Graphics"/>
        /// </param>
        /// <param name="signature" >
        /// <inheritdoc cref="Signature" path="/summary"/>
        /// </param>
        static public void DrawSignature(Graphics graphics, Signature signature, int? xOffset = null, int? yOffset = null)
        {
            xOffset ??= 0;
            yOffset ??= 0;
            int lastConnectionBreakpointIndex = 0;
            int lastOffset = +1;
            int nextOffset = -1;
            graphics.SmoothingMode = SignatureSmoothingMode;
            for (int nextConnectionBreakpoint = lastConnectionBreakpointIndex + 1; nextConnectionBreakpoint < signature.Points.Length; nextConnectionBreakpoint++)
            {
                if (signature.Points[nextConnectionBreakpoint] == ConnectionBreakpoint)
                {
                    Point[] submass = new Point[(nextConnectionBreakpoint + nextOffset) - (lastConnectionBreakpointIndex + lastOffset)];
                    CopyMassToMass(submass, 0, signature.Points, lastConnectionBreakpointIndex + lastOffset, submass.Length);
                    // Смещение точек
                    if ((xOffset != 0) && (yOffset != 0))
                    {
                        for (int i = 0; i < submass.Length; i++)
                        {
                            submass[i].X += (int)xOffset;
                            submass[i].Y += (int)yOffset;
                        }
                    }
                    graphics.DrawLines(SignaturePen, submass);
                    lastConnectionBreakpointIndex = nextConnectionBreakpoint;
                }
            }
        }

        /// <summary>
        /// Пропорцианально изменяет размер изображения. Если <paramref name="newHeight"/> и <paramref name="newWidth"/> непропорцианальны, то расчитывается новое значение меньшей из величин
        /// </summary>
        /// <param name="source">Изображение <see cref="Signature"/></param>
        /// <param name="newHeight">Новая высота изображения</param>
        /// <param name="newWidth">Новая ширина изображения</param>
        /// <returns>Изображение с изменённым размером</returns>
        static public Bitmap ProportionalResizingTheSignatureImage(Bitmap source, int newHeight, int newWidth)
        {
            float newImageHeight = newHeight;
            float newImageWidth = newWidth;
            float sourceProportion = (float)source.Width / source.Height;
            float newImageProportion = newImageWidth / newImageHeight;

            // Перерасчёт наименьщей стороны
            if (sourceProportion != newImageProportion)
            {
                if (newImageWidth > newImageHeight)
                {
                    newImageHeight = (newImageWidth * source.Height) / source.Width;
                }
                else
                {
                    newImageWidth = (source.Width * newImageHeight) / source.Height;
                }
            }

            Bitmap resizedImage = new Bitmap((int)newImageWidth, (int)newImageHeight);
            resizedImage.MakeTransparent();

            Graphics graphic = Graphics.FromImage(resizedImage);
            graphic.SmoothingMode = SignatureSmoothingMode;
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(source, 0, 0, newImageWidth, newImageHeight);

            return resizedImage;
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
        public Bitmap CreateSingatireBmpImage(bool isTransparentBackground)
        {
            int width = (maxX - minX) + PenWidth * 2;
            int height = (maxY - minY) + PenWidth * 2;
            int xOffset = PenWidth;
            int yOffset = PenWidth;
            Bitmap bitmap = new Bitmap(width, height);
            if (isTransparentBackground)
            {
                bitmap.MakeTransparent();
            }
            Graphics graphic = Graphics.FromImage(bitmap);
            DrawSignature(graphic, this, xOffset, yOffset);
            return bitmap;
        }

        /// <summary>
        /// Копирует массив в массив
        /// </summary>
        /// <typeparam name="T">Тип массива</typeparam>
        /// <param name="copyTo">Копирующий массив</param>
        /// <param name="copyToStartIndex">Индекс копирующего мссива с которого начинается копирование</param>
        /// <param name="copyFrom">Копируемый массив</param>
        /// <param name="copyFromStartIndex">Индекс копируемого массива с которого начинается копирование</param>
        /// <param name="count">количество элементов, которое нужно скопировать</param>
        static private void CopyMassToMass<T>(T[] copyTo, int copyToStartIndex, T[] copyFrom, int copyFromStartIndex, int count)
        {
            int currentCount = 0;
            for (int copyToIndex = copyToStartIndex, copyFromIndex = copyFromStartIndex; copyToIndex < copyFrom.Length; copyToIndex++, copyFromIndex++)
            {
                if (currentCount < count)
                {
                    copyTo[copyToIndex] = copyFrom[copyFromIndex];
                    currentCount++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
