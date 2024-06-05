using CustomerConnect.Application.Dtos;
using CustomerConnect.Application.Interfaces;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerCRUD<ClientDto, Client, IClientRepository, IClientService>
{
    private readonly ILogger<ClientController> _logger;
    public ClientController(ILogger<ClientController> logger, IClientService service) : base(service, logger)
    {
        _logger = logger;
    }

    [HttpGet("all")]
    public virtual async Task<IActionResult> GetAll([FromQuery] bool includePhones = false)
    {
        try
        {
            var entity = await _service.GetAll(includePhones);
            if (entity == null)
                return NoContent();

            return Ok(entity);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar {typeof(Client).Name}. Erro: {ex.Message}");
        }
    }
}
