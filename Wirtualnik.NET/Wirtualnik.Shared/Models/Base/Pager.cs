using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Wirtualnik.Shared.Models.Base
{
    [BindRequired]
    public class Pager
    {
        private int pageIndex;
        private int pageSize;
        private string sort;
        private string order;
        private int totalRows;

        [FromQuery(Name = "index")]
        [JsonProperty(PropertyName = "index")]
        public virtual int PageIndex
        {
            get
            {
                if (pageIndex < TotalPages)
                {
                    return pageIndex;
                }
                else if (TotalPages > 0)
                {
                    return TotalPages;
                }
                else
                {
                    return 1;
                }
            }
            set
            {
                pageIndex = value > 0 ? value : 1;
            }
        }

        #region PageSize
        [FromQuery(Name = "size")]
        [JsonProperty(PropertyName = "size")]
        public virtual int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value > 0 ? value : 1;
            }
        }

        [FromQuery(Name = "sort")]
        [JsonProperty(PropertyName = "sort")]
        public virtual string Sort
        {
            get
            {
                return sort;
            }
            set
            {
                sort = value;
            }
        }

        [FromQuery(Name = "order")]
        [JsonProperty(PropertyName = "order")]
        public virtual string Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value?.ToUpper() == "ASC" ? "ASC" : "DESC";
            }
        }

        [BindNever]
        public virtual int TotalRows
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

        [BindNever]
        public virtual int TotalPages
        {
            get
            {
                if (PageSize > 0)
                    return Convert.ToInt32(Math.Ceiling((double)TotalRows / PageSize));
                else
                    return 0;
            }
        }

        [BindNever]
        public virtual int Offset
        {
            get
            {
                return (PageIndex - 1) * PageSize;
            }
        }

        public Pager() : this(1, 20, "Id", "ASC")
        {
        }

        public Pager(Pager pager)
        {
            totalRows = pager.totalRows;
            pageIndex = pager.pageIndex;
            pageSize = pager.pageSize;
            sort = pager.sort;
            order = pager.order;
        }

        public Pager(int pageIndex, int pageSize = 20, string sort = "Id", string order = "ASC")
        {
            TotalRows = Int32.MaxValue;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Sort = sort;
            Order = order;
            this.sort = sort;
            this.order = order;
        }
        #endregion
    }

    public static partial class PagerExtensions
    {
        #region Paginate()
        public static IQueryable<TModel> Paginate<TModel>(this IQueryable<TModel> query, Pager pager) where TModel : class
        {
            // Count
            pager.TotalRows = query.Count();

            // Sort
            if (!String.IsNullOrEmpty(pager.Sort))
            {
                if (OrderingMethodFinder.OrderMethodExists(query.Expression))
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
                .Skip<TModel>(pager.Offset)
                .Take<TModel>(pager.PageSize);
        }
        #endregion
    }

    internal class OrderingMethodFinder : ExpressionVisitor
    {
        bool orderingMethodFound = false;

        #region VisitMethodCall()
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            var name = node.Method.Name;

            if (node.Method.DeclaringType == typeof(Queryable) && (
                name.StartsWith("OrderBy", StringComparison.Ordinal) ||
                name.StartsWith("ThenBy", StringComparison.Ordinal)))
            {
                orderingMethodFound = true;
            }

            return base.VisitMethodCall(node);
        }
        #endregion

        #region OrderMethodExists()
        public static bool OrderMethodExists(Expression expression)
        {
            var visitor = new OrderingMethodFinder();

            visitor.Visit(expression);

            return visitor.orderingMethodFound;
        }
        #endregion
    }
}
