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
    public class HeavyWorkMockRequestValidator : IRequestValidator<MockExternalRequest>
    {
        public IInputValidationResult Validate(MockExternalRequest request)
        {
            if (request != null)
            {
                if (request.MyInputString.Equals("Success"))
                {
                    string heavyWorkLoad = "This takes long and should optimally only be done once in validator and not repeated in Manager when ValidRequest";
                    return new CustomInputValidationResult() { ValidationResult = ValidationResultType.Success, MyPropertyThatNeededHeavyWork_DoneOnlyOnce = heavyWorkLoad };
                }
                else
                    return new CustomInputValidationResult() { ValidationResult = ValidationResultType.Error };
            }
            else
                return new CustomInputValidationResult() { ValidationResult = ValidationResultType.Error };
        }
    }
}
