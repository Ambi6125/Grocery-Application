using EasyTools.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisDataLayer
{
    public sealed class InsertValidationResponse : ValidationResponse, IValidationResponse
    {
        public int? ResultID { get; }

        public InsertValidationResponse(bool success, string message, int? newID)
            : base(success, message)
        {
            ResultID = newID;
        }
    }
}
