using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ControlPlaza.Entities;
using ControlPlaza.Services;

namespace ControlPlaza.DAL
{
    public class ControlPlazaRepository : IControlPlazaRepository, IDisposable
    {
        private ControlPlazasContext context;

        private bool isUnitOfWork;
        public ControlPlazaRepository(bool IsUnitOfWork = false)
        {
            this.context = new ControlPlazasContext();
            this.isUnitOfWork = IsUnitOfWork;
        }
        public Plaza? RetrievePlazaById(Guid Id)
        {
            Plaza? plaza = context.Plazas
                .Single(p => p.Id == Id);
            //Se indica la carga explícita de las plazas de origen
            var plazasOrigen = context.Plazas.ToList();
            return plaza;
        }
        public int SaveChanges()
        {
            int result = 0;
            if (context != null)
            {
                try
                {
                    result = context.SaveChanges();
                }
                catch (DbUpdateException miE)
                {
                    Console.WriteLine(miE);
                }
            }
            return result;
        }
        private bool Save()
        {
            int changes = 0;
            if (!isUnitOfWork)
            {
                changes = SaveChanges();
            }
            return changes == 1;
        }
        public void Dispose()
        {
            context.Dispose();
        }

    }
}