using DatabaseAccess.Application.Nomenclatures.Queries.GetNomenclature;
using DatabaseAccess.Application.Nomenclatures.Queries.GetNomenclaturesList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAccess.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class NomenclatureController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<NomenclatureVm>> Get(Guid nomenclatureId)
        {
            var query = new GetNomenclatureQuery()
            {
                NomenclatureId = nomenclatureId
            };
            try
            {
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    NomenclatureId = nomenclatureId,
                    Status = "Error",
                    Message = ex.Message
                };
                return NotFound(response);
            }
        }

        [HttpGet]
        public async Task<ActionResult<NomenclaturesListVm>> GetListNomenclatures()
        {
            var query = new GetNomenclaturesListQuery();

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
