using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessEntities
{
    public class CustomInputValidationResult : IInputValidationResult
    {
        public ValidationResultType ValidationResult { get; set; }
        public string MyPropertyThatNeededHeavyWork_DoneOnlyOnce { get; set; }
    }
}
