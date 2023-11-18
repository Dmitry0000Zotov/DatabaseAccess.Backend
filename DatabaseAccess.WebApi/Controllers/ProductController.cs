using AutoMapper;
using DatabaseAccess.Application.Products.Commands.CreateProduct;
using DatabaseAccess.Application.Products.Commands.DeleteProduct;
using DatabaseAccess.Application.Products.Commands.UpdateProduct;
using DatabaseAccess.Application.Products.Queries.GetProduct;
using DatabaseAccess.Application.Products.Queries.GetProductsList;
using DatabaseAccess.WebApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace DatabaseAccess.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ProductsListVm>> GetListProducts(Guid nomenclatureId)
        {
            var query = new GetProductsListQuery
            {
                NomenclatureId = nomenclatureId
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet]
        public async Task<ActionResult<ProductVm>> Get(Guid productId)
        {
            var query = new GetProductQuery
            {
                ProductId = productId
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
                    ProductId = productId,
                    Status = "Error",
                    Message = ex.Message
                };
                return NotFound(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto createProduct)
        {
            var command = _mapper.Map<CreateProductCommand>(createProduct);
            var productId = await Mediator.Send(command);

            var response = new
            {
                ProductId = productId,
                Status = "Success",
                Message = "Product added successfully."
            };

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand updateProduct)
        {
            try
            {
                await Mediator.Send(updateProduct);

                var response = new
                {
                    ProductId = updateProduct.ProductId,
                    Status = "Success",
                    Message = "Product updated successfully."
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    ProductId = updateProduct.ProductId,
                    Status = "Error",
                    Message = ex.Message
                };
                return NotFound(response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid productId)
        {
            var command = new DeleteProductCommand
            {
                ProductId = productId
            };

            try
            {
                await Mediator.Send(command);

                var response = new
                {
                    ProductId = productId,
                    Status = "Success",
                    Message = "Product deleted successfully."
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new
                {
                    ProductId = productId,
                    Status = "Error",
                    Message = ex.Message
                };
                return NotFound(response);
            }
        }
    }
}
