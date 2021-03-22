using BusinessLogic.BusinessEngines;
using BusinessLogic.BusinessEntities;
using BusinessLogic.BusinessEntities.Base;
using BusinessLogic.BusinessManagers;
using BusinessLogic.Tests.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests.BusinessManagers
{
    public class HeavyValidationMockRequestManager : RequestManagerBase<MockExternalRequest, MockExternalResponse, CustomInputValidationResult>
    {
        private IRequestValidator<MockExternalRequest> _requestValidator;

        public HeavyValidationMockRequestManager(IRequestValidator<RequestBase> baseRequestValidator, IRequestValidator<MockExternalRequest> requestValidator) : base(baseRequestValidator)
        {
            _requestValidator = requestValidator;
        }

        protected override IRequestValidator<MockExternalRequest> GetInputRequestValidator(MockExternalRequest request)
        {
            return _requestValidator;
        }

        protected override MockExternalResponse HandleInvalidRequest(MockExternalRequest request, CustomInputValidationResult failedValidation)
        {
            throw new NotImplementedException();
        }

        protected override MockExternalResponse HandleValidRequest(MockExternalRequest request, CustomInputValidationResult successfulValidation)
        {
            // We know that request is validated by our validator

            // We also know that our CustomInputValidationResult will then hold the object/property that has taken long time to build in the validation
            // flow. And that we therefore does not need to compute once again here in manager.

            var heavyWorkObject = successfulValidation.MyPropertyThatNeededHeavyWork_DoneOnlyOnce;
            return new MockExternalResponse { ErrorCode = 0, ErrorLevel = ErrorLevelType.Info, MyOutputString = "Success" };
        }

        protected override MockExternalResponse HandleWarningRequest(MockExternalRequest request, CustomInputValidationResult warningValidation)
        {
            throw new NotImplementedException();
        }
    }
}
