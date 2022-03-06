using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlPlaza.Entities;
using ControlPlaza.Services;
using ControlPlaza.DAL;

namespace ControlPlaza.BLL
{
    public class ControlPlazaOperations : IControlPlazaOperations
    {
        public Plaza? RetrieveById(Guid Id)
        {
            Plaza? plaza = null;
            using (var repositorio = ControlPlazaRepositoryFactory.GetControlPlazaRepository())
            {
                plaza = repositorio.RetrievePlazaById(Id);
            }
            return plaza;
        }
    }
}