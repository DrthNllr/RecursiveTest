using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecursiveTest.Entities;

namespace RecursiveTest.Services
{
    public interface IControlPlazaRepository : IDisposable
    {
        Plaza? RetrievePlazaById(Guid Id);
    }
}