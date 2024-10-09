using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Microsoft.EntityFrameworkCore;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.ReadRepositories;

/// <summary>
/// Читает <see cref="Signature"/> из репозитория
/// </summary>
public class SignatureReadRepository : ISignatureReadRepository
{
    private readonly IDbReader reader;

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="SignatureReadRepository"/>
    /// </summary>
    public SignatureReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }

    /// <summary>
    /// Получает все подписи
    /// </summary>
    public Task<List<Signature>> GetAllAsync(CancellationToken token)
        => reader.Read<Signature>()
        .NotDeleted()
                 .OrderBy(s => s.Id)
                 .ToListAsync(token);

    /// <summary>
    /// Получает подпись по идентификатору
    /// </summary>
    public Task<Signature?> GetAsync(Guid id, CancellationToken token)
        => reader.Read<Signature>()
            .NotDeleted()
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Получает подпись по идентификатору утверждающего
    /// </summary>
    public Task<Signature?> GetByApproverIdAsync(Guid approverId, CancellationToken token)
        => reader.Read<Signature>()
            .NotDeleted()
            .Where(s => s.ApproverId == approverId)
            .FirstOrDefaultAsync(token);

    /// <summary>
    /// Проверяет, существует ли подпись по свойствам Points и ApproverId
    /// </summary>
    public bool IsExist(Signature signature)
        => reader.Read<Signature>()
        .NotDeleted()
                 .Any(s => s.ApproverId == signature.ApproverId &&
                           s.Points.SequenceEqual(signature.Points));
}