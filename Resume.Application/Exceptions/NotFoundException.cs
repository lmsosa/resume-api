using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"No se encontró la entidad \"{name}\" ({key}).")
        {
        }
    }
}
