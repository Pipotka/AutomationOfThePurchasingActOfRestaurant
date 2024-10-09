using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations.Interfaces;

namespace Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations;

/// <summary>
/// Операции форматирование клеток Excel листа
/// </summary>
public class ExcelCellFormattingOperations : IExcelCellFormattingOperations
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
                                      DiagonalBorder? diagonal = null)
    {
        left ??= CreateLeftBorder(BorderStyleValues.None);
        right ??= CreateRightBorder(BorderStyleValues.None);
        top ??= CreateTopBorder(BorderStyleValues.None);
        bottom ??= CreateBottomBorder(BorderStyleValues.None);
        diagonal ??= CreateDiagonalBorder(BorderStyleValues.None);
        var result = new Border()
        {
            LeftBorder = left.CloneNode(true) as LeftBorder,
            RightBorder = right.CloneNode(true) as RightBorder,
            TopBorder = top.CloneNode(true) as TopBorder,
            BottomBorder = bottom.CloneNode(true) as BottomBorder,
            DiagonalBorder = diagonal.CloneNode(true) as DiagonalBorder
        };
        return result;
    }

    /// <summary>
    /// Создаёт левую границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр LeftBorder</returns>
    public LeftBorder CreateLeftBorder(string colorHex = "000000")
    {
        var style = BorderStyleValues.None;

        return CreateLeftBorder(style, colorHex);
    }

    /// <summary>
    /// Создаёт левую границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр LeftBorder</returns>
    public LeftBorder CreateLeftBorder(BorderStyleValues style, string colorHex = "000000")
    {
        LeftBorder leftBorder = new LeftBorder() { Style = style };
        if (!string.IsNullOrEmpty(colorHex))
        {
            leftBorder.Color = new Color() { Rgb = new HexBinaryValue(colorHex) };
        }
        return leftBorder;
    }

    /// <summary>
    /// Создаёт правую границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр RightBorder</returns>
    public RightBorder CreateRightBorder(string colorHex = "000000")
    {
        var style = BorderStyleValues.None;

        return CreateRightBorder(style, colorHex);
    }

    /// <summary>
    /// Создаёт правую границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр RightBorder</returns>
    public RightBorder CreateRightBorder(BorderStyleValues style, string colorHex = "000000")
    {
        RightBorder rightBorder = new RightBorder() { Style = style };
        if (!string.IsNullOrEmpty(colorHex))
        {
            rightBorder.Color = new Color() { Rgb = new HexBinaryValue(colorHex) };
        }
        return rightBorder;
    }

    /// <summary>
    /// Создаёт верхнюю границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр TopBorder</returns>
    public TopBorder CreateTopBorder(string colorHex = "000000")
    {
        var style = BorderStyleValues.None;

        return CreateTopBorder(style, colorHex);
    }

    /// <summary>
    /// Создаёт верхнюю границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр TopBorder</returns>
    public TopBorder CreateTopBorder(BorderStyleValues style, string colorHex = "000000")
    {
        TopBorder topBorder = new TopBorder() { Style = style };
        if (!string.IsNullOrEmpty(colorHex))
        {
            topBorder.Color = new Color() { Rgb = new HexBinaryValue(colorHex) };
        }
        return topBorder;
    }

    /// <summary>
    /// Создаёт нижнюю границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр BottomBorder</returns>
    public BottomBorder CreateBottomBorder(string colorHex = "000000")
    {
        var style = BorderStyleValues.None;

        return CreateBottomBorder(style, colorHex);
    }

    /// <summary>
    /// Создаёт нижнюю границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр BottomBorder</returns>
    public BottomBorder CreateBottomBorder(BorderStyleValues style, string colorHex = "000000")
    {
        BottomBorder bottomBorder = new BottomBorder() { Style = style };
        if (!string.IsNullOrEmpty(colorHex))
        {
            bottomBorder.Color = new Color() { Rgb = new HexBinaryValue(colorHex) };
        }
        return bottomBorder;
    }

    /// <summary>
    /// Создаёт диагональную границу с опциональным цветом.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <returns>Экземпляр DiagonalBorder</returns>
    public DiagonalBorder CreateDiagonalBorder(string colorHex = "000000")
    {
        var style = BorderStyleValues.None;

        return CreateDiagonalBorder(style, colorHex);
    }

    /// <summary>
    /// Создаёт диагональную границу с опциональными цветом и стилем.
    /// </summary>
    /// <param name="colorHex">Цвет в формате hex</param>
    /// <param name="style">Стиль границы</param>
    /// <returns>Экземпляр DiagonalBorder</returns>
    public DiagonalBorder CreateDiagonalBorder(BorderStyleValues style, string colorHex = "000000")
    {
        DiagonalBorder diagonalBorder = new DiagonalBorder() { Style = style };
        if (!string.IsNullOrEmpty(colorHex))
        {
            diagonalBorder.Color = new Color() { Rgb = new HexBinaryValue(colorHex) };
        }
        return diagonalBorder;
    }

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
        bool isShrinkToFit = false)
    {
        return new Alignment()
        {
            Horizontal = horizontalAlignment,
            Vertical = verticalAlignment,
            WrapText = isWrapText,
            ShrinkToFit = isShrinkToFit,
            TextRotation = 0
        };
    }

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
        string colorHex = "000000")
    {
        var font = new Font();

        font.Append(new FontName() { Val = fontName });

        font.Append(new FontSize() { Val = fontSize });

        if (!string.IsNullOrEmpty(colorHex))
        {
            font.Append(new Color() { Rgb = new HexBinaryValue(colorHex) });
        }

        if (isBold)
        {
            font.Append(new Bold());
        }

        if (isItalic)
        {
            font.Append(new Italic());
        }

        if (isUnderline)
        {
            font.Append(new Underline());
        }

        return font;
    }

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
        Font font = null)
    {
        var stylesheet = document.WorkbookPart.WorkbookStylesPart.Stylesheet;

        CellFormat cellFormat = new CellFormat();

        if (border != null)
        {
            Border existingBorder = null;
            uint borderIndex = 0;

            foreach (var b in stylesheet.Borders.Elements<Border>())
            {
                if (b.OuterXml == border.OuterXml)
                {
                    existingBorder = b;
                    break;
                }
                borderIndex++;
            }

            if (existingBorder != null)
            {
                cellFormat.BorderId = borderIndex;
            }
            else
            {
                stylesheet.Borders.Append(border);
                borderIndex = (uint)(stylesheet.Borders.ChildElements.Count - 1);
                cellFormat.BorderId = borderIndex;
                stylesheet.Borders.Count = (uint)stylesheet.Borders.ChildElements.Count;
            }
            cellFormat.ApplyBorder = true;
        }

        if (font != null)
        {
            Font existingFont = null;
            uint fontIndex = 0;

            foreach (var f in stylesheet.Fonts.Elements<Font>())
            {
                if (f.OuterXml == font.OuterXml)
                {
                    existingFont = f;
                    break;
                }
                fontIndex++;
            }

            if (existingFont != null)
            {
                cellFormat.FontId = fontIndex;
            }
            else
            {
                stylesheet.Fonts.Append(font);
                fontIndex = (uint)(stylesheet.Fonts.ChildElements.Count - 1);
            }

            stylesheet.Fonts.Count = (uint)stylesheet.Fonts.ChildElements.Count;

            cellFormat.FontId = fontIndex;
            cellFormat.ApplyFont = true;
        }

        if (alignment != null)
        {
            cellFormat.Alignment = alignment.CloneNode(true) as Alignment;
            cellFormat.ApplyAlignment = true;
        }


        uint cellFormatIndex = 0;
        CellFormat existingCellFormat = null;

        foreach (var cf in stylesheet.CellFormats.Elements<CellFormat>())
        {
            if (cf.OuterXml == cellFormat.OuterXml)
            {
                existingCellFormat = cf;
                break;
            }
            cellFormatIndex++;
        }

        if (existingCellFormat != null)
        {
            return cellFormatIndex;
        }

        cellFormatIndex = (uint)stylesheet.CellFormats.ChildElements.Count;
        stylesheet.CellFormats.Append(cellFormat);
        stylesheet.CellFormats.Count = (uint)stylesheet.CellFormats.ChildElements.Count;

        return cellFormatIndex;
    }

    /// <summary>
    /// Применяет формат клетки
    /// </summary>
    /// <param name="cellFormatIndex">индекс формата клетки</param>
    public Cell ApplyCellFormat(Cell cell, uint cellFormatIndex)
    {
        cell.StyleIndex = cellFormatIndex;

        return cell;
    }
}
