using _3.Leonisa.Proyecto.Componente.Domain;

namespace _4.Leonisa.Proyecto.Componente.Repository
{
    public interface IAS400Repository
    {
        Task CreateAsync(Products entity, CancellationTokenSource cancellationToken);
    }
}
