using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.DtoLayer.FeatureDto;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var value = _productService.TProductCount();
            return Ok(value);
        }

        [HttpGet("ProductCountByCategoryNameHamburger")]
        public IActionResult ProductCountByCategoryNameHamburger()
        {
            var value = _productService.TProductCountByCategoryNameHamburger();
            return Ok(value);
        }

        [HttpGet("ProductCountByCategoryNameDrink")]
        public IActionResult ProductCountByCategoryNameDrink()
        {
            var value = _productService.TProductCountByCategoryNameDrink();
            return Ok(value);
        }

        [HttpGet("ProductPriceAvg")]
        public IActionResult ProductPriceAvg()
        {
            var value = _productService.TProductPriceAvg();
            return Ok(value);
        }

        [HttpGet("ProductNameByMaxPrice")]
        public IActionResult ProductNameByMaxPrice()
        {
            var value = _productService.TProductNameByMaxPrice();
            return Ok(value);
        }

        [HttpGet("ProductNameByMinPrice")]
        public IActionResult ProductNameByMinPrice()
        {
            var value = _productService.TProductNameByMinPrice();
            return Ok(value);
        }

        [HttpGet("ProductAvgPriceByHamburger")]
        public IActionResult ProductAvgPriceByHamburger()
        {
            var value = _productService.TProductAvgPriceByHamburger();
            return Ok(value);
        }

        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategoryDto
            {
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Price = y.Price,
                ProductID = y.ProductID,
                ProductName = y.ProductName,
                ProductStatus = y.ProductStatus,
                CategoryName = y.Category.CategoryName
            });
            return Ok(values.ToList());
            //var values = _mapper.Map<List<ResultProductWithCategoryDto>>(_productService.TGetProductsWithCategories());
            //return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);
            return Ok("Ürün Bilgisi Eklendi");
            //_productService.TAdd(new Product()
            //{
            //    Description = createProductDto.Description,
            //    ProductName = createProductDto.ProductName,
            //    Price = createProductDto.Price,
            //    ImageUrl = createProductDto.ImageUrl,
            //    ProductStatus = createProductDto.ProductStatus,
            //    CategoryID = createProductDto.CategoryID
            //});
            //return Ok("Ürün eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok("Ürün silindi");
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetByID(id);
            return Ok(_mapper.Map<GetProductDto>(value));

            //var value = _productService.TGetByID(id);
            //return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok("Ürün Bilgisi Güncellendi");


            //_productService.TUpdate(new Product()
            //{
            //    ProductID = updateProductDto.ProductID,
            //    Description = updateProductDto.Description,
            //    ProductName = updateProductDto.ProductName,
            //    Price = updateProductDto.Price,
            //    ImageUrl = updateProductDto.ImageUrl,
            //    ProductStatus = updateProductDto.ProductStatus,
            //    CategoryID = updateProductDto.CategoryID
            //});
            //return Ok("Ürün bilgisi güncellendi");
        }

        [HttpGet("GetTake6ProductList")]
        public IActionResult GetTake6ProductList()
        {
            return Ok(_productService.TGetLast6Product());
        }
    }
}
