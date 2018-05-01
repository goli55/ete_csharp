using CustomersUtil;
using System;
using System.Configuration;
using System.Linq;


namespace CustomersDAL.DAL.Repository
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        //private const string  _connectionStringName = "MAIDbContext";
        private CustomersDbEntities _context;
        private IRepository<Customer> _customers;
        

        private bool _isDisposed=false;

        public SqlUnitOfWork()
        {
            string writeLog = "false";
            int retries,intervalMin,intervalMax;
            retries=3;
            intervalMin=1;
            intervalMax=3;
            //var connectionString = ConfigurationManager
            //    .ConnectionStrings[_connectionStringName]
            //    .ConnectionString;

            try
            {
                _context = Run.WithProgressBackOff<CustomersDbEntities>(retries, intervalMin, intervalMax, () =>
                {
                    return new CustomersDbEntities();
                });
                
                //_context =new ModemDBEntities();

                _context.Configuration.LazyLoadingEnabled = true;
                _context.Configuration.AutoDetectChangesEnabled = false;

                try
                {
                    writeLog = ConfigurationManager.AppSettings["WriteCacheLog"];
                }
                catch { }

                if (!string.IsNullOrEmpty(writeLog))
                {
                    if (writeLog.ToLower() == "true")
                    {
                        _context.Database.Log = new Action<string>((o) => Logger.Info(o.AsQueryable().ToString()));
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Fail to create connection to sql db.Message:" + ex.Message + " .Stack:" + ex.StackTrace);
                throw ex;
            }
            

        }


       
        public IRepository<Customer> Customers
        {
            get {
                if (_isDisposed)
                    throw new ObjectDisposedException("SqlUnitOfWork Disposed");

                if (_customers == null)
                    _customers = new SqlRepository<Customer>(_context);
                return _customers;
            }
        }

     

        public void Commit()
        {
            if (_isDisposed)
                throw new ObjectDisposedException("SqlUnitOfWork Disposed");

            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }


        public virtual void Dispose(bool isDisposed)
        {
            if (_isDisposed == false)
            {
                if (isDisposed)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                    _isDisposed = true;
                }
               
            }
        }
    }
}
