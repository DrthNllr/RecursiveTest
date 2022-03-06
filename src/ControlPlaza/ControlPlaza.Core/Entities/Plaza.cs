using System;
using System.Collections.Generic;

namespace ControlPlaza.Entities
{
    public partial class Plaza
    {
        public Plaza()
        {
            InversePlazaOrigenNavigation = new HashSet<Plaza>();
        }

        public Guid Id { get; set; }
        public int CodPago { get; set; }
        public int Unidad { get; set; }
        public int SubUnidad { get; set; }
        public string CatPuesto { get; set; } = null!;
        public decimal Horas { get; set; }
        public int ConsPlaza { get; set; }
        public Guid? PlazaOrigen { get; set; }

        public virtual Plaza? PlazaOrigenNavigation { get; set; }
        public virtual ICollection<Plaza> InversePlazaOrigenNavigation { get; set; }
    }
}
