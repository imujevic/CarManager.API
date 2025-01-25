using Contract.CarInformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceCenterService : IServiceCenterService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ServiceCenterService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> Create(CreateServiceCenterDto servicecenterDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var servicecenter = servicecenterDto.Adapt<ServiceCenter>(); // Fixing the variable name and calling Adapt on the DTO
                _repositoryManager.ServiceCenterRepository.CreateServiceCenter(servicecenter);
                var rowsAffected = await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error while creating service record."
                    };
                }

                return new GeneralResponseDto { IsSuccess = true, Message = "Service record created successfully!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task Delete(int servicecenterId, CancellationToken cancellationToken = default)
        {
            var servicecenter = await _repositoryManager.ServiceCenterRepository.GetById(servicecenterId, cancellationToken);
            if (servicecenter == null)
            {
                throw new ArgumentException($"Servicecenter with ID {servicecenterId} not found.");
            }

            _repositoryManager.ServiceCenterRepository.DeleteServiceCenter(servicecenter);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ServiceCenterDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var servicecenters = await _repositoryManager.ServiceCenterRepository.GetAll(cancellationToken);
            return servicecenters.Adapt<IEnumerable<ServiceCenterDto>>(); // Ensuring that the mapping is done properly
        }

        public async Task<ServiceCenterDto> GetById(int servicecenterId, CancellationToken cancellationToken = default)
        {
            var servicecenter = await _repositoryManager.ServiceCenterRepository.GetById(servicecenterId, cancellationToken);
            if (servicecenter == null)
            {
                throw new ArgumentException($"Servicecenter with ID {servicecenterId} not found.");
            }

            return servicecenter.Adapt<ServiceCenterDto>(); // Ensure that the object is correctly mapped
        }

        public async Task<GeneralResponseDto> Update(int servicecenterId, UpdateServiceCenterDto servicecenterDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingServicecenter = await _repositoryManager.ServiceCenterRepository.GetById(servicecenterId, cancellationToken);
                if (existingServicecenter == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Servicecenter not found." };
                }

                servicecenterDto.Adapt(existingServicecenter); // Adapt the update DTO to the existing entity

                _repositoryManager.ServiceCenterRepository.UpdateServiceCenter(existingServicecenter);
                var rowsAffected = await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Error during update." };
                }

                return new GeneralResponseDto { IsSuccess = true, Message = "Service record updated successfully!" };
            }
            catch (Exception ex)
            {
                return new GeneralResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
