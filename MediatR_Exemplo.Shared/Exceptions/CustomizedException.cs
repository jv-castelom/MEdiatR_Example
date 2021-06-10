using System;
using System.Collections.Generic;
using System.Text;

namespace MediatR_Exemplo.Shared.Exceptions
{
    public class CustomizedException : Exception
    {
        public CustomizedException(Dictionary<string, IEnumerable<string>> errors)
        : base("Invalid data")
            => Errors = errors;

        public Dictionary<string, IEnumerable<string>> Errors { get; }
    }
}
