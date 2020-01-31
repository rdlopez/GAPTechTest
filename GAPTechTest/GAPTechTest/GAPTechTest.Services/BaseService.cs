using GoIn.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAPTechTest.Services
{
    public class BaseService
    {
        public UnitOfWork UnitOfWork { get; set; }

        public BaseService(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
