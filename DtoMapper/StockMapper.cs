using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practiceApi.Dtos;
using practiceApi.Models;

namespace practiceApi.DtoMapper
{
    public static class StockMapper
    {
        public static StockDto ToStockDto(this Stock stockModel) {
            return new StockDto {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
            };
        }

        public static Stock ToCreateStockRequestDto(this CreateStockDto stockModel) {
            return new Stock {
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
            };
        }
    }
}