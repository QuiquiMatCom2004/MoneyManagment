using Application.Dtos;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public static class AssetMapper
    {
        public static AssetDto ToAssetDto(this Asset asset)
        {
            return new AssetDto
            {
                id = asset.Id,
                Name = asset.Name,
                Value = asset.Value,
                DateAcquired = asset.DateAcquired,
                MonthlyIncome = asset.MonthlyIncome,
                Category = asset.Category.AssetToString()
            };
        }
    }
}
