using Application.Dtos;
using FastEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Test;
public class TestCommandHandler : CommandHandler<TestRequest, AssetDto>
{
    public override Task<AssetDto> ExecuteAsync(TestRequest command, CancellationToken ct = default)
    {
        return Task.FromResult(new AssetDto
        {
            Id = Guid.NewGuid(),
            Value = 100.0m,
            Category = "Test Category"
        });
    }
}
