using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWAF_Core.ViewModels
{
    public class ErrorViewModel
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public string StackTrace { get; set; }

        public ErrorViewModel(Exception ex)
        {
            Type = ex.GetType().Name;
            Message = ex.Message;

            if (ex.InnerException != null)
            {
                InnerMessage = ex.InnerException.Message;
            }
            StackTrace = ex.ToString();
        }
    }
}
