using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Drawing;
using Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations.Interfaces;

namespace Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations;

/// <summary>
/// Операции на Excel листом
/// </summary>
public class ExcelSheetOperations : IExcelSheetOperations
{
    /// <summary>
    /// Создаёт строку
    /// </summary>
    /// <param name="rowIndex">индекс строки</param>
    public Row FindOrCreateRow(WorksheetPart worksheetPart, uint rowIndex)
    {
        var sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
        Row row = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex);

        if (row == null)
        {
            row = new Row()
            {
                RowIndex = rowIndex,
            };
            sheetData.Append(row);
        }

        return row;
    }

    /// <summary>
    /// Создаёт клетку
    /// </summary>
    /// <param name="CellReference">
    /// Ссылка на клетку
    /// </param>
    public Cell FindOrCreateCell(WorksheetPart worksheetPart, string CellReference)
    {
        var cellIndexes = GetIndexesFromCellReference(CellReference);
        Row row = PrivFindOrCreateRow(worksheetPart, cellIndexes.rowIndex);
        var cell = PrivFindOrCreateCell(row, CellReference);

        return cell;
    }

    /// <summary>
    /// Создаёт клетку
    /// </summary>
    /// <param name="CellReference">
    /// Ссылка на клетку
    /// </param>
    public Cell FindOrCreateCell(Row row, string CellReference)
    {
        Cell cell = row.Elements<Cell>().FirstOrDefault(c => c.CellReference == CellReference);
        if (cell == null)
        {
            cell = new Cell()
            {
                CellReference = CellReference,
            };
            row.Append(cell);
        }

        return cell;
    }

    /// <summary>
    /// Создание диапазона клеток
    /// </summary>
    /// <param name="topLeftCellReference">
    /// 
    /// </param>
    /// <param name="lowerRightCellReference">
    /// 
    /// </param>
    public WorksheetPart CreateRangeCells(WorksheetPart worksheetPart,
        string topLeftCellReference,
        string lowerRightCellReference)
    {
        var topLeftCellIndexes = GetIndexesFromCellReference(topLeftCellReference);
        var lowerRightCellIndexes = GetIndexesFromCellReference(lowerRightCellReference);

        for (uint rowIndex = topLeftCellIndexes.rowIndex; rowIndex <= lowerRightCellIndexes.rowIndex; rowIndex++)
        {
            var row = PrivFindOrCreateRow(worksheetPart, rowIndex);

            for (uint columnIndex = topLeftCellIndexes.columnIndex; columnIndex <= lowerRightCellIndexes.columnIndex; columnIndex++)
            {
                var columnName = GetColumnName(columnIndex);
                var cellReference = columnName + rowIndex.ToString();
                PrivFindOrCreateCell(row, cellReference);
            }
        }

        return worksheetPart;
    }

    /// <summary>
    /// Создание диапазона клеток
    /// </summary>
    /// <param name="topLeftCellReference">
    /// 
    /// </param>
    /// <param name="lowerRightCellReference">
    /// 
    /// </param>
    public WorksheetPart CreateRangeCells(WorksheetPart worksheetPart,
        string CellRangeReference)
    {
        var references = CellRangeReference.Split(":");
        var topLeftCellReference = references[0];
        var lowerRightCellReference = references[1];
        var topLeftCellIndexes = GetIndexesFromCellReference(topLeftCellReference);
        var lowerRightCellIndexes = GetIndexesFromCellReference(lowerRightCellReference);

        for (uint rowIndex = topLeftCellIndexes.rowIndex; rowIndex <= lowerRightCellIndexes.rowIndex; rowIndex++)
        {
            var row = PrivFindOrCreateRow(worksheetPart, rowIndex);

            for (uint columnIndex = topLeftCellIndexes.columnIndex; columnIndex <= lowerRightCellIndexes.columnIndex; columnIndex++)
            {
                var columnName = GetColumnName(columnIndex);
                var cellReference = columnName + rowIndex.ToString();
                PrivFindOrCreateCell(row, cellReference);
            }
        }

        return worksheetPart;
    }

    /// <summary>
    /// Добавляет изображение на лист
    /// </summary>
    /// <param name="worksheetPart"></param>
    /// <param name="image">изображение</param>
    /// <param name="pictureName">название изображения</param>
    /// <param name="pictureId">Id изображения</param>
    /// <param name="startCellReference">
    /// Самая крайняя левая верхняя клетка, на которой "лежит" изображение
    /// </param>
    /// <param name="endCellReference">
    /// Самая крайняя правая нижняя клетка, на которой "лежит" изображение
    /// </param>
    /// <param name="PixelOffsetFromTheStartCell">
    /// Смещение изображения относительно левого верхнего угла <paramref name="startCellReference"/>
    /// </param>
    /// <param name="PixelOffsetFromTheEndCell">
    /// Смещение изображения относительно левого верхнего угла <paramref name="endCellReference"/>
    /// </param>
    /// <param name="imageWidth">
    /// Ширина изображения
    /// </param>
    /// <param name="imageHeight">
    /// Высота изображения
    /// </param>
    public void InsertImageInList(WorksheetPart worksheetPart,
        Bitmap image,
        string pictureName,
        uint pictureId,
        string startCellReference,
        string endCellReference,
        (uint columnOffset, uint rowOffset) PixelOffsetFromTheStartCell,
        (uint columnOffset, uint rowOffset) PixelOffsetFromTheEndCell,
        int imageWidth,
        int imageHeight)
    {
        var startCellIndexes = GetIndexesFromCellReference(startCellReference);
        var endCellIndexes = GetIndexesFromCellReference(endCellReference);
        DrawingsPart drawingsPart;
        if (worksheetPart.DrawingsPart == null)
        {
            drawingsPart = worksheetPart.AddNewPart<DrawingsPart>();
            worksheetPart.Worksheet.Append(new Drawing() { Id = worksheetPart.GetIdOfPart(drawingsPart) });
        }
        else
        {
            drawingsPart = worksheetPart.DrawingsPart;
        }

        ImagePart imagePart = drawingsPart.AddImagePart(ImagePartType.Png);

        using (MemoryStream stream = new MemoryStream())
        {
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Position = 0;
            imagePart.FeedData(stream);
        }

        long extentsCx = imageWidth * 9525L;
        long extentsCy = imageHeight * 9525L;

        WorksheetDrawing worksheetDrawing = drawingsPart.WorksheetDrawing ?? new WorksheetDrawing();
        TwoCellAnchor twoCellAnchor = new TwoCellAnchor(
            new DocumentFormat.OpenXml.Drawing.Spreadsheet.FromMarker(new ColumnId(startCellIndexes.columnIndex.ToString()),
            new ColumnOffset(PixelOffsetFromTheStartCell.columnOffset.ToString()),
            new RowId(startCellIndexes.rowIndex.ToString()),
            new RowOffset(PixelOffsetFromTheStartCell.rowOffset.ToString())),
            new DocumentFormat.OpenXml.Drawing.Spreadsheet.ToMarker(new ColumnId(endCellIndexes.columnIndex.ToString()),
            new ColumnOffset(PixelOffsetFromTheEndCell.columnOffset.ToString()),
            new RowId(endCellIndexes.rowIndex.ToString()),
            new RowOffset(PixelOffsetFromTheEndCell.rowOffset.ToString())),
            new DocumentFormat.OpenXml.Drawing.Spreadsheet.Picture(
                new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualPictureProperties(
                    new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualDrawingProperties() { Id = pictureId, Name = pictureName },
                    new DocumentFormat.OpenXml.Drawing.Spreadsheet.NonVisualPictureDrawingProperties(new PictureLocks() { NoChangeAspect = true })),
                new DocumentFormat.OpenXml.Drawing.Spreadsheet.BlipFill(new Blip() { Embed = drawingsPart.GetIdOfPart(imagePart), CompressionState = BlipCompressionValues.Print },
                    new Stretch(new FillRectangle())),
                new DocumentFormat.OpenXml.Drawing.Spreadsheet.ShapeProperties(new Transform2D(new Offset() { X = 0, Y = 0 }, new Extents() { Cx = extentsCx, Cy = extentsCy }),
                    new PresetGeometry(new AdjustValueList()) { Preset = ShapeTypeValues.Rectangle }))
            );

        worksheetDrawing.Append(twoCellAnchor);
        drawingsPart.WorksheetDrawing = worksheetDrawing;
        worksheetDrawing.Save(drawingsPart);
    }

    /// <summary>
    /// Создаёт клетку
    /// </summary>
    /// <param name="CellReference">
    /// Ссылка на клетку
    /// </param>
    private static Cell PrivFindOrCreateCell(Row row, string CellReference)
    {
        Cell cell = row.Elements<Cell>().FirstOrDefault(c => c.CellReference == CellReference);
        if (cell == null)
        {
            cell = new Cell()
            {
                CellReference = CellReference,
            };
            row.Append(cell);
        }

        return cell;
    }

    /// <summary>
    /// Создаёт строку
    /// </summary>
    /// <param name="rowIndex">индекс строки</param>
    private static Row PrivFindOrCreateRow(WorksheetPart worksheetPart, uint rowIndex)
    {
        var sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
        Row row = sheetData.Elements<Row>().FirstOrDefault(r => r.RowIndex == rowIndex);

        if (row == null)
        {
            row = new Row()
            {
                RowIndex = rowIndex,
            };
            sheetData.Append(row);
        }

        return row;
    }

    /// <summary>
    /// Возвращает строку в виде CellReference
    /// </summary>
    /// <param name="columnIndex">числовой индекс</param>
    /// <returns>строковый индекс</returns>
    private string GetColumnName(uint columnIndex)
    {
        string columnName = string.Empty;
        uint dividend = columnIndex;
        while (dividend > 0)
        {
            uint modulo = (dividend - 1) % 26;
            columnName = Convert.ToChar(65 + modulo) + columnName;
            dividend = (dividend - modulo) / 26;
        }
        return columnName;
    }

    /// <summary>
    /// Возвращает числовые индексы строки и столбца из CellReference.
    /// </summary>
    /// <param name="cellReference">Строковое значение ссылки на ячейку, например "B2".</param>
    /// <returns>Кортеж с числовыми индексами столбца и строки.</returns>
    private (uint columnIndex, uint rowIndex) GetIndexesFromCellReference(string cellReference)
    {
        // Инициализация индексов
        uint columnIndex = 0;
        uint rowIndex = 0;

        // Разделение строковой ссылки на буквы (столбец) и числа (строка)
        string columnLetters = string.Empty;
        string rowNumbers = string.Empty;

        foreach (char ch in cellReference)
        {
            if (char.IsDigit(ch))
            {
                rowNumbers += ch;
            }
            else
            {
                columnLetters += ch;
            }
        }

        // Конвертация букв в числовой индекс для столбца
        for (int i = 0; i < columnLetters.Length; i++)
        {
            columnIndex *= 26;
            columnIndex += (uint)(columnLetters[i] - 'A' + 1);
        }

        // Конвертация строки в числовой индекс для строки
        rowIndex = uint.Parse(rowNumbers);

        return (columnIndex, rowIndex);
    }
}
