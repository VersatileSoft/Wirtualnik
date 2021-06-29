using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Wirtualnik.Shared.Models.Base
{
    public class Pagination<T> : Statement
    {
        public int TotalRows { get; set; }
        public IEnumerable<T> Items { get; set; }
        public dynamic Meta { get; set; }

        public Pagination(IEnumerable<T> items, int totalRows)
        {
            Meta = new ExpandoObject();
            TotalRows = totalRows;
            Items = items;
        }
    }

    public static class TPagination
    {
        public static Pagination<T> FromT<T>(IEnumerable<T> data, int totalRows)
        {
            return new Pagination<T>(data, totalRows);
        }
    }
}
