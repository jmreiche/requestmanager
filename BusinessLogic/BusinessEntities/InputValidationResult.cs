using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessEntities
{
    public class InputValidationResult : IInputValidationResult
    {
        public ValidationResultType ValidationResult { get; set; }
    }
}
