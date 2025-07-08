using Application.Features.Create.Liability;
using Application.Dtos;
using FastEndpoints;

namespace MoneyManagment.Endpoints.Liability
{
    public class LiabilityCreateEndpoint : Endpoint<LiabilityCommand,LiabilityDto>
    {
        public override void Configure()
        {
            Post("/liabilities");
            AllowAnonymous();
        }
        public override async Task HandleAsync(LiabilityCommand req, CancellationToken ct)
        {
            var response = await req.ExecuteAsync(ct);
            await SendAsync(response, StatusCodes.Status201Created, cancellation: ct);
        }
    }
}
