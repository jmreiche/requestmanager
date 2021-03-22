using BusinessLogic.BusinessEngines;
using BusinessLogic.BusinessEntities;
using BusinessLogic.BusinessEntities.Base;
using BusinessLogic.BusinessManagers;
using BusinessLogic.Tests.BusinessEngines;
using BusinessLogic.Tests.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests.BusinessManagers
{
    public class MockRequestManager : RequestManagerBase<MockExternalRequest, MockExternalResponse, InputValidationResult>
    {
        private IRequestValidator<MockExternalRequest> _requestValidator;

        public MockRequestManager(IRequestValidator<RequestBase> baseRequestValidator, IRequestValidator<MockExternalRequest> requestValidator) : base(baseRequestValidator)
        {
            _requestValidator = requestValidator;
        }

        protected override IRequestValidator<MockExternalRequest> GetInputRequestValidator(MockExternalRequest request)
        {
            return _requestValidator;
        }

        protected override MockExternalResponse HandleInvalidRequest(MockExternalRequest request, InputValidationResult failedValidation)
        {
            throw new NotImplementedException();
        }

        protected override MockExternalResponse HandleValidRequest(MockExternalRequest request, InputValidationResult successfulValidation)
        {
            throw new NotImplementedException();
        }

        protected override MockExternalResponse HandleWarningRequest(MockExternalRequest request, InputValidationResult warningValidation)
        {
            throw new NotImplementedException();
        }
    }
}
