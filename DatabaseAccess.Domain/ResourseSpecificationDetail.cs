using System;
using System.Collections.Generic;

namespace DatabaseAccess.Domain;

public partial class ResourseSpecificationDetail
{
    public Guid DetailId { get; set; }

    public Guid SpecificationId { get; set; }

    public Guid MaterialNomenclatureId { get; set; }

    public string? Characteristic { get; set; }

    public decimal? Amount { get; set; }

    public string? WayToObtain { get; set; }

    public string? ArticleCosting { get; set; }

    public virtual ResourseSpecification Specification { get; set; } = null!;
}
