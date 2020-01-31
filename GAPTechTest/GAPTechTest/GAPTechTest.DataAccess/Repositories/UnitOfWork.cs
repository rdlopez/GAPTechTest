using GAPTechTest.DataAccess;
using GAPTechTest.Models;
using System;

namespace GoIn.DataAccess.Repositories
{
    public class UnitOfWork : IDisposable
    {
        #region Fields 

        private readonly GAPTechContext _db;
        private BaseRepository<Policy> policyRepository;
        private BaseRepository<Hedge> hedgeRepository;

        #endregion

        #region Properties

        public BaseRepository<Policy> PolicyRepository
        {
            get
            {
                if (this.policyRepository == null)
                {
                    this.policyRepository = new BaseRepository<Policy>(_db);
                }
                return policyRepository;
            }
        }

        public BaseRepository<Hedge> HedgeRepository
        {
            get
            {
                if (this.hedgeRepository == null)
                {
                    this.hedgeRepository = new BaseRepository<Hedge>(_db);
                }
                return hedgeRepository;
            }
        }

        #endregion

        #region Methods

        public UnitOfWork()
        {
            if(_db == null)
            {
                _db = new GAPTechContext();
            }
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        #endregion
    }
}
