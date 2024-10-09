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
/// Интерфейс операций над клетками Excel листа
/// </summary>
public interface IExcelCellOperations
{
    /// <summary>
    /// Вставляет значение в клетку
    /// </summary>
    /// <param name="data">значение</param>
    /// <param name="CellReference">
    /// Ссылка на клетку
    /// </param>
    public Cell InsertDataIntoCell(WorksheetPart worksheetPart, string CellReference, string data);

    /// <summary>
    /// Вставляет значение в клетку
    /// </summary>
    /// <param name="data">значение</param>
    /// <returns></returns>
    public Cell InsertDataIntoCell(Cell cell, string data);

    /// <summary>
    /// Вставляет значение в клетку
    /// </summary>
    /// <param name="data">значение</param>
    /// <param name="dataType">Тип данных</param>
    /// <returns></returns>
    public Cell InsertDataIntoCell(Cell cell, string data, CellValues dataType);

    /// <summary>
    /// Объединение ячеек
    /// </summary>
    /// <param name="CellRangeReference">Диапазон ячеек</param>
    public Cell MergeCells(WorksheetPart worksheetPart,
        string CellRangeReference);

    /// <summary>
    /// Получает ссылку на первую клетку диапазона
    /// </summary>
    /// <param name="mergeCell">объединёная клетка</param>
    public string GetFirstCellFromMergeCell(string mergeCellReference);
}
