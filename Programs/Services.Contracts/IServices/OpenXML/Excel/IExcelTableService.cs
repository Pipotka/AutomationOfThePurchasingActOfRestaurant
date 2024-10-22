using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.OpenXML.Excel;

/// <summary>
/// Интерфейс сервиса по работе с Excel таблицами
/// </summary>
public interface IExcelTableService
{
    /// <summary>
    /// Экспортирует закупочный акт в Excel таблицу
    /// </summary>
    /// <param name="memoryStream">
    /// Поток памяти, в который будет сохранён Excel документ
    /// </param>
    /// <param name="purchaseFormId">
    /// Id закупочного акта, который нужно экспартировать в Excel таблицу
    /// </param>
    Task<Stream> ExportPurchasingFormInTableAsync(Guid purchaseFormId,
        CancellationToken token);
}
