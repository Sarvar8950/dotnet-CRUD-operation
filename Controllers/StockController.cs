using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practiceApi.Data;
using practiceApi.DtoMapper;
using practiceApi.Dtos;
using practiceApi.Models;

namespace practiceApi.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context){
            _context = context;
        }
        
        [HttpGet("getAll")]
        // [Route("getAll")]
        public async Task<IActionResult> GetAll(){
            var result = await _context.Stock.ToListAsync();
            var searchResult = result.Select(s => s.ToStockDto());
            return Ok(result);
        }

        [HttpGet("getByRouteId/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) {
            var result = await _context.Stock.FindAsync(id);
            if(result == null){
                return NotFound();
            }
            return Ok(result.ToStockDto());
        }

        [HttpGet("getByQueryId")]
        public async Task<IActionResult> GetQueryId([FromQuery] int id) {
            if(id == 0) {
                return BadRequest();
            }
            var result = await _context.Stock.FindAsync(id);
            if(result == null){
                return NotFound();
            }
            return Ok(result.ToStockDto());
        }

        [HttpPost("create")]
        public async Task<IActionResult> AddNewRecord([FromBody] CreateStockDto stockDto) {
            var dataModel = stockDto.ToCreateStockRequestDto();
            await _context.Stock.AddAsync(dataModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new {id = dataModel.Id}, dataModel.ToStockDto());
        }

        [HttpPut("updateByPut")]
        public async Task<IActionResult> UpdateRecord([FromBody] StockDto updatedData) {
            int id = updatedData.Id;
            var dataModal = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(dataModal == null){
                return NotFound();
            }

            dataModal.Symbol = updatedData.Symbol;
            dataModal.CompanyName = updatedData.CompanyName;
            dataModal.Purchase = updatedData.Purchase;
            dataModal.LastDiv = updatedData.LastDiv;
            dataModal.MarketCap = updatedData.MarketCap;

            await _context.SaveChangesAsync();

            return Ok(dataModal.ToStockDto());
        }

        [HttpPatch("updateByPatch")]
        public async Task<IActionResult> UpdateByPatch([FromBody] StockDto updatedData) {
            var data = await _context.Stock.FirstOrDefaultAsync(x => x.Id == updatedData.Id);

            if(data == null) {
                return NotFound();
            }

            data.Symbol = updatedData.Symbol;
            data.CompanyName = updatedData.CompanyName;
            data.Purchase = updatedData.Purchase;
            data.LastDiv = updatedData.LastDiv;
            data.MarketCap = updatedData.MarketCap;

            await _context.SaveChangesAsync();

            return Ok(data.ToStockDto());
        }

        [HttpDelete("deleteByRouteId/{id}")]
        public async Task<IActionResult> DeleteRecord([FromRoute] int id) {
            var dataModal = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(dataModal == null) {
                return NotFound();
            }
            _context.Stock.Remove(dataModal);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("deleteByQueryId")]
        public async Task<IActionResult> DeleteRecordByQuery([FromQuery] int id) {
            if(id == 0) {
                return BadRequest();
            }
            var dataModal = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(dataModal == null) {
                return NotFound();
            }
            _context.Stock.Remove(dataModal);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}