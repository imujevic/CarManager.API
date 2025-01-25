﻿using Domain.Repositories;

namespace Persistence.Repositories;

internal sealed class UnitOfWork(DataContext dbContext) : IUnitOfWork
{

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => dbContext.SaveChangesAsync(cancellationToken);
}