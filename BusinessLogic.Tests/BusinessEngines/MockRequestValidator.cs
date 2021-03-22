using BusinessLogic.BusinessEngines;
using BusinessLogic.BusinessEntities;
using BusinessLogic.Tests.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests.BusinessEngines
{
    public class MockRequestValidator : IRequestValidator<MockExternalRequest>
    {
        public IInputValidationResult Validate(MockExternalRequest request)
        {
            if (request != null)
            {
                if (request.MyInputString.Equals("Success"))
                    return new CustomInputValidationResult() { ValidationResult = ValidationResultType.Success };
                else
                    return new InputValidationResult() { ValidationResult = ValidationResultType.Error };
            }
            else
                return new InputValidationResult() { ValidationResult = ValidationResultType.Error };
        }
    }
}
