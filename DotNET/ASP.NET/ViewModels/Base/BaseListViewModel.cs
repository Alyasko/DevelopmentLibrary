using System.Collections.Generic;
using BookPages.Models.Enums;

namespace BookPages.ViewModels.Base
{
    public abstract class BaseListViewModel<TModel, TSortErder>
    {
        public SortDirection SortDirection { get; set; }
        public TSortErder SortOrder { get; set; }

        public IEnumerable<TModel> Models { get; set; }
    }
}