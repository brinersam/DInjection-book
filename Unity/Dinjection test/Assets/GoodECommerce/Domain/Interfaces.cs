using System;
using System.Collections.Generic;

namespace ECom.Domain
{
    public interface IDataContext
    {
        public IEnumerable<Product> GetProducts(Func<Product,bool> predicate = null);
    }

    public interface IViewAdapter<T>
    {
        public IEnumerable<T> ViewAdapter(IEnumerable<Product> products);
    }
}