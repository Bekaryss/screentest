using Company.Delivery.Core;
using Company.Delivery.Database;
using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Company.Delivery.Infrastructure;

public class WaybillService : IWaybillService
{
    private readonly DeliveryDbContext _dbContext;

    public WaybillService(DeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<WaybillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // TODO: Если сущность не найдена по идентификатору, кинуть исключение типа EntityNotFoundException

        var waybill = await _dbContext.Waybills
                .Include(w => w.Items)
                .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

        if (waybill == null)
        {
            throw new EntityNotFoundException("Cannot find any waybills.");
        }

        var waybillDto = waybill.Adapt<WaybillDto>();

        return waybillDto;
    }

    public async Task<WaybillDto> CreateAsync(WaybillCreateDto data, CancellationToken cancellationToken)
    {
        var waybill = data.Adapt<Waybill>();
        _dbContext.Waybills.Add(waybill);
        await _dbContext.SaveChangesAsync(cancellationToken);
        var waybillDto = waybill.Adapt<WaybillDto>();

        return waybillDto;
    }

    public async Task<WaybillDto> UpdateByIdAsync(Guid id, WaybillUpdateDto data, CancellationToken cancellationToken)
    {
        // TODO: Если сущность не найдена по идентификатору, кинуть исключение типа EntityNotFoundException

        var waybill = await _dbContext.Waybills
            .Include(w => w.Items)
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

        if (waybill == null)
        {
            throw new EntityNotFoundException("Cannot find any waybills.");
        }

        data.Adapt(waybill);
        await _dbContext.SaveChangesAsync(cancellationToken);
        var waybillDto = waybill.Adapt<WaybillDto>();

        return waybillDto;
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // TODO: Если сущность не найдена по идентификатору, кинуть исключение типа EntityNotFoundException

        var waybill = await _dbContext.Waybills
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

        if (waybill == null)
        {
            throw new EntityNotFoundException("Cannot find any waybills.");
        }

        _dbContext.Waybills.Remove(waybill);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}