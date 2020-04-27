using System;
using System.Collections.Generic;
using System.Text;

namespace RMX_TOOLS.converter
{
    public interface IConverter
    {
          string valueToString(object value);
          object stringToValue(string str);
    }
}
