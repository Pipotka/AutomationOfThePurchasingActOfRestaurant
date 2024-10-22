using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations.Interfaces;


/// <summary>
/// Интерфейс операций форматирования клеток Excel листа
/// </summary>
public interface IExcelCellFormattingOperations
{
    /// <summary>
    /// Создаёт экземпляр класса Border, используя переданные стороны границы.
    ///  Если какая-то сторона не указана, то она будет равна No border (по умолчанию)
    /// </summary>
    /// <param name="left">Левая граница</param>
    /// <param name="right">Правая граница</param>
    /// <param name="top">Верхняя граница</param>
    /// <param name="bottom">Нижняя граница</param>
    /// <param name="diagonal">Диагональная граница</param>
    /// <returns>Экземпляр класса Border</returns>
    public Border CreateBorder(LeftBorder? left = null, RightBorder? right = null,
                                      TopBorder? top = null, BottomBorder? bottom = null,
                                      DiagonalBorder? diagonal = null);

    /// <summary>
    /// Создаёт левую границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр LeftBorder</returns>
    public LeftBorder CreateLeftBorder(string colorHex = "000000");

    /// <summary>
    /// Создаёт левую границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр LeftBorder</returns>
    public LeftBorder CreateLeftBorder(BorderStyleValues style, string colorHex = "000000");

    /// <summary>
    /// Создаёт правую границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр RightBorder</returns>
    public RightBorder CreateRightBorder(string colorHex = "000000");

    /// <summary>
    /// Создаёт правую границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр RightBorder</returns>
    public RightBorder CreateRightBorder(BorderStyleValues style, string colorHex = "000000");

    /// <summary>
    /// Создаёт верхнюю границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр TopBorder</returns>
    public TopBorder CreateTopBorder(string colorHex = "000000");

    /// <summary>
    /// Создаёт верхнюю границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр TopBorder</returns>
    public TopBorder CreateTopBorder(BorderStyleValues style, string colorHex = "000000");

    /// <summary>
    /// Создаёт нижнюю границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр BottomBorder</returns>
    public BottomBorder CreateBottomBorder(string colorHex = "000000");

    /// <summary>
    /// Создаёт нижнюю границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр BottomBorder</returns>
    public BottomBorder CreateBottomBorder(BorderStyleValues style, string colorHex = "000000");

    /// <summary>
    /// Создаёт диагональную границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр DiagonalBorder</returns>
    public DiagonalBorder CreateDiagonalBorder(string colorHex = "000000");

    /// <summary>
    /// Создаёт диагональную границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр DiagonalBorder</returns>
    public DiagonalBorder CreateDiagonalBorder(BorderStyleValues style, string colorHex = "000000");

    /// <summary>
    /// Создаёт выравнивание
    /// </summary>
    /// <param name="horizontalAlignment">Горизонтальное выравнивание</param>
    /// <param name="verticalAlignment">Вертикальное выравнивание</param>
    /// <param name="isWrapText">Перенос текста</param>
    /// <param name="isShrinkToFit">Уменьшение текста если не помещается в клетку</param>
    public Alignment CreateAlignment(
        HorizontalAlignmentValues horizontalAlignment,
        VerticalAlignmentValues verticalAlignment,
        bool isWrapText = false,
        bool isShrinkToFit = false);

    /// <summary>
    /// Создаёт шрифт
    /// </summary>
    /// <param name="fontName">Название шрифта</param>
    /// <param name="fontSize">Размер шрифта</param>
    /// <param name="isBold">Жирный шрифт</param>
    /// <param name="isItalic">Курсив</param>
    /// <param name="isUnderline">Подчеркивание</param>
    /// <param name="colorHex">Цвет в формате HEX</param>
    public Font CreateFont(
        string fontName,
        double fontSize,
        bool isBold = false,
        bool isItalic = false,
        bool isUnderline = false,
        string colorHex = "000000");

    /// <summary>
    /// Создаёт CellFormat с указанными параметрами Border, Alignment и Font.
    /// </summary>
    /// <param name="border">Граница для ячейки (Border). Может быть null, если границы не нужны.</param>
    /// <param name="alignment">Выравнивание для ячейки (Alignment). Может быть null, если не требуется выравнивание.</param>
    /// <param name="font">Шрифт для ячейки (Font). Может быть null, если шрифт не нужен.</param>
    /// <returns>Индекс CellFormat(формата ячейки)</returns>
    public uint CreateCellFormat(SpreadsheetDocument document,
        Border border = null,
        Alignment alignment = null,
        Font font = null);

    /// <summary>
    /// Применяет формат клетки
    /// </summary>
    /// <param name="cellFormatIndex">индекс формата клетки</param>
    public Cell ApplyCellFormat(Cell cell, uint cellFormatIndex);
}
