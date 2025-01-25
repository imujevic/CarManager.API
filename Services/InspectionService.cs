namespace Services
{
    public class InspectionService(IRepositoryManager repositoryManager) : IInspectionService
    {
        public async Task<GeneralResponseDto> Create(InspectionCreateDto inspectionDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var inspection = inspectionDto.Adapt<Inspection>();
                repositoryManager.InspectionRepository.CreateInspection(inspection);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto
                    {
                        IsSuccess = false,
                        Message = "Error while creating inspection."
                    };
                }

                return new GeneralResponseDto { Message = "Inspection created successfully!" };
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

        public async Task Delete(int inspectionId, CancellationToken cancellationToken = default)
        {
            var inspection = await repositoryManager.InspectionRepository.GetById(inspectionId, cancellationToken);
            if (inspection == null)
            {
                throw new ArgumentException($"Inspection with ID {inspectionId} not found.");
            }

            repositoryManager.InspectionRepository.DeleteInspection(inspection, cancellationToken);
            await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<InspectionDto>> GetAll(CancellationToken cancellationToken = default)
        {
            var inspections = await repositoryManager.InspectionRepository.GetAll(cancellationToken);
            return inspections.Adapt<IEnumerable<InspectionDto>>();
        }

        public async Task<InspectionDto> GetById(int inspectionId, CancellationToken cancellationToken = default)
        {
            var inspection = await repositoryManager.InspectionRepository.GetById(inspectionId, cancellationToken);
            if (inspection == null)
            {
                throw new ArgumentException($"Inspection with ID {inspectionId} not found.");
            }

            return inspection.Adapt<InspectionDto>();
        }

        public async Task<GeneralResponseDto> Update(int inspectionId, InspectionUpdateDto inspectionDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var existingInspection = await repositoryManager.InspectionRepository.GetById(inspectionId, cancellationToken);
                if (existingInspection == null)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Inspection not found." };
                }

                inspectionDto.Adapt(existingInspection);

                repositoryManager.InspectionRepository.UpdateInspection(existingInspection);
                var rowsAffected = await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (rowsAffected != 1)
                {
                    return new GeneralResponseDto { IsSuccess = false, Message = "Error during update." };
                }

                return new GeneralResponseDto { Message = "Inspection updated successfully!" };
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
