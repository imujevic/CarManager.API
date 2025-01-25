using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceCentarService : IServiceCentarService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ServiceCentarService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<GeneralResponseDto> Create(ServiceCentarCreateDto serviceCentarDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var serviceCentar = serviceCentarDto.Adapt<ServiceCentar>(); // Fixing the variable name and calling Adapt on the DTO
                _repositoryManager.ServiceCentarRepository.CreateServiceCentar(serviceCentar);
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

        public async Task Delete(int serviceCentarId, CancellationToken cancellationToken = default)
        {
            var serviceCentar = await _repositoryManager.ServiceCentarRepository.GetById(serviceCentarId, cancellationToken);
            if (serviceCentar == null)
            {
                throw new ArgumentException($"ServiceCentar with ID {serviceCentarId} not found.");
            }

            _repositoryManager.ServiceCentarRepository.DeleteServiceCentar(serviceCentar);
            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ServiceCentarDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var serviceCentars = await _repositoryManager.ServiceCentarRepository.GetAll(cancellationToken);
            return serviceCentars.Adapt<IEnumerable<ServiceCentarDto>>(); // Ensuring that the mapping is done properly
        }

        public async Task<ServiceCentarDto> GetById(int serviceCentarId, CancellationToken cancellationToken = default)
        {
            var serviceCentar = await _repositoryManager.ServiceCentarRepository.GetById(serviceCentarId, cancellationToken);
            if (serviceCentar == null)
            {
                throw new ArgumentException($"ServiceCentar with ID {serviceCentarId} not found.");
            }

            return serviceCentar.Adapt<ServiceCentarDto>(); // Ensure that the object is correctly mapped
        }

        public async Task<GeneralResponseDto> Update(int serviceCentarId, ServiceCentarUpdateDto serviceCentarDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingServiceCentar = await _repositoryManager.ServiceCentarRepository.GetById(serviceCentarId, cancellationToken);
                if (existingServiceCentar == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "ServiceCentar not found." };
                }

                serviceCentarDto.Adapt(existingServiceCentar); // Adapt the update DTO to the existing entity

                _repositoryManager.ServiceCentarRepository.UpdateServiceCentar(existingServiceCentar);
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
