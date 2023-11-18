using DatabaseAccess.Domain;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess.Application.Interfaces
{
    public interface IApiDbContext
    {
        DbSet<Employee> Employees { get; set; }

        DbSet<Material> Materials { get; set; }

        DbSet<Nomenclature> Nomenclatures { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<ResourseSpecification> ResourseSpecifications { get; set; }

        DbSet<ResourseSpecificationDetail> ResourseSpecificationDetails { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
