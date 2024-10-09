using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;

/// <summary>
/// Графическая подпись
/// </summary>
public sealed class Signature : IBaseEntity, ISoftDelited
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
    /// Регулярное выражение для расшифровки подписи
    /// </summary>
    public static Regex RegularExpressionForSignatureDecryption = new Regex(@"^[A-ZА-Я]\\.?([A-ZА-Я]\\.)? [A-ZА-Я][a-zа-я]*$");
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Закупочные акты
    /// </summary>
    public ICollection<PurchaseForm> purchaseForms { get; set; } = new List<PurchaseForm>();
    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime DateOfCreation { get; set; }
    /// <summary>
    /// Дата последнего изменения
    /// </summary>
    public DateTime DateOfLastChange { get; set; }
    /// <summary>
    /// <see cref="Approver"/> Id
    /// </summary>
    public Guid? ApproverId { get; set; }
    /// <summary>
    /// Утверждающий
    /// </summary>
    public Approver? Approver { get; set; }
    /// <summary>
    /// Точки из которых состоит подпись
    /// </summary>
    [Required]
    public Point[] Points {  get; set; }
    /// <summary>
    /// Расшифровка подписи
    /// </summary>
    public string SignatureDecryption { get; set; }
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
    /// <inheritdoc cref="ISoftDelited.DateOfDeletion" path="/summary"/>
    /// </summary>
    public DateTime DateOfDeletion { get; set; }
    /// <summary>
    /// <inheritdoc cref="ISoftDelited.IsDelited" path="/summary"/>
    /// </summary>
    public bool IsDelited { get; set; } = false;

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
    /// Рисует <see cref="Signature"/> на <see cref="Graphics"/>
    /// </summary>
    /// <param name="graphics">
    /// <see cref="Graphics"/>
    /// </param>
    /// <param name="signature" >
    /// <inheritdoc cref="Signature" path="/summary"/>
    /// </param>
    /// <param name="xOffset">Смещение по X</param>
    /// <param name="yOffset">Смещение по Y</param>
    static public void DrawSignature(Graphics graphics, Signature signature, int xOffset = 0, int yOffset = 0)
    {
        int lastConnectionBreakpointIndex = 0;
        int lastOffset = +1;
        int nextOffset = -1;
        graphics.SmoothingMode = SignatureSmoothingMode;
        for (int nextConnectionBreakpoint = lastConnectionBreakpointIndex + 1; nextConnectionBreakpoint < signature.Points.Length; nextConnectionBreakpoint++)
        {
            if (signature.Points[nextConnectionBreakpoint] == ConnectionBreakpoint)
            {
                Point[] submass = new Point[(nextConnectionBreakpoint + nextOffset) - (lastConnectionBreakpointIndex + lastOffset)];
                Array.Copy(signature.Points, lastConnectionBreakpointIndex + lastOffset, submass, 0, submass.Length);
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
        var filteredPoints = Points.Where(p => p != ConnectionBreakpoint);
        maxX = filteredPoints.Max(x => x.X);
        minX = filteredPoints.Min(x => x.X);
        maxY = filteredPoints.Max(x => x.Y);
        minY = filteredPoints.Min(x => x.Y);
    }

    /// <summary>
    /// Возвращает наименьшую координату Y из <see cref="Points"/>
    /// </summary>
    /// <returns>Наименьшая координата Y из <see cref="Points"/></returns>
    public int GetMinY() => minY;
    /// <summary>
    /// Возвращает наибольшую координату Y из <see cref="Points"/>
    /// </summary>
    /// <returns>Наибольшая координата Y из <see cref="Points"/></returns>
    public int GetMaxY() => maxY;
    /// <summary>
    /// Возвращает наименьшую координату X из <see cref="Points"/>
    /// </summary>
    /// <returns>Наименьшая координата X из <see cref="Points"/></returns>
    public int GetMinX() => minX;
    /// <summary>
    /// Возвращает наибольшую координату X из <see cref="Points"/>
    /// </summary>
    /// <returns>Наибольшая координата X из <see cref="Points"/></returns>
    public int GetMaxX() => maxX;
}
