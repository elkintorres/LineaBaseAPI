using _3.Leonisa.Proyecto.Componente.Domain;

using _4.Leonisa.Proyecto.Componente.Repository;

using Bogus;

using GenFu;

using System.Linq.Expressions;



namespace _7.Leonisa.Proyecto.Componente.Test.Fake
{
    public class FakeProductsRepository : IProductsRepository
    {
        private IQueryable<Products> fakeProductsDB;

        public FakeProductsRepository()
        {
            int id = 1;
            A.Configure<Products>()
            .Fill(p => p.ProductID, () => { return id++; })
            .Fill(p => p.ProductName, () => new Faker().Commerce.ProductName())
            .Fill(p => p.SupplierID, () => GenFu.GenFu.Random.Next(1, 20))
            .Fill(p => p.CategoryID, () => GenFu.GenFu.Random.Next(1, 10))
            .Fill(p => p.QuantityPerUnit, () => new Faker().Commerce.Ean8())
            .Fill(p => p.UnitPrice, () => { return Decimal.Parse(GenFu.GenFu.Random.Next(100, 50000).ToString()); })
            .Fill(p => p.UnitsInStock, () => { return short.Parse(GenFu.GenFu.Random.Next(0, 100).ToString()); })
            .Fill(p => p.UnitsOnOrder, () => { return short.Parse(GenFu.GenFu.Random.Next(0, 50).ToString()); })
            .Fill(p => p.ReorderLevel, () => { return short.Parse(GenFu.GenFu.Random.Next(0, 20).ToString()); })
            .Fill(p => p.Discontinued).WithRandom(new[] { true, false });

            var productList = GenFu.GenFu.ListOf<Products>(50);
            fakeProductsDB = productList.AsQueryable();
        }

        public Task<int> CountAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Products entity, CancellationTokenSource cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int entityKey, CancellationTokenSource cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetByExpressionAsync(Expression<Func<Products, bool>> predicate, CancellationTokenSource cancellationToken)
        {
            var result = fakeProductsDB.Where(predicate);
            if (result.Any(x => x.ProductID == 30 || x.ProductID == 50))
            {
                cancellationToken.Cancel();
                throw new Exception("Get_record_with_code_500_InternalServerError");
            }

            return Task.FromResult<IEnumerable<Products>>(result);
        }

        public Task<IEnumerable<Products>> GetProductsPaginateEFAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetProductsPaginateSPAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Products entity, CancellationTokenSource cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
