using System;
using System.Collections.Generic;

namespace DatabaseAccess.Domain;

public partial class Product
{
    public Guid ProductId { get; set; }

    public Guid NomenclatureId { get; set; }

    public Guid SpecificationId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Status { get; set; }

    public string? Code { get; set; }

    public decimal? PalletNumber { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public virtual Nomenclature Nomenclature { get; set; } = null!;

    public virtual ResourseSpecification Specification { get; set; } = null!;
}
