using Application.Dtos;
using Application.Handlers.Test;
using FastEndpoints;

namespace MoneyManagment.Endpoints
{
    public class TestEndpoint : EndpointWithoutRequest<AssetDto>
    {
        public override void Configure()
        {
            Get("/test");
            AllowAnonymous();
        }

        public override async Task HandleAsync( CancellationToken ct)
        {
            var response = await new TestRequest().ExecuteAsync(ct);
            await SendOkAsync(response, ct);
        }
    }
}