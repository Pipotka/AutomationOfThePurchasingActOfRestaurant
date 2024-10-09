using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations.Interfaces;

/// <summary>
/// Интерфейс операций на Excel листом
/// </summary>
public interface IExcelSheetOperations
{
    /// <summary>
    /// Создаёт строку
    /// </summary>
    /// <param name="rowIndex">индекс строки</param>
    public Row FindOrCreateRow(WorksheetPart worksheetPart, uint rowIndex);

    /// <summary>
    /// Создаёт клетку
    /// </summary>
    /// <param name="CellReference">
    /// Ссылка на клетку
    /// </param>
    public Cell FindOrCreateCell(WorksheetPart worksheetPart, string CellReference);

    /// <summary>
    /// Создаёт клетку
    /// </summary>
    /// <param name="CellReference">
    /// Ссылка на клетку
    /// </param>
    public Cell FindOrCreateCell(Row row, string CellReference);

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
        string lowerRightCellReference);

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
        string CellRangeReference);

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
        int imageHeight);
}
