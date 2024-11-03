using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var value = _categoryService.TCategoryCount();
            return Ok(value);
        }

        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var value = _categoryService.TActiveCategoryCount();
            return Ok(value);
        }

        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var value = _categoryService.TPassiveCategoryCount();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            createCategoryDto.Status = true;
            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(value);
            return Ok("Kategori Eklendi");


            //_categoryService.TAdd(new Category()
            //{
            //    CategoryName = createCategoryDto.CategoryName,
            //    Status = createCategoryDto.Status
            //});
            //return Ok("Kategori eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Kategori silindi");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {

            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok("Kategori Güncellendi");


            //_categoryService.TUpdate(new Category()
            //{
            //    CategoryID = updateCategoryDto.CategoryID,
            //    CategoryName = updateCategoryDto.CategoryName,
            //    Status = updateCategoryDto.Status
            //});
            //return Ok("Kategori güncellendi");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(value);
        }
    }
}
