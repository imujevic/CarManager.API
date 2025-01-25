using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IServiceCenterRepository : IRepositoryBase<ServiceCenter>
    {
        Task<IEnumerable<ServiceCenter>> GetAll(CancellationToken cancellationToken = default);

        Task<ServiceCenter> GetById(int serviceCenterId, CancellationToken cancellationToken = default);

        void CreateServiceCenter(ServiceCenter serviceCenter, CancellationToken cancellationToken = default);

        void DeleteServiceCenter(ServiceCenter serviceCenter, CancellationToken cancellationToken = default);

        void UpdateServiceCenter(ServiceCenter serviceCenter, CancellationToken cancellationToken = default);
    }
}
