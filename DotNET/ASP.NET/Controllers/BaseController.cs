using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookPages.Models.Enums;
using BookPages.ViewModels;
using BookPages.ViewModels.Base;

namespace BookPages.Controllers
{
    public class BaseController : Controller
    {
        private bool _handleExceptions = false;

        protected ActionResult RunSafe(Action action, Func<ActionResult> afterAction)
        {
            
            try
            {
                action();

            }
            catch (Exception e)
            {
                if (_handleExceptions == false)
                    throw;

                return View("Error", new ErrorViewModel($"{e.GetType().Name} is occurred", e.Message));
            }

            return afterAction();
        }

        protected ActionResult SortableListAction<TSortOrder, TViewModel, TModel>(Func<TSortOrder, SortDirection, IEnumerable<TModel>> getAllModelsFunc, Func<TSortOrder> convertSortOrderFunc, int sortBy = 0, int direction = 0)  where TViewModel : BaseListViewModel<TModel, TSortOrder>, new()
        {
            if(getAllModelsFunc == null)
                throw new NullReferenceException("getAllModelsFunc can not be null.");

            if(convertSortOrderFunc == null)
                throw new NullReferenceException("convertSortOrderFunc can not be null.");

            TViewModel viewModel = new TViewModel();

            return RunSafe(() =>
            {
                SortDirection sortDirection = (SortDirection)direction;
                TSortOrder sortOrder = convertSortOrderFunc();

                SortDirection newSortDirecton = SortDirection.Descending;

                switch (sortDirection)
                {
                    case SortDirection.Ascending:
                        newSortDirecton = SortDirection.Descending;
                        break;
                    case SortDirection.Descending:
                        newSortDirecton = SortDirection.Ascending;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                viewModel.SortDirection = newSortDirecton;
                viewModel.SortOrder = sortOrder;

                viewModel.Models = getAllModelsFunc(sortOrder, sortDirection);

            }, () => View(viewModel));
        }
    }
}