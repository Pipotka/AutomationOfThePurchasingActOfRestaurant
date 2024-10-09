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
/// Операции над клетками Excel листа
/// </summary>
public class ExcelCellOperations : IExcelCellOperations
{
    private static ExcelSheetOperations SheetOperations = new ExcelSheetOperations();

    /// <summary>
    /// Вставляет значение в клетку
    /// </summary>
    /// <param name="data">значение</param>
    /// <param name="CellReference">
    /// Ссылка на клетку
    /// </param>
    public Cell InsertDataIntoCell(WorksheetPart worksheetPart, string CellReference, string data)
    {
        var cell = SheetOperations.FindOrCreateCell(worksheetPart, CellReference);

        cell.CellValue = new CellValue(data);
        cell.DataType = new EnumValue<CellValues>(CellValues.String);

        return cell;
    }

    /// <summary>
    /// Вставляет значение в клетку
    /// </summary>
    /// <param name="data">значение</param>
    /// <returns></returns>
    public Cell InsertDataIntoCell(Cell cell, string data)
    {
        cell.CellValue = new CellValue(data);
        cell.DataType = new EnumValue<CellValues>(CellValues.String);

        return cell;
    }

    /// <summary>
    /// Вставляет значение в клетку
    /// </summary>
    /// <param name="data">значение</param>
    /// <param name="dataType">Тип данных</param>
    /// <returns></returns>
    public Cell InsertDataIntoCell(Cell cell, string data, CellValues dataType)
    {
        cell.CellValue = new CellValue(data);
        cell.DataType = new EnumValue<CellValues>(dataType);

        return cell;
    }

    /// <summary>
    /// Объединение ячеек
    /// </summary>
    /// <param name="CellRangeReference">Диапазон ячеек</param>
    public Cell MergeCells(WorksheetPart worksheetPart,
        string CellRangeReference)
    {
        Worksheet worksheet = worksheetPart.Worksheet;
        var firstCellReference = GetFirstCellFromMergeCell(CellRangeReference);
        var firstCell = SheetOperations.FindOrCreateCell(worksheetPart, firstCellReference);

        MergeCells mergeCells;
        if (worksheet.Elements<MergeCells>().Count() > 0)
        {
            mergeCells = worksheet.Elements<MergeCells>().First();
        }
        else
        {
            mergeCells = new MergeCells();
            if (worksheet.Elements<CustomSheetView>().Count() > 0)
            {
                worksheet.InsertAfter(mergeCells, worksheet.Elements<CustomSheetView>().First());
            }
            else
            {
                worksheet.InsertAfter(mergeCells, worksheet.Elements<SheetData>().First());
            }
        }

        MergeCell mergeCell = new MergeCell()
        {
            Reference = new StringValue(CellRangeReference)
        };

        mergeCells.Append(mergeCell);

        return firstCell;
    }

    /// <summary>
    /// Получает ссылку на первую клетку диапазона
    /// </summary>
    /// <param name="mergeCell">объединёная клетка</param>
    public string GetFirstCellFromMergeCell(string mergeCellReference)
    {
        var cellReferences = mergeCellReference.Split(':');

        return cellReferences[0];
    }
}
