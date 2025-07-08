using Application.Features.Create.Assets;
using FastEndpoints;

namespace MoneyManagment.Endpoints.Asset
{
    public class AssetCreateEndpoint : Endpoint<Application.Features.Create.Assets.AssetCommand, Application.Dtos.AssetDto>
    {
        public override void Configure()
        {
            Post("/assets");
            AllowAnonymous();
        }
        public override async Task HandleAsync(AssetCommand req, CancellationToken ct)
        {
            var response = await req.ExecuteAsync(ct);
            await SendAsync(response, StatusCodes.Status201Created,cancellation: ct);
        }
    }
}
