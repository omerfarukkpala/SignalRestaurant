using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TableDetailDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableDetailsController : ControllerBase
    {
        private readonly ITableDetailService _tableDetailService;

        public TableDetailsController(ITableDetailService tableDetailService)
        {
            _tableDetailService = tableDetailService;
        }

        [HttpGet]
        public IActionResult TableDetailList()
        {
            var values = _tableDetailService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTableDetail(CreateTableDetailDto createTableDetailDto)
        {
            TableDetail tableDetail = new TableDetail()
            {
                Name = createTableDetailDto.Name,
                Status = false
            };

            _tableDetailService.TAdd(tableDetail);
            return Ok("Masa başarılı bir şekilde eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTableDetail(int id)
        {
            var value = _tableDetailService.TGetByID(id);
            _tableDetailService.TDelete(value);
            return Ok("Masa başarılı bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateTableDetail(UpdateTableDetailDto updateTableDetailDto)
        {
            TableDetail tableDetail = new TableDetail()
            {
                TableDetailID = updateTableDetailDto.TableDetailID,
                Name = updateTableDetailDto.Name,
                Status = updateTableDetailDto.Status
            };
            _tableDetailService.TUpdate(tableDetail);
            return Ok("Masa başarılı bir şekilde güncellendi");
        }

        [HttpGet("GetTableDetail")]
        public IActionResult GetTableDetail(int id)
        {
            var value = _tableDetailService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("TableCount")]
        public IActionResult TableCount()
        {
            var value = _tableDetailService.TTableCount();
            return Ok(value);
        }
    }
}
