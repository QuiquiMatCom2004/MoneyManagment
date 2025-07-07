using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IValidable
    {
        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
            bool Validate();
    }
}
