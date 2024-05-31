using Microsoft.AspNetCore.Mvc;

namespace CustomerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;
    public ClientController(ILogger<ClientController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        try
        {
            var client = await _clientService.GetClientByIdAsync(id, true);
            if (client == null) 
                return NoContent();

            return Ok(client);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar recuperar clientes. Erro: {ex.Message}");
        }
    }
}
