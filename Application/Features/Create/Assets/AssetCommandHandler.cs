using Application.Dtos;
using Application.Mappers;
using Domain.Abstractions;
using Domain.Entities.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Create.Assets
{
    public class AssetCommandHandler : CommandHandler<AssetCommand, AssetDto>
    {
        private readonly IAssetServiceCreate _service;
        private readonly IUnitOfWork _work;
        public AssetCommandHandler(IAssetServiceCreate service , IUnitOfWork work)
        {
            _service = service;
            _work = work;
        }
        public override async Task<AssetDto> ExecuteAsync(AssetCommand command, CancellationToken ct)
        {
            Asset? asset = null;
            switch (command.Category.ToAssetCategory())
            {
                
                case AssetCategorys.RawMaterial:
                    asset = _service.CreateRawMaterials(command);
                    var repo1 = _work.GetRepository<RawMaterialsAsset>();
                    await repo1.AddAsync(asset as RawMaterialsAsset);
                    await _work.SaveChangesAsync();
                    return await Task.FromResult(asset.ToAssetDto());
                case AssetCategorys.Actions:
                    asset= _service.CreateActions(command);
                    var repo2 = _work.GetRepository<ActionAsset>();
                    await repo2.AddAsync(asset as ActionAsset);
                    await _work.SaveChangesAsync();
                    return await Task.FromResult(asset.ToAssetDto());
                case AssetCategorys.CriptoCurrency:
                    asset = _service.CreateCryptocurrency(command);
                    var repo3 = _work.GetRepository<CriptoAsset>();
                    await repo3.AddAsync(asset as CriptoAsset);
                    await _work.SaveChangesAsync();
                    return await Task.FromResult(asset.ToAssetDto());
                case AssetCategorys.Investment:
                    asset = _service.CreateEmpresarialInvestment(command);
                    var repo4 = _work.GetRepository<EmpresarialInvestmentAsset>();
                    await repo4.AddAsync(asset as EmpresarialInvestmentAsset);
                    await _work.SaveChangesAsync();
                    return await Task.FromResult(asset.ToAssetDto());
                case AssetCategorys.RealEstate:
                    asset = _service.CreateRealEstate(command);
                    var repo5 = _work.GetRepository<RealStateAsset>();
                    await repo5.AddAsync(asset as RealStateAsset);
                    await _work.SaveChangesAsync();
                    return await Task.FromResult(asset.ToAssetDto());
                default:
                    throw new ArgumentException("Invalid category");
            }

        }
    }
}
