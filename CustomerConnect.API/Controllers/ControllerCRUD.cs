using CustomerConnect.Application.Dtos;
using CustomerConnect.Application.Interfaces;
using CustomerConnect.Domain.Entities;
using CustomerConnect.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerConnect.API.Controllers
{
    public class ControllerCRUD<TDto, TEntity, TRepository, TService> : ControllerBase where TService : IService<TDto, TEntity, TRepository>
                            where TDto : EntityDto
                            where TEntity : Entity
                            where TRepository : IRepository<TEntity>
    {

        protected TService _service;
        protected ILogger _logger;

        protected ControllerCRUD(TService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet()]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var dto = await _service.GetAllAsync();
                if (dto == null)
                    return NoContent();

                return Ok(dto);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar {typeof(TEntity).Name}. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                if (entity == null)
                    return NoContent();

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar {typeof(TEntity).Name}. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Insert(TDto dto)
        {
            try
            {
                var entity = await _service.InsertAsync(dto);
                if (entity == null)
                    return NoContent();

                return Created($"{this.HttpContext}/{entity.Id}", entity);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar {typeof(TEntity).Name}. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(Guid id, TDto dto)
        {
            try
            {
                var entity = await _service.UpdateAsync(dto);

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar {typeof(TEntity).Name}. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar {typeof(TEntity).Name}. Erro: {ex.Message}");
            }
        }
    }
}
