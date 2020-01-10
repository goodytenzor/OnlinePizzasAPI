using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePizzas.API.Models.Pizza.ViewModels
{
    /// <summary>
    /// Representational model for catching exceptions
    /// </summary>
    public class ErrorModel
    {
        public int StatusCode { get; set; }

        public string ErrorMessage { get; set; }

    }
}
