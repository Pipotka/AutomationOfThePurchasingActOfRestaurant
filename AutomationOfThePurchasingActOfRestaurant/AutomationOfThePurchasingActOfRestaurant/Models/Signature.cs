using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace AutomationOfThePurchasingActOfRestaurant.Models
{
    /// <summary>
    /// Графическая подпись
    /// </summary>
    public sealed class Signature
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid SignatureId { get; set; }
        /// <summary>
        /// <see cref="Approver"/> Id
        /// </summary>
        public Guid ApproverId { get; set; }
        /// <summary>
        /// <see cref="Approver"/>
        /// </summary>
        public Approver Approver { get; set; }
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
        /// Регулярное выражение для расшифровки подписи
        /// </summary>
        public static Regex RegularExpressionForSignatureDecryption = new Regex(@"^[A-ZА-Я]\\.?([A-ZА-Я]\\.)? [A-ZА-Я][a-zа-я]*$");
        /// <summary>
        /// Точки из которых состоит подпись
        /// </summary>
        [Required]
        public Point[] Points { get; set; }
        /// <summary>
        /// Расшифровка подписи
        /// </summary>
        [Required(ErrorMessage = "Необходима расшифровка подписи")]
        [RegularExpression(@"^[A-ZА-Я]\.?([A-ZА-Я]\.)? [A-ZА-Я][a-zа-я]*$"
, ErrorMessage = "Неправильная расшифровка подписи")]
        [Display(Name = "Расшифровка подписи")]
        public string SignatureDecryption { get; set; }
        /// <summary>
        /// Указывает на актуальность подписи. Если <c>False</c>, то подпись актуальна, если <c>True</c>, то это значит, что <see cref="Approver"/> поменял свою подпись
        /// </summary>
        public bool IsObsolete { get; set; } = false;
        /// <summary>
        /// Наименьшая координата Y <see cref="Points"/>
        /// </summary>
        private int minY = 0;
        /// <summary>
        /// Наибольшая координата Y <see cref="Points"/>
        /// </summary>
        private int maxY = 0;
        /// <summary>
        /// Наименьшая координата X <see cref="Points"/>
        /// </summary>
        private int minX = 0;
        /// <summary>
        /// Наибольшая координата X <see cref="Points"/>
        /// </summary>
        private int maxX = 0;

        /// <summary>
        /// Пустой конструктор <see cref="Signature"/>
        /// </summary>
        public Signature() { }

        /// <summary>
        /// Конструктор <see cref="Signature"/>
        /// </summary>
        /// <param name="points">
        /// <inheritdoc cref="Points" path="/summary"/>
        /// </param>
        /// <param name="signatureDecryption">
        /// <inheritdoc cref="SignatureDecryption" path="/summary"/>
        /// </param>
        public Signature(List<Point> points, string signatureDecryption)
        {
            Points = new Point[points.Count];
            points.CopyTo(Points);
            SignatureDecryption = signatureDecryption;
        }

        /// <summary>
        /// Конструктор <see cref="Signature"/>
        /// </summary>
        /// <param name="signature">
        /// <inheritdoc cref="Signature" path="/summary"/>
        /// </param>
        /// <param name="signatureDecryption">
        /// <inheritdoc cref="SignatureDecryption" path="/summary"/>
        /// </param>
        public Signature(Signature signature)
        {
            Points = (Point[])(signature.Points.Clone());
            SignatureDecryption = signature.SignatureDecryption;
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
                        for (var i = 0; i < submass.Length; i++)
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
        /// Определяет крайние точки <see cref="Points"/>
        /// </summary>
        private void DeterminationOfExtremePoints()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                if (Points[i] != ConnectionBreakpoint)
                {
                    if (Points[i].X > maxX)
                    {
                        maxX = Points[i].X;
                    }
                    else if (Points[i].X < minX)
                    {
                        minX = Points[i].X;
                    }

                    if (Points[i].Y > maxY)
                    {
                        maxY = Points[i].Y;
                    }
                    else if (Points[i].Y < minY)
                    {
                        minY = Points[i].Y;
                    }
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
        static public Bitmap ProportionalResizingTheBmpImage(Bitmap source, int newHeight, int newWidth)
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
            DeterminationOfExtremePoints();
            var width = (maxX - minX) + PenWidth * 2;
            var height = (maxY - minY) + PenWidth * 2;
            var xOffset = PenWidth;
            var yOffset = PenWidth;
            var bitmap = new Bitmap(width, height);
            if (isTransparentBackground)
            {
                bitmap.MakeTransparent();
            }
            var graphic = Graphics.FromImage(bitmap);
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
