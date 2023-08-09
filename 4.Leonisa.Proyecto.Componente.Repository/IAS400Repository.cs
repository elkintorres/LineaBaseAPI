using _3.Leonisa.Proyecto.Componente.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Leonisa.Proyecto.Componente.Repository
{
    public interface IAS400Repository
    {
        Task CreateAsync(Products entity, CancellationTokenSource cancellationToken);
    }
}
