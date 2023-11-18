using DatabaseAccess.Application.Common.Exeptions;
using DatabaseAccess.Application.Materials.Commands.CreateMaterial;
using DatabaseAccess.Application.Materials.Commands.DeleteMaterial;
using DatabaseAccess.Application.Materials.Commands.UpdateMaterial;
using DatabaseAccess.Application.Materials.Queries.GetMaterial;
using DatabaseAccess.Application.Materials.Queries.GetMaterialsList;
using DatabaseAccess.Application.Products.Commands.CreateProduct;
using DatabaseAccess.Application.Products.Commands.DeleteProduct;
using DatabaseAccess.Application.Products.Commands.UpdateProduct;
using DatabaseAccess.Application.Products.Queries.GetProductsList;
using DatabaseAccess.WebApi.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAccess.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaterialController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MaterialVm>> Get(Guid materialId)
        {
            var query = new GetMaterialQuery
            {
                MaterialId = materialId
            };
            try
            {
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }
            catch (NotFoundException ex)
            {
                var response = new
                {
                    MaterialId = materialId,
                    Status = "Error",
                    Message = ex.Message
                };
                return NotFound(response);
            }
            catch (ValidationException)
            {
                var response = new
                {
                    Error = "Validation Error",
                    Message = "Some params invalid. Please check the data."
                };

                return BadRequest(response);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<MaterialsListVm>> GetListMaterials()
        {
            var query = new GetMaterialsListQuery();

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateMaterialCommand createMaterial)
        {
            var command = createMaterial;

            try
            {
                var materialId = await Mediator.Send(command);

                var response = new
                {
                    MaterialId = materialId,
                    Status = "Success",
                    Message = "Material added successfully."
                };

                return Ok(response);
            }
            catch (ValidationException)
            {
                var response = new
                {
                    Error = "Validation Error",
                    Message = "Some params invalid. Please check the data."
                };

                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMaterialCommand updateMaterial)
        {
            try
            {
                await Mediator.Send(updateMaterial);

                var response = new
                {
                    MaterialId = updateMaterial.MaterialId,
                    Status = "Success",
                    Message = "Material updated successfully."
                };

                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                var response = new
                {
                    MaterialId = updateMaterial.MaterialId,
                    Status = "Error",
                    Message = ex.Message
                };
                return NotFound(response);
            }
            catch (ValidationException)
            {
                var response = new
                {
                    Error = "Validation Error",
                    Message = "Some params invalid. Please check the data."
                };

                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid materialId)
        {
            var command = new DeleteMaterialCommand
            {
                MaterialId = materialId
            };

            try
            {
                await Mediator.Send(command);

                var response = new
                {
                    MaterialId = materialId,
                    Status = "Success",
                    Message = "Material deleted successfully."
                };

                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                var response = new
                {
                    MaterialId = materialId,
                    Status = "Error",
                    Message = ex.Message
                };
                return NotFound(response);
            }
            catch (ValidationException)
            {
                var response = new
                {
                    Error = "Validation Error",
                    Message = "Some params invalid. Please check the data."
                };

                return BadRequest(response);
            }
        }
    }
}
