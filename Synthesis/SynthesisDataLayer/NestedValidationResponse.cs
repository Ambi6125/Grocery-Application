using EasyTools.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisDataLayer
{
    public class NestedValidationResponse : ValidationResponse, IValidationResponse
    {
        public IValidationResponse Inner { get; }
        public NestedValidationResponse(bool success, string message, IValidationResponse inner) : base(success, message)
        {
            Inner = inner;
        }
    }
}
