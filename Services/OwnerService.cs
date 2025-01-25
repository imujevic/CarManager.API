using Contract.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OwnerService(IRepositoryManager repositoryManager) : IOwnerService
    {
        public async Task<GeneralResponseDto> Create(CreateOwnerDto ownerDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var owner = ownerDto.Adapt<Owner>();
                repositoryManager.OwnerRepository.CreateOwner(owner);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error!"
                    };
                }

                return new GeneralResponseDto { Message = "Success!" };
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

        public async Task Delete(int ownerId, CancellationToken cancellationToken = default)
        {
            var owner = await repositoryManager.OwnerRepository.GetById(ownerId, cancellationToken);
            if (owner == null)
            {
                throw new ArgumentException($"Owner with ID {ownerId} not found.");
            }

            repositoryManager.OwnerRepository.DeleteOwner(owner, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<OwnerDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var owners = await repositoryManager.OwnerRepository.GetAll(cancellationToken);
            return owners.Adapt<IEnumerable<OwnerDto>>();
        }

        public async Task<OwnerDto> GetById(int ownerId, CancellationToken cancellationToken = default)
        {
            var owner = await repositoryManager.OwnerRepository.GetById(ownerId, cancellationToken);
            if (owner == null)
            {
                throw new ArgumentException($"Owner with ID {ownerId} not found.");
            }

            return owner.Adapt<OwnerDto>();
        }

        public async Task<GeneralResponseDto> Update(int ownerId, UpdateOwnerDto ownerDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingOwner = await repositoryManager.OwnerRepository.GetById(ownerId, cancellationToken);
                if (existingOwner == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Owner not found." };
                }

                ownerDto.Adapt(existingOwner);

                repositoryManager.OwnerRepository.UpdateOwner(existingOwner);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Error during update." };
                }

                return new GeneralResponseDto { Message = "Success!" };
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

