using _3.Leonisa.Proyecto.Componente.Domain;

using _4.Leonisa.Proyecto.Componente.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Leonisa.Proyecto.Componente.Persistence
{
    public class AS400Repository : IAS400Repository
    {
        public Task CreateAsync(Products entity, CancellationTokenSource cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
