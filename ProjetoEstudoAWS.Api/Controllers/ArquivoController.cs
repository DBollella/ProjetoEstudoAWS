using Microsoft.AspNetCore.Mvc;
using ProjetoEstudoAWS.Infra.ExternalService;
using System.Threading.Tasks;

namespace ProjetoEstudoAWS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArquivoController : ControllerBase
    {        
        private readonly ILogger<ArquivoController> _logger;
        private readonly IStorageService _storageService;

        public ArquivoController(ILogger<ArquivoController> logger, IStorageService storageService)
        {
            _logger = logger;
            _storageService = storageService;
        }

        [HttpGet("{id}/URLPreAssinada")]
        public async Task<ActionResult<string>> Get([FromRoute] string id)
        {
            var url = await _storageService.GenerateDownloadUrl("projeto-estudo-aws", $"processados/{id}");

            return Ok(url);
        }

        //[HttpGet(Name = "URLPreAssinada/{id}")]
        //public ActionResult<string> Post([FromBody] string id)
        //{
        //    var url = _storageService.GenerateDownloadUrl("projeto-estudo-aws", $"processados/{id}");

        //    return Ok(url);
        //}
    }
}
