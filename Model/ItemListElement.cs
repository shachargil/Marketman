using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ParentList : IEntity
    {
        public About about { get; set; }
    }

    public class About : IEntity
    {
        public IEnumerable<ItemListElement> itemListElement { get; set; }
    }
    public class ItemListElement : IEntity
    {
        public string url { get; set; }
    }
}
