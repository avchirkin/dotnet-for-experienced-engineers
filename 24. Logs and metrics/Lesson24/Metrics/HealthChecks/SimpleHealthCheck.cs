using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Metrics.HealthChecks;

public sealed class SimpleHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(HealthCheckResult.Healthy());
    }
}