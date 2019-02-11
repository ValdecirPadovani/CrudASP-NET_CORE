using System.Collections.Generic;

namespace CrudASP_NET_CORE.Controllers.Data.Converter
{
    interface IParcer<O, D>
    {
        D Parse(O origin);
        List<D> ParseList(List<O> origin);
    }
}
