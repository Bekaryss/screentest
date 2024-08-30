using Company.Delivery.Api.Controllers.Waybills.Request;
using Company.Delivery.Api.Controllers.Waybills.Response;
using Company.Delivery.Core;
using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Company.Delivery.Api.Controllers.Waybills;

/// <summary>
/// Waybills management
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WaybillsController : ControllerBase
{
    private readonly IWaybillService _waybillService;

    /// <summary>
    /// Waybills management
    /// </summary>
    public WaybillsController(IWaybillService waybillService) => _waybillService = waybillService;

    /// <summary>
    /// Получение Waybill
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // TODO: вернуть ответ с кодом 200 если найдено или кодом 404 если не найдено
        // TODO: WaybillsControllerTests должен выполняться без ошибок

        try
        {
            var waybillDto = await _waybillService.GetByIdAsync(id, cancellationToken);
            var response = waybillDto.Adapt<WaybillResponse>();

            return Ok(response);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Создание Waybill
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync([FromBody] WaybillCreateRequest request, CancellationToken cancellationToken)
    {
        // TODO: вернуть ответ с кодом 200 если успешно создано
        // TODO: WaybillsControllerTests должен выполняться без ошибок
        try
        {
            var waybillCreateDto = request.Adapt<WaybillCreateDto>();
            var waybillDto = await _waybillService.CreateAsync(waybillCreateDto, cancellationToken);
            var response = waybillDto.Adapt<WaybillResponse>();

            return Ok(response);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Редактирование Waybill
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(WaybillResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateByIdAsync(Guid id, [FromBody] WaybillUpdateRequest request, CancellationToken cancellationToken)
    {
        // TODO: вернуть ответ с кодом 200 если найдено и изменено, или 404 если не найдено
        // TODO: WaybillsControllerTests должен выполняться без ошибок
        try
        {
            var waybillUpdateDto = request.Adapt<WaybillUpdateDto>();
            var waybillDto = await _waybillService.UpdateByIdAsync(id, waybillUpdateDto, cancellationToken);
            var response = waybillDto.Adapt<WaybillResponse>();

            return Ok(response);
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Удаление Waybill
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        // TODO: вернуть ответ с кодом 200 если найдено и удалено, или 404 если не найдено
        // TODO: WaybillsControllerTests должен выполняться без ошибок

        try
        {
            await _waybillService.DeleteByIdAsync(id, cancellationToken);

            return Ok();
        }
        catch (EntityNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}