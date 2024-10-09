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
/// Интерфейс операций над Excel документом
/// </summary>
public interface IExcelDocumentOperations
{
    /// <summary>
    /// Создаёт документ
    /// </summary>
    /// <param name="filePath">путь к файлу</param>
    public SpreadsheetDocument CreateExcelFile(string filePath);

    /// <summary>
    /// Создаёт документ
    /// </summary>
    /// <param name="filePath">путь к файлу</param>
    public SpreadsheetDocument CreateExcelFile(Stream stream);

    /// <summary>
    /// Сохранение документа
    /// </summary>
    public SpreadsheetDocument SaveFile(SpreadsheetDocument document);

    /// <summary>
    /// Возвращает лист по названию
    /// </summary>
    /// <param name="sheetName">название листа</param>
    public WorksheetPart GetWorksheetPart(SpreadsheetDocument document, string sheetName);

    /// <summary>
    /// Возвращает лист по sheetId
    /// </summary>
    /// <param name="sheetId">Id листа</param>
    public WorksheetPart GetWorksheetPart(SpreadsheetDocument document, uint sheetId);

    /// <summary>
    /// Добавляет лист в документ
    /// </summary>
    /// <param name="sheetId">Id нового листа</param>
    /// <param name="sheetName">название листа</param>
    public WorksheetPart AddSheet(SpreadsheetDocument document, uint sheetId, string sheetName);
}
