using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookPages.ViewModels.Base
{
    // ReSharper disable once InconsistentNaming
    public class BaseCUWithSelectViewModel<TModel> : BaseCUViewModel<TModel>
    {
        public IEnumerable<SelectListItem> SelectItems { get; set; }
    }
}