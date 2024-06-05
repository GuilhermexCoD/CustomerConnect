using CustomerConnect.Application.Dtos;
using CustomerConnect.Application.Interfaces;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomerConnect.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhoneController : ControllerCRUD<PhoneDto, Phone, IPhoneRepository, IPhoneService>
{
    private readonly ILogger<PhoneController> _logger;
    public PhoneController(ILogger<PhoneController> logger, IPhoneService service) : base(service, logger)
    {
        _logger = logger;
    }
}
