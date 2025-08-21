using FluentResults;
using Property.Application.Response;

namespace Property.Application.Commands
{
    public interface IPropertyCommands
    {
        public Task<PropertyResponse> AddPropertyAsync(string unit, CancellationToken cancellationToken);
        public Task<Result> DeletePropertyAsync(string id, CancellationToken cancellationToken);
        public Task<Result> OccupyPropertyAsync(string unit, CancellationToken cancellationToken);
        public Task<Result> VacantPropertyAsync(string unit, CancellationToken cancellationToken);
        public Task<Result> UnderMaintenancePropertyAsync(string unit, CancellationToken cancellationToken);
    }
}
