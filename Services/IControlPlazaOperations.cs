using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecursiveTest.Entities;

namespace RecursiveTest.Services
{
    public interface IControlPlazaOperations
    {
        Plaza? RetrieveById(Guid Id);
    }
}