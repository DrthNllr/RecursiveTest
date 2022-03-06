using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlPlaza.Entities;

namespace ControlPlaza.Services
{
    public interface IControlPlazaOperations
    {
        Plaza? RetrieveById(Guid Id);
    }
}