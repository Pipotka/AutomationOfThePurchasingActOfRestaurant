using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.OpenXML.Excel.ComfortableOperations.Interfaces;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.OpenXML.Excel;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2016.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.OpenXML.Excel;

/// <summary>
/// Сервис по работе с Excel таблицами
/// </summary>
public class ExcelTableService : IExcelTableService
{
    private readonly IExcelCellFormattingOperations formattingOperations;
    private readonly IExcelCellOperations cellOperations;
    private readonly IExcelDocumentOperations documentOperations;
    private readonly IExcelSheetOperations sheetOperations;
    private readonly IPurchaseFormReadRepository purchaseFormReadRepository;

    /// <summary>
    /// Конструктор <see cref="ExcelTableService"/>
    /// </summary>
    public ExcelTableService(IExcelCellFormattingOperations formattingOperations
        , IExcelCellOperations cellOperations
        , IExcelDocumentOperations documentOperations
        , IExcelSheetOperations sheetOperations
        , IPurchaseFormReadRepository purchaseFormReadRepository)
    {
        this.formattingOperations = formattingOperations;
        this.cellOperations = cellOperations;
        this.documentOperations = documentOperations;
        this.sheetOperations = sheetOperations;
        this.purchaseFormReadRepository = purchaseFormReadRepository;
    }

    /// <summary>
    /// Экспортирует закупочный акт в Excel таблицу
    /// </summary>
    /// <param name="memoryStream">
    /// Поток памяти, в который будет сохранён Excel документ
    /// </param>
    /// <param name="purchaseFormId">
    /// Id закупочного акта, который нужно экспартировать в Excel таблицу
    /// </param>
    public async Task<Stream> ExportPurchasingFormInTableAsync(Guid purchaseFormId,
        CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        var memoryStream = new MemoryStream();

        var purchaseForm = await purchaseFormReadRepository.GetWithAllLinksAsync(purchaseFormId, token);
        if (purchaseForm == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<PurchaseForm>(purchaseFormId);
        }

        token.ThrowIfCancellationRequested();

        using (SpreadsheetDocument document = documentOperations.CreateExcelFile(memoryStream))
        {
            token.ThrowIfCancellationRequested();

            uint sheetId = 1U;
            var sheetName = "List 1";
            var sheet = documentOperations.AddSheet(document, sheetId, sheetName);

            token.ThrowIfCancellationRequested();

            sheetOperations.CreateRangeCells(sheet, "A1:N54");

            var fontCalibri11 = formattingOperations.CreateFont("Calibri", 11);
            var alignmentLeftBottom = formattingOperations.CreateAlignment(HorizontalAlignmentValues.Left,
                VerticalAlignmentValues.Bottom);
            var Style1Index = formattingOperations.CreateCellFormat(document, 
                font: fontCalibri11,
                alignment: alignmentLeftBottom);

            token.ThrowIfCancellationRequested();
            {
                var cell = cellOperations.MergeCells(sheet, "H2:K2");
                formattingOperations.ApplyCellFormat(cell, Style1Index);
                cellOperations.InsertDataIntoCell(cell, "Унифицированная форма № ОП-5");

                var cell2 = cellOperations.MergeCells(sheet, "H3:L3");
                formattingOperations.ApplyCellFormat(cell, Style1Index);
                cellOperations.InsertDataIntoCell(cell2, "утверждена постановлением Госкомстата России");

                var cell3 = cellOperations.MergeCells(sheet, "H4:J4");
                formattingOperations.ApplyCellFormat(cell, Style1Index);
                cellOperations.InsertDataIntoCell(cell3, "от 25.12.98 № 132");
            }
            token.ThrowIfCancellationRequested();

            var alignmentCenterBottom = formattingOperations.
                CreateAlignment(HorizontalAlignmentValues.Center, 
                VerticalAlignmentValues.Bottom);
            var StyleUnderlinedIndex = formattingOperations.
                CreateCellFormat(document, font: fontCalibri11,
                alignment: alignmentCenterBottom);

            var alignmentCenterTop = formattingOperations.
                CreateAlignment(HorizontalAlignmentValues.Center, VerticalAlignmentValues.Top);
            var fontCalibri10 = formattingOperations.
                CreateFont("Calibri", 10);
            var summaryStyleIndex = formattingOperations.
                CreateCellFormat(document, font: fontCalibri10, 
                alignment: alignmentCenterTop);

            token.ThrowIfCancellationRequested();
            {
                var cell = cellOperations.MergeCells(sheet, "B7:I7");
                formattingOperations.ApplyCellFormat(cell, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell, purchaseForm.SponsorOrganization.Name);

                var summaryCell = cellOperations.MergeCells(sheet, "D8:F8");
                formattingOperations.ApplyCellFormat(summaryCell, summaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell, "организация, адрес");

                var cell2 = cellOperations.MergeCells(sheet, "B10:I10");
                formattingOperations.ApplyCellFormat(cell2, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell2, purchaseForm.SponsorOrganization.Address);

                var cell3 = cellOperations.MergeCells(sheet, "B11:J11");
                formattingOperations.ApplyCellFormat(cell3, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell3, purchaseForm.SponsorOrganization.StructuralUnit);

                var summaryCell2 = cellOperations.MergeCells(sheet, "D12:F12");
                formattingOperations.ApplyCellFormat(summaryCell2, summaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell2, "структурное подразделение");
            }
            token.ThrowIfCancellationRequested();

            var alignmentRightBottom = formattingOperations
                .CreateAlignment(HorizontalAlignmentValues.Right,
                VerticalAlignmentValues.Bottom);
            var rightSummaryStyleIndex = formattingOperations
                .CreateCellFormat(document, 
                font: fontCalibri11, 
                alignment: alignmentRightBottom);

            token.ThrowIfCancellationRequested();
            {
                var cell = cellOperations.MergeCells(sheet, "K5:L5");
                formattingOperations.ApplyCellFormat(cell, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell, "Код");

                var cell2 = cellOperations.MergeCells(sheet, "K6:L6");
                formattingOperations.ApplyCellFormat(cell2, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell2, purchaseForm.FormKey.OKUD);

                var summaryCell = cellOperations.MergeCells(sheet, "I6:J6");
                formattingOperations.ApplyCellFormat(summaryCell, rightSummaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell, "Форма по ОКУД");


                var cell3 = cellOperations.MergeCells(sheet, "K7:L7");
                formattingOperations.ApplyCellFormat(cell3, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell3, purchaseForm.FormKey.OKPO);

                var summaryCell2 = sheetOperations.FindOrCreateCell(sheet, "J7");
                formattingOperations.ApplyCellFormat(summaryCell2, rightSummaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell2, "по ОКПО");

                var cell4 = cellOperations.MergeCells(sheet, "K8:L10");
                formattingOperations.ApplyCellFormat(cell4, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell4, purchaseForm.FormKey.TIN);

                var summaryCell3 = sheetOperations.FindOrCreateCell(sheet, "J10");
                formattingOperations.ApplyCellFormat(summaryCell3, rightSummaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell3, "ИНН");

                var K11 = cellOperations.MergeCells(sheet, "K11:L11");
                formattingOperations.ApplyCellFormat(K11, StyleUnderlinedIndex);

                var cell5 = cellOperations.MergeCells(sheet, "K12:L13");
                formattingOperations.ApplyCellFormat(cell5, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell5, purchaseForm.FormKey.OKDP);

                var summaryCell4 = cellOperations.MergeCells(sheet, "H13:J13");
                formattingOperations.ApplyCellFormat(summaryCell4, rightSummaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell4, "Вид деятелности по ОКДП");

                var K14 = cellOperations.MergeCells(sheet, "K14:L14");
                formattingOperations.ApplyCellFormat(K14, StyleUnderlinedIndex);

                var summaryCell5 = cellOperations.MergeCells(sheet, "I14:J14");
                formattingOperations.ApplyCellFormat(summaryCell5, rightSummaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell5, "Вид операции");
            }
            token.ThrowIfCancellationRequested();

            var fontCalibri11Bold = formattingOperations.CreateFont("Calibri", 11, true);
            var boldFontStyle = formattingOperations.CreateCellFormat(document,
                alignment: alignmentCenterBottom,
                font: fontCalibri11Bold);

            token.ThrowIfCancellationRequested();
            {
                var cell = cellOperations.MergeCells(sheet, "J17:K17");
                formattingOperations.ApplyCellFormat(cell, boldFontStyle);
                cellOperations.InsertDataIntoCell(cell, "УТВЕРЖДАЮ");

                var cell2 = cellOperations.MergeCells(sheet, "I19:L19");
                formattingOperations.ApplyCellFormat(cell2, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell2,
                    purchaseForm.ApprovingOfficer.Position.Name);

                var summaryCell = cellOperations.MergeCells(sheet, "J20:K20");
                formattingOperations.ApplyCellFormat(summaryCell, summaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell, "должность");

                var cell3 = cellOperations.MergeCells(sheet, "K22:M22");
                formattingOperations.ApplyCellFormat(cell3, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell3, 
                    purchaseForm.ApprovingOfficer.SignatureDecryption);

                var summaryCell2 = cellOperations.MergeCells(sheet, "K23:M23");
                formattingOperations.ApplyCellFormat(summaryCell2, summaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell2, "расшифровка подписи");

                var G22 = cellOperations.MergeCells(sheet, "G22:I22");
                formattingOperations.ApplyCellFormat(G22, StyleUnderlinedIndex);

                var summaryCell3 = cellOperations.MergeCells(sheet, "G23:I23");
                formattingOperations.ApplyCellFormat(summaryCell3, summaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell3, "подпись");

                var cell4 = cellOperations.MergeCells(sheet, "F25:G25");
                formattingOperations.ApplyCellFormat(cell4, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell4, $"«     {purchaseForm.DocumentDate.Day}    »");

                var cell5 = cellOperations.MergeCells(sheet, "I25:J25");
                formattingOperations.ApplyCellFormat(cell5, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell5, purchaseForm.DocumentDate.Month.ToString());

                var cell6 = cellOperations.MergeCells(sheet, "L25:M25");
                formattingOperations.ApplyCellFormat(cell6, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell6, $"{purchaseForm.DocumentDate.Year}г.");
            }
            token.ThrowIfCancellationRequested();

            var fontCalibri12 = formattingOperations.CreateFont("Calibri", 12);
            var fontArialUnicodeMS14Bold = formattingOperations.CreateFont("Arial Unicode MS", 14, true);
            var alignmentCenterCenter = formattingOperations.CreateAlignment(HorizontalAlignmentValues.Center, VerticalAlignmentValues.Center);
            var ArialBoldFontStyle = formattingOperations
                .CreateCellFormat(document, alignment: alignmentCenterCenter, font: fontArialUnicodeMS14Bold);
            var calibri12CenterCenterStyle = formattingOperations
                .CreateCellFormat(document, alignment: alignmentCenterCenter, font: fontCalibri12);

            token.ThrowIfCancellationRequested();
            {
                var cell = cellOperations.MergeCells(sheet, "B28:D29"); 
                formattingOperations.ApplyCellFormat(cell, ArialBoldFontStyle);
                cellOperations.InsertDataIntoCell(cell, "ЗАКУПОЧНЫЙ АКТ");

                var cell2 = cellOperations.MergeCells(sheet, "E28:F29"); 
                formattingOperations.ApplyCellFormat(cell2, calibri12CenterCenterStyle);
                cellOperations.InsertDataIntoCell(cell2, purchaseForm.DocumentNumber.ToString());

                var cell3 = cellOperations.MergeCells(sheet, "G28:H29"); 
                formattingOperations.ApplyCellFormat(cell3, calibri12CenterCenterStyle);
                cellOperations.InsertDataIntoCell(cell3, purchaseForm.DocumentDate.ToShortDateString());

                var headCell = cellOperations.MergeCells(sheet, "E27:F27"); 
                formattingOperations.ApplyCellFormat(headCell, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(headCell, "Номер документа");

                var headCell2 = cellOperations.MergeCells(sheet, "G27:H27"); 
                formattingOperations.ApplyCellFormat(headCell2, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(headCell2, "Дата составления");

                var cell4 = cellOperations.MergeCells(sheet, "B32:M32"); 
                formattingOperations.ApplyCellFormat(cell4, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell4, purchaseForm.AddressOfPurchase);

                var summaryCell3 = cellOperations.MergeCells(sheet, "F33:H33"); 
                formattingOperations.ApplyCellFormat(summaryCell3, summaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell3, "место закупки");

                var cell5 = sheetOperations.FindOrCreateCell(sheet, "B35"); 
                formattingOperations.ApplyCellFormat(cell5, Style1Index);
                cellOperations.InsertDataIntoCell(cell5, "Мною,");

                var cell6 = cellOperations.MergeCells(sheet, "C35:E35"); 
                formattingOperations.ApplyCellFormat(cell6, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell6, purchaseForm.ProcurementSpecialist.Position.Name);

                var summaryCell4 = cellOperations.MergeCells(sheet, "C36:E36"); 
                formattingOperations.ApplyCellFormat(summaryCell4, summaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell4, "должность");

                var cell7 = cellOperations.MergeCells(sheet, "G35:M35"); 
                formattingOperations.ApplyCellFormat(cell7, StyleUnderlinedIndex);
                cellOperations
                    .InsertDataIntoCell(cell7,
                    $"{purchaseForm.ProcurementSpecialist.LastName} {purchaseForm.ProcurementSpecialist.FirstName} {purchaseForm.ProcurementSpecialist.Patronymic}");

                var summaryCell5 = cellOperations.MergeCells(sheet, "I36:K36"); 
                formattingOperations.ApplyCellFormat(summaryCell5, summaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell5, "фамилия, имя, отчество");

                var cell8 = sheetOperations.FindOrCreateCell(sheet, "B38"); 
                formattingOperations.ApplyCellFormat(cell8, Style1Index);
                cellOperations.InsertDataIntoCell(cell8, "куплено у");

                var cell9 = cellOperations.MergeCells(sheet, "C38:M38"); 
                formattingOperations.ApplyCellFormat(cell9, StyleUnderlinedIndex);
                cellOperations
                    .InsertDataIntoCell(cell9,
                    $"{purchaseForm.Salesman.LastName} {purchaseForm.Salesman.FirstName} {purchaseForm.Salesman.Patronymic}");

                var summaryCell6 = cellOperations.MergeCells(sheet, "G39:I39"); 
                formattingOperations.ApplyCellFormat(summaryCell6, summaryStyleIndex);
                cellOperations.InsertDataIntoCell(summaryCell6, "фамилия, имя, отчество");
            }
            token.ThrowIfCancellationRequested();

            var Calibri11AlignCenterTop = formattingOperations
                .CreateCellFormat(document, 
                alignment: alignmentCenterTop,
                font: fontCalibri11);
            var alignmentCenterTopWrapText = formattingOperations
                .CreateAlignment(HorizontalAlignmentValues.Center,
                VerticalAlignmentValues.Top, isWrapText: true);
            var Calibri11AlignCenterTopWrapText = formattingOperations
                .CreateCellFormat(document, 
                alignment: alignmentCenterTopWrapText,
                font: fontCalibri11);

            token.ThrowIfCancellationRequested();
            {
                var cell = cellOperations.MergeCells(sheet, "B41:F41");
                formattingOperations.ApplyCellFormat(cell, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell, "Сельскохозяйственные продукты");

                var cell2 = cellOperations.MergeCells(sheet, "B42:D43");
                formattingOperations.ApplyCellFormat(cell2, Calibri11AlignCenterTopWrapText);
                cellOperations.InsertDataIntoCell(cell2, "наименование, характеристика");

                var cell3 = cellOperations.MergeCells(sheet, "E42:F43");
                formattingOperations.ApplyCellFormat(cell3, Calibri11AlignCenterTop);
                cellOperations.InsertDataIntoCell(cell3, "код");

                var cell4 = cellOperations.MergeCells(sheet, "G41:H41");
                formattingOperations.ApplyCellFormat(cell4, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell4, "Единица измерения");

                var cell5 = cellOperations.MergeCells(sheet, "G42:G43");
                formattingOperations.ApplyCellFormat(cell5, Calibri11AlignCenterTopWrapText);
                cellOperations.InsertDataIntoCell(cell5, "наименова-ние");

                var cell6 = cellOperations.MergeCells(sheet, "H42:H43");
                formattingOperations.ApplyCellFormat(cell6, Calibri11AlignCenterTopWrapText);
                cellOperations.InsertDataIntoCell(cell6, "код по ОКЕИ");

                var cell7 = cellOperations.MergeCells(sheet, "I41:I43");
                formattingOperations.ApplyCellFormat(cell7, Calibri11AlignCenterTopWrapText);
                cellOperations.InsertDataIntoCell(cell7, "Количество");

                var cell8 = cellOperations.MergeCells(sheet, "J41:K43");
                formattingOperations.ApplyCellFormat(cell8, Calibri11AlignCenterTopWrapText);
                cellOperations.InsertDataIntoCell(cell8, "Цена, руб. коп.");

                var cell9 = cellOperations.MergeCells(sheet, "L41:M43");
                formattingOperations.ApplyCellFormat(cell9, Calibri11AlignCenterTopWrapText);
                cellOperations.InsertDataIntoCell(cell9, "Сумма, руб. коп.");

                var cell10 = cellOperations.MergeCells(sheet, "B44:D44");
                formattingOperations.ApplyCellFormat(cell10, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell10, "1");

                var cell11 = cellOperations.MergeCells(sheet, "E44:F44");
                formattingOperations.ApplyCellFormat(cell11, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell11, "2");

                var cell12 = sheetOperations.FindOrCreateCell(sheet, "G44");
                formattingOperations.ApplyCellFormat(cell12, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell12, "3");

                var cell13 = sheetOperations.FindOrCreateCell(sheet, "H44");
                formattingOperations.ApplyCellFormat(cell13, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell13, "4");

                var cell14 = sheetOperations.FindOrCreateCell(sheet, "I44");
                formattingOperations.ApplyCellFormat(cell14, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell14, "5");

                var cell15 = cellOperations.MergeCells(sheet, "J44:K44");
                formattingOperations.ApplyCellFormat(cell15, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell15, "6");

                var cell16 = cellOperations.MergeCells(sheet, "L44:M44");
                formattingOperations.ApplyCellFormat(cell16, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell16, "7");
            }
            token.ThrowIfCancellationRequested();

            var row = 45;
            double totalCost = 0.0;

            foreach (var merchendise in purchaseForm.PurchasedMerchandises)
            {
                token.ThrowIfCancellationRequested();

                var cell = cellOperations.MergeCells(sheet, $"B{row}:D{row}");
                formattingOperations.ApplyCellFormat(cell, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell, merchendise.Name);

                var cell2 = cellOperations.MergeCells(sheet, $"E{row}:F{row}");
                formattingOperations.ApplyCellFormat(cell2, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell2, merchendise.MerchandiseKey.ToString());

                var cell3 = sheetOperations.FindOrCreateCell(sheet, $"G{row}");
                formattingOperations.ApplyCellFormat(cell3, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell3, merchendise.MeasurementUnit.Name);

                var cell4 = sheetOperations.FindOrCreateCell(sheet, $"H{row}");
                formattingOperations.ApplyCellFormat(cell4, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell4, merchendise.MeasurementUnit.OKEIKey.ToString());

                var cell5 = sheetOperations.FindOrCreateCell(sheet, $"I{row}");
                formattingOperations.ApplyCellFormat(cell5, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell5, merchendise.Count.ToString());

                var cell6 = cellOperations.MergeCells(sheet, $"J{row}:K{row}");
                var price = merchendise.Price;
                formattingOperations.ApplyCellFormat(cell6, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell6, price.ToString());

                var cost = merchendise.Count * price;
                totalCost += cost;
                var cell7 = cellOperations.MergeCells(sheet, $"L{row}:M{row}");
                formattingOperations.ApplyCellFormat(cell7, StyleUnderlinedIndex);
                cellOperations.InsertDataIntoCell(cell7, cost.ToString());
                row++;
            }
            token.ThrowIfCancellationRequested();

            var KTotal = sheetOperations.FindOrCreateCell(sheet, $"K{row}");
            formattingOperations.ApplyCellFormat(KTotal, Style1Index);
            cellOperations.InsertDataIntoCell(KTotal, "Итого");

            token.ThrowIfCancellationRequested();

            var LTotalPrice = cellOperations.MergeCells(sheet, $"L{row}:M{row}");
            formattingOperations.ApplyCellFormat(LTotalPrice, StyleUnderlinedIndex);
            cellOperations.InsertDataIntoCell(LTotalPrice, totalCost.ToString());

            documentOperations.SaveFile(document);
            token.ThrowIfCancellationRequested();
        }

        token.ThrowIfCancellationRequested();

        return memoryStream;
    }
}
