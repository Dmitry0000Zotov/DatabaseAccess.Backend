using DatabaseAccess.Application.Products.Queries.GetProductsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Application.Nomenclatures.Queries.GetNomenclaturesList
{
    public class NomenclaturesListVm
    {
        public IList<GetNomenclaturesList> Nomenclatures { get; set; }
    }
}
