using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecursiveTest.Entities;
using RecursiveTest.Services;
using RecursiveTest.DAL;

namespace RecursiveTest.BLL
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