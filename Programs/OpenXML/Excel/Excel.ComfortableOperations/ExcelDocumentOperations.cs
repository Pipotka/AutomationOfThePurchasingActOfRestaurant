using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations.Interfaces;

namespace Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations;

/// <summary>
/// Операции над Excel документом
/// </summary>
public class ExcelDocumentOperations : IExcelDocumentOperations
{
    /// <summary>
    /// Создаёт документ
    /// </summary>
    /// <param name="filePath">путь к файлу</param>
    public SpreadsheetDocument CreateExcelFile(string filePath)
    {
        SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook);

        document.AddWorkbookPart();
        document.WorkbookPart.Workbook = new Workbook();
        document.WorkbookPart.Workbook.AppendChild(new Sheets());
        document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
        document.WorkbookPart.WorkbookStylesPart.Stylesheet = new Stylesheet();
        document.WorkbookPart.WorkbookStylesPart.Stylesheet.Fonts = new Fonts();
        document.WorkbookPart.WorkbookStylesPart.Stylesheet.Borders = new Borders();
        document.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats = new CellFormats();

        return document;
    }

    /// <summary>
    /// Создаёт документ
    /// </summary>
    /// <param name="filePath">путь к файлу</param>
    public SpreadsheetDocument CreateExcelFile(Stream stream)
    {
        SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook);

        document.AddWorkbookPart();
        document.WorkbookPart.Workbook = new Workbook();
        document.WorkbookPart.Workbook.AppendChild(new Sheets());
        document.WorkbookPart.AddNewPart<WorkbookStylesPart>();
        document.WorkbookPart.WorkbookStylesPart.Stylesheet = new Stylesheet();
        document.WorkbookPart.WorkbookStylesPart.Stylesheet.Fonts = new Fonts();
        document.WorkbookPart.WorkbookStylesPart.Stylesheet.Borders = new Borders();
        document.WorkbookPart.WorkbookStylesPart.Stylesheet.CellFormats = new CellFormats();

        return document;
    }

    /// <summary>
    /// Сохранение документа
    /// </summary>
    public SpreadsheetDocument SaveFile(SpreadsheetDocument document)
    {
        document.Save();

        return document;
    }

    /// <summary>
    /// Возвращает лист по названию
    /// </summary>
    /// <param name="sheetName">название листа</param>
    public WorksheetPart GetWorksheetPart(SpreadsheetDocument document, string sheetName)
    {
        WorkbookPart workbookPart = document.WorkbookPart;


        Sheet sheet = workbookPart.Workbook.Descendants<Sheet>()
                        .FirstOrDefault(s => s.Name == sheetName);

        if (sheet == null)
        {
            return null;
        }

        WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);

        return worksheetPart;
    }

    /// <summary>
    /// Возвращает лист по sheetId
    /// </summary>
    /// <param name="sheetId">Id листа</param>
    public WorksheetPart GetWorksheetPart(SpreadsheetDocument document, uint sheetId)
    {
        WorkbookPart workbookPart = document.WorkbookPart;


        Sheet sheet = workbookPart.Workbook.Descendants<Sheet>()
                        .FirstOrDefault(s => s.SheetId == sheetId);

        if (sheet == null)
        {
            return null;
        }

        WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);

        return worksheetPart;
    }

    /// <summary>
    /// Добавляет лист в документ
    /// </summary>
    /// <param name="sheetId">Id нового листа</param>
    /// <param name="sheetName">название листа</param>
    public WorksheetPart AddSheet(SpreadsheetDocument document, uint sheetId, string sheetName)
    {
        WorksheetPart worksheetPart = document.WorkbookPart.AddNewPart<WorksheetPart>();
        worksheetPart.Worksheet = new Worksheet(new SheetData());

        Sheet sheet = new Sheet()
        {
            Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
            SheetId = sheetId,
            Name = sheetName
        };
        document.WorkbookPart.Workbook.Sheets.Append(sheet);

        worksheetPart.Worksheet.Append(new Drawing() { Id = worksheetPart.GetIdOfPart(worksheetPart.AddNewPart<DrawingsPart>()) });
        return worksheetPart;
    }
}
