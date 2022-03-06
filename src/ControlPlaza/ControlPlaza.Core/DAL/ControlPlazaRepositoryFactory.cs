using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlPlaza.Services;

namespace ControlPlaza.DAL
{
    public static class ControlPlazaRepositoryFactory
    {
        public static IControlPlazaRepository GetControlPlazaRepository(bool IsUnitOfWork = false)
        {
            return new ControlPlazaRepository(IsUnitOfWork);
        }
    }
}