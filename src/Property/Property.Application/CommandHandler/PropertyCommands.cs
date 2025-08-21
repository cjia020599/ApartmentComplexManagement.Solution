using AutoMapper;
using FluentResults;
using Property.Application.Commands;
using Property.Application.Errors;
using Property.Application.Response;
using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.Services;

namespace Property.Application.CommandHandler
{
    public class PropertyCommands : IPropertyCommands
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyCommands(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PropertyResponse> AddPropertyAsync(string unit, CancellationToken cancellationToken)
        {
            PropertyUnit property = PropertyUnit.Create(unit);
            await _unitOfWork.Properties.AddAsync(property);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<PropertyResponse>(property);
        }

        public async Task<Result> DeletePropertyAsync(string unit, CancellationToken cancellationToken)
        {
            List<PropertyUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            PropertyUnit? property = properties.FirstOrDefault(p => p.Unit == unit);
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }   
            await _unitOfWork.Properties.DeleteAsync(property);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();

        }

        public async Task<Result> OccupyPropertyAsync(string unit, CancellationToken cancellationToken)
        {
            List<PropertyUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            PropertyUnit? property = properties.FirstOrDefault(p => p.Unit == unit);
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }
            var propertyService = new ChangeStatusService();
            PropertyUnit occupiedProperty = propertyService.OccupyProperty(property);
            await _unitOfWork.Properties.UpdateAsync(occupiedProperty);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();

        }

        public async Task<Result> UnderMaintenancePropertyAsync(string unit, CancellationToken cancellationToken)
        {
            List<PropertyUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            PropertyUnit? property = properties.FirstOrDefault(p => p.Unit == unit);
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }
            var propertyService = new ChangeStatusService();
            PropertyUnit occupiedProperty = propertyService.UnderMaintenanceProperty(property);
            await _unitOfWork.Properties.UpdateAsync(occupiedProperty);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }

        public async Task<Result> VacantPropertyAsync(string unit, CancellationToken cancellationToken)
        {
            List<PropertyUnit> properties = await _unitOfWork.Properties.GetAllAsync();
            PropertyUnit? property = properties.FirstOrDefault(p => p.Unit == unit);
            if (property == null)
            {
                return Result.Fail(new PropertyNotExistingError("This property doesn't exist."));
            }
            var propertyService = new ChangeStatusService();
            PropertyUnit occupiedProperty = propertyService.VacantProperty(property);
            await _unitOfWork.Properties.UpdateAsync(occupiedProperty);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
