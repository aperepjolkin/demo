using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankRatesManagement.Domain.Entities;

namespace BankRatesManagement.Domain.Concrete
{
    public class UnitOfWork : IDisposable
    {
        private EFDbContext context = new EFDbContext();

        private GenericRepository<Rate> rateRepository;
        public GenericRepository<Rate> RateRepository
        {
            get
            {
                if (this.rateRepository == null)
                    this.rateRepository = new GenericRepository<Rate>(context);
                return rateRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                //Free any other managed objects here. 
                context.Dispose();
            }

            // Free any unmanaged objects here. 
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
