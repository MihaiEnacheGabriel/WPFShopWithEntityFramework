using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Services
{
    public class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        public Grouping(TKey key, IEnumerable<TElement> items)
        {
            Key = key;
            foreach (var item in items)
                Items.Add(item);
        }

        public TKey Key { get; private set; }
        public ObservableCollection<TElement> Items { get; } = new ObservableCollection<TElement>();

        public IEnumerator<TElement> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}
