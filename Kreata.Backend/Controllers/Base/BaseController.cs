using Kreata.Backend.Repos.Base;
using Kreta.Shared.Assemblers;
using Kreta.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kreata.Backend.Controllers.Base
{
    public abstract class BaseController<TModel,TDto> : ControllerBase
        where TModel : class,IDbEntity<TModel>,new()
        where TDto : class, new()
    {
        protected Assambler<TModel,TDto> _assambler;
        protected IBaseRepo<TModel> _repo;

        public BaseController(Assambler<TModel, TDto>? assambler, IBaseRepo<TModel>? repo)
        {
            _assambler = assambler ?? throw new ArgumentNullException(nameof(assambler));
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var entity = (await _repo.FindByConditionAsync(s => s.Id == id)).FirstOrDefault();
            if (entity != null)
                return Ok(_assambler.ToDto(entity));
            return NotFound();
        }
    }
}
