using AutoMapper;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.ReadRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Repository.Contracts.WriteRepositories;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Exceptions;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.IServices.ModelServices;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models;
using Company.AutomationOfThePurchasingActOfRestaurant.Services.Contracts.Models.BaseModels;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Services.ModelServices;

/// <summary>
/// Сервис по работе с подписями
/// </summary>
public class SignatureService : ISignatureService
{
    private readonly ISignatureReadRepository signatureReadRepository;
    private readonly ISignatureWriteRepository signatureWriteRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    /// <summary>
    /// Конструктор <see cref="SignatureService"/>
    /// </summary>
    public SignatureService(ISignatureReadRepository signatureReadRepository
        , ISignatureWriteRepository signatureWriteRepository
        , IUnitOfWork unitOfWork
        , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.signatureWriteRepository = signatureWriteRepository;
        this.signatureReadRepository = signatureReadRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Добавляет подпись
    /// </summary>
    public async Task<SignatureModel> AddAsync(SignatureBaseModel source, CancellationToken token)
    {
        var IsExist = signatureReadRepository.IsExist(mapper.Map<Signature>(source));
        if (IsExist)
        {
            throw new InvalidOperationPurchasingEntityServiceException($"Подобная подпись уже существует");
        }

        var result = mapper.Map<Signature>(source);
        result.Id = Guid.NewGuid();
        signatureWriteRepository.Add(result);
        await unitOfWork.SaveChangesAsync(token);

        return mapper.Map<SignatureModel>(result);
    }

    /// <summary>
    /// Удаляет подпись по Id
    /// </summary>
    public async Task DeleteByIdAsync(Guid id, CancellationToken token)
    {
        var result = await signatureReadRepository.GetAsync(id, token);
        if (result != null)
        {
            signatureWriteRepository.Delete(result);
            await unitOfWork.SaveChangesAsync(token);
            return;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Signature>(id);
    }

    /// <summary>
    /// Возвращает все подписи
    /// </summary>
    public async Task<List<SignatureModel>> GetAllAsync(CancellationToken token)
    {
        var result = await signatureReadRepository.GetAllAsync(token);
        return mapper.Map<List<SignatureModel>>(result);
    }

    /// <summary>
    /// Возвращает подпись по Id
    /// </summary>
    public async Task<SignatureModel> GetAsync(Guid id, CancellationToken token)
    {
        var result = await signatureReadRepository.GetAsync(id, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByIdServiceExeption<Signature>(id);
        }
        return mapper.Map<SignatureModel>(result);
    }

    /// <summary>
    /// Возвращает подпись по Id утвержадющего
    /// </summary>
    public async Task<SignatureModel?> GetByApproverIdAsync(Guid approverId, CancellationToken token)
    {
        var result = await signatureReadRepository.GetByApproverIdAsync(approverId, token);
        if (result == null)
        {
            throw new PurchasingEntityNotFoundByRelatedEntityServiceExeption<Signature, Approver>(approverId);
        }
        return mapper.Map<SignatureModel>(result);
    }

    /// <summary>
    /// Изменяет подпись
    /// </summary>
    public async Task<SignatureModel> UpdateAsync(SignatureModel source, CancellationToken token)
    {
        var result = await signatureReadRepository.GetAsync(source.Id, token);
        if (result != null)
        {
            mapper.Map(source, result);
            signatureWriteRepository.Update(result);
            await unitOfWork.SaveChangesAsync(token);
            return source;
        }
        throw new PurchasingEntityNotFoundByIdServiceExeption<Signature>(source.Id);
    }
}
