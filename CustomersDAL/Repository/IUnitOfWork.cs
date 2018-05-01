using System;
namespace CustomersDAL.DAL.Repository
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
      

        void Commit();
        void Dispose(bool isDisposed);
    }
}
