using System;
using System.Collections.Generic;

namespace DatabaseAccess.Domain;

public partial class ResourseSpecification
{
    public Guid SpecificationId { get; set; }

    public string? SpecificationName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<ResourseSpecificationDetail> ResourseSpecificationDetails { get; set; } = new List<ResourseSpecificationDetail>();
}
