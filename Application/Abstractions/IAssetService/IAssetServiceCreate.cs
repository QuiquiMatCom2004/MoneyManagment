using Application.Dtos;
using Application.Features.Create.Assets;
using Domain.Entities.Assets;

namespace Application.Abstractions.IAssetService
{
    public interface IAssetServiceCreate
    {
        ActionAsset CreateActions(AssetCommand command);
        CriptoAsset CreateCryptocurrency(AssetCommand command);
        EmpresarialInvestmentAsset CreateEmpresarialInvestment(AssetCommand command);
        RealStateAsset CreateRealEstate(AssetCommand command);
        RawMaterialsAsset CreateRawMaterials(AssetCommand command);
    }
}
