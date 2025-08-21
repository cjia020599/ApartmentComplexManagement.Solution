using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Exceptions
{
    public class PropertyOccupiedException(string message) : Exception(message)
    {
    }
}
