using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Refit;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Wirtualnik.Shared.Models.Base
{
    public class Pager
    {
        private int pageIndex;
        private int pageSize;
        private string? order;
        private int totalRows;

        public int PageIndex
        {
            get
            {
                return pageIndex > 0 ? pageIndex : 1;
            }
            set
            {
                pageIndex = value > 0 ? value : 1;
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize > 0 ? pageSize : 10;
            }
            set
            {
                pageSize = value > 0 ? value : 1;
            }
        }

        public string? Sort { get; set; }

        public string Order
        {
            get
            {
                return order ?? "DESC";
            }
            set
            {
                order = value?.ToUpper() == "ASC" ? "ASC" : "DESC";
            }
        }

        [BindNever]
        public int TotalRows
        {
            get
            {
                return totalRows;
            }
            set
            {
                totalRows = value > 0 ? value : 0;
            }
        }

        public int TotalPages => PageSize > 0 ? Convert.ToInt32(Math.Ceiling((double)TotalRows / PageSize)) : 0;
    }

    public static class PagerExtensions
    {
        public static IQueryable<TModel> Paginate<TModel>(this IQueryable<TModel> query, Pager pager) where TModel : class
        {
            // Count
            pager.TotalRows = query.Count();

            // Sort
            if (!string.IsNullOrEmpty(pager.Sort))
            {
                if (IsOrdered(query))
                {
                    query = (query as IOrderedQueryable<TModel>).ThenBy($"{pager.Sort} {pager.Order}");
                }
                else
                {
                    query = query.OrderBy<TModel>($"{pager.Sort} {pager.Order}");
                }
            }

            // Pager
            return query
                .Skip<TModel>((pager.PageIndex - 1) * pager.PageSize)
                .Take<TModel>(pager.PageSize);
        }
     
        private static bool IsOrdered<T>(IQueryable<T> queryable)
        {
            return queryable.Expression.Type == typeof(IOrderedQueryable<T>);
        }
    }
}
