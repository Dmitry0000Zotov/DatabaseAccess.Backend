using DatabaseAccess.Application.Products.Queries.GetProductsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Materials.Queries.GetMaterialsList
{
    public class MaterialsListVm
    {
        public IList<GetMaterialsList> Materials { get; set; }
    }
}
