﻿namespace Infrastructure.Persistence
{
    public abstract class UnitOfWork<T> :
        QueryUnitOfWork<T>, IUnitOfWork where T : Microsoft.EntityFrameworkCore.DbContext
    {
        public UnitOfWork(Options options) : base(options: options)
        {
        }

        public async System.Threading.Tasks.Task SaveAsync()
        {
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
