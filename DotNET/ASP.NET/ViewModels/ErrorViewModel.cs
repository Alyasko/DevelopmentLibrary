using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookPages.ViewModels
{
    public class ErrorViewModel
    {
        private const String DefaultErrorTitle = "Error occurred during processing of your request";
        private const String DefaultErrorDescription = "Details";

        public ErrorViewModel() : this(DefaultErrorTitle, DefaultErrorDescription)
        {
            
        }

        public ErrorViewModel(String errorDescription) : this(DefaultErrorTitle, errorDescription)
        {
            ErrorDescription = errorDescription;
        }

        public ErrorViewModel(String errorTitle, String errorDescription)
        {
            ErrorTitle = errorTitle;
            ErrorDescription = errorDescription;
        }

        public String ErrorTitle { get; set; }
        public String ErrorDescription { get; set; }
    }
}