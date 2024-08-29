using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomationOfThePurchasingActOfRestaurant.Repositories
{
    /// <summary>
    /// Репозиторий Единиц измерения
    /// </summary>
    public class MeasurementUnitsRepository
    {
        private readonly PurchasingDbContext dbContext;

        public MeasurementUnitsRepository(PurchasingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Получает единицу измерения по идентификатору
        /// </summary>
        public async Task<MeasurementUnit> GetAsync(Guid id, CancellationToken token)
        {
            var measurementUnit = await dbContext.MeasurementUnits
                .AsNoTracking()
                .Where(mu => mu.Id == id)
                .FirstOrDefaultAsync(token);

            return measurementUnit;
        }

        /// <summary>
        /// Получает все единицы измерения
        /// </summary>
        public async Task<List<MeasurementUnit>> GetAllAsync(CancellationToken token)
        {
            var measurementUnits = await dbContext.MeasurementUnits
                .AsNoTracking()
                .ToListAsync(token);

            return measurementUnits;
        }

        /// <summary>
        /// Добавляет единицу измерения в БД
        /// </summary>
        public async Task CreateAsync(MeasurementUnit measurementUnit, CancellationToken token)
        {
            dbContext.MeasurementUnits.Add(measurementUnit);
            await dbContext
                .SaveChangesAsync(token);
        }

        /// <summary>
        /// Проверяет существует ли единица измерения в БД
        /// </summary>
        /// <returns>
        /// Если единица измерения существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public bool IsExist(MeasurementUnit measurementUnit)
        {
            var isExist = dbContext.MeasurementUnits
                .Where(mu => mu.Equals(measurementUnit)) == null
                ? false : true;

            return isExist;
        }

        /// <summary>
        /// Проверяет существует ли единица измерения с <paramref name="id"/> в БД
        /// </summary>
        /// <param name="id">
        /// Id единицы измерения, которая нуждается в проверке
        /// </param>
        /// <returns>
        /// Если единица измерения существует,
        /// то возвращает <c>True</c>, иначе <c>False</c>
        /// </returns>
        public async Task<bool> IsExistByIdAsync(Guid id, CancellationToken token)
        {
            var result = await GetAsync(id, token);
            var isExist = result == null ? false : true;

            return isExist;
        }

        /// <summary>
        /// Изменяет единицу измерения
        /// </summary>
        /// <param name="updatedMeasurementUnit">
        /// Изменённая единица измерения
        /// </param>
        public async Task EditAsync(MeasurementUnit updatedMeasurementUnit, CancellationToken token)
        {
            var oldMeasurementUnit = await dbContext.MeasurementUnits
                .FirstOrDefaultAsync(mu =>
                mu.Id == updatedMeasurementUnit.Id, token);

            oldMeasurementUnit.Name = updatedMeasurementUnit.Name;
            oldMeasurementUnit.OKEIKey = updatedMeasurementUnit.OKEIKey;
            oldMeasurementUnit.Merchandises = updatedMeasurementUnit.Merchandises;

            dbContext.MeasurementUnits.Update(oldMeasurementUnit);

            await dbContext.SaveChangesAsync(token);
        }

        /// <summary>
        /// Удаляет единицу измерения по идентификатору
        /// </summary>
        public async Task DeleteAsync(Guid id, CancellationToken token)
        {
            var removableMeasurementUnit = await dbContext.MeasurementUnits
                .Where(mu => mu.Id == id)
                .FirstOrDefaultAsync(token);

            dbContext.MeasurementUnits.Remove(removableMeasurementUnit);

            await dbContext.SaveChangesAsync(token);
        }
    }
}
