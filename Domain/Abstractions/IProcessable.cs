using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface IProcessable
    {
        /// <summary>
        /// Processes the current instance.
        /// </summary>
        /// <returns>A boolean indicating whether the processing was successful.</returns>
        bool Process();
    }
}
