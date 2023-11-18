using System;
using System.Collections.Generic;

namespace DatabaseAccess.Domain;

public partial class Material
{
    public Guid MaterialId { get; set; }

    public Guid NomenclatureId { get; set; }

    public decimal? Amount { get; set; }

    public virtual Nomenclature Nomenclature { get; set; } = null!;
}
