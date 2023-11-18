using System;
using System.Collections.Generic;

namespace DatabaseAccess.Domain;

public partial class Nomenclature
{
    public Guid NomenclatureId { get; set; }

    public string NomenclatureName { get; set; } = null!;

    public string CountType { get; set; } = null!;

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
