using Contract.CarInformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceRecordService(IRepositoryManager repositoryManager) : IServiceRecordService
    {
        public async Task<GeneralResponseDto> Create(CreateServiceRecordDto serviceRecordDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var serviceRecord = serviceRecordDto.Adapt<ServiceRecord>();
                repositoryManager.ServiceRecordRepository.CreateServiceRecord(serviceRecord);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error while creating service record."
                    };
                }

                return new GeneralResponseDto { Message = "Service record created successfully!" };
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

        public async Task Delete(int serviceRecordId, CancellationToken cancellationToken = default)
        {
            var serviceRecord = await repositoryManager.ServiceRecordRepository.GetById(serviceRecordId, cancellationToken);
            if (serviceRecord == null)
            {
                throw new ArgumentException($"ServiceRecord with ID {serviceRecordId} not found.");
            }

            repositoryManager.ServiceRecordRepository.DeleteServiceRecord(serviceRecord, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ServiceRecordDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var serviceRecords = await repositoryManager.ServiceRecordRepository.GetAll(cancellationToken);
            return serviceRecords.Adapt<IEnumerable<ServiceRecordDto>>();
        }

        public async Task<ServiceRecordDto> GetById(int serviceRecordId, CancellationToken cancellationToken = default)
        {
            var serviceRecord = await repositoryManager.ServiceRecordRepository.GetById(serviceRecordId, cancellationToken);
            if (serviceRecord == null)
            {
                throw new ArgumentException($"ServiceRecord with ID {serviceRecordId} not found.");
            }

            return serviceRecord.Adapt<ServiceRecordDto>();
        }

        public async Task<GeneralResponseDto> Update(int serviceRecordId, UpdateServiceRecordDto serviceRecordDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingServiceRecord = await repositoryManager.ServiceRecordRepository.GetById(serviceRecordId, cancellationToken);
                if (existingServiceRecord == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "ServiceRecord not found." };
                }

                serviceRecordDto.Adapt(existingServiceRecord);

                repositoryManager.ServiceRecordRepository.UpdateServiceRecord(existingServiceRecord);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Error during update." };
                }

                return new GeneralResponseDto { Message = "Service record updated successfully!" };
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
