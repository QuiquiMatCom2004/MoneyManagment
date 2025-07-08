

using Application.Dtos;
using Application.Features.Create.Assets;
using Domain.Abstractions;
using Domain.Entities.Assets;
using System.Runtime.CompilerServices;
using Domain.ValueObjects;
namespace Application.Services.Assets
{
    public class AssetService: IAssetServiceCreate
    {
        public ActionAsset CreateActions(AssetCommand command)
        {
            return new ActionAsset(
                    command.Name,
                    new Domain.ValueObjects.Money(command.Value, command.Currency),
                    command.DateAcquired,
                    command.DividendYield ?? 0
                    );
        }

        public CriptoAsset CreateCryptocurrency(AssetCommand command)
        {
            return new CriptoAsset(command.Name,
                new Domain.ValueObjects.Money(command.Value, command.Currency),
                command.DateAcquired,
                command.MarketCap ?? 0
            );
        }

        public EmpresarialInvestmentAsset CreateEmpresarialInvestment(AssetCommand command)
        {
            return new EmpresarialInvestmentAsset(
                command.Name,
                new Money(command.Value, command.Currency),
                command.DateAcquired,
                command.PorcentageInvestment ?? 0,
                new Money(command.AnualPerformace ?? 0,command.Currency)
            );
        }

        public RawMaterialsAsset CreateRawMaterials(AssetCommand command)
        {
            return new RawMaterialsAsset(
                command.Name,
                new Money(command.Value, command.Currency),
                command.DateAcquired,
                new Money(command.SellPrice ?? 0, command.Currency)
            );
        }

        public RealStateAsset CreateRealEstate(AssetCommand command)
        {
            return new RealStateAsset(
                command.Name,
                new Money(command.Value, command.Currency),
                command.DateAcquired,
                new Money(command.RentPrice ?? 0, command.Currency),
                new Money(command.ChoreExpenses ?? 0, command.Currency)
            );
        }
    }
}
