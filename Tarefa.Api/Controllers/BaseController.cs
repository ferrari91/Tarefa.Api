using Microsoft.AspNetCore.Mvc;
using Tarefa.Application.Interface;

namespace Tarefa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IDataService _dataService;

        public BaseController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost]
        [Route("create-database")]
        public async Task<IActionResult> CreateDataBaseAsync()
        {
            return Ok(await _dataService.CreateDataBaseAsync());
        }
    }
}
