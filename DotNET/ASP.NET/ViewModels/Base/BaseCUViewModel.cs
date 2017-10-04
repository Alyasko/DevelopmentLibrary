using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPages.ViewModels.Base
{
    public class BaseCUViewModel<TModel>
    {
        public TModel Model { get; set; }
    }
}