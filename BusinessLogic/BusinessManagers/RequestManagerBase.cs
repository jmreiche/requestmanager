using BusinessLogic.BusinessEngines;
using BusinessLogic.BusinessEntities;
using BusinessLogic.BusinessEntities.Base;
using System;

namespace BusinessLogic.BusinessManagers
{
    /// <summary>
    /// Base class for all RequestManagers. Handles the flow with processing of requests including uniform way of validation
    /// </summary>
    /// <typeparam name="Req">The request type</typeparam>
    /// <typeparam name="Resp">The response type</typeparam>
    /// <typeparam name="InpValRes">The input validation type that is returned from validation of request type</typeparam>
    public abstract class RequestManagerBase<Req, Resp, InpValRes> : IRequestManager<Req, Resp> where Req : RequestBase where Resp : ResponseBase where InpValRes : IInputValidationResult
    {
        private readonly IRequestValidator<RequestBase> _baseValidator;
        public RequestManagerBase(IRequestValidator<RequestBase> baseRequestValidator)
        {
            _baseValidator = baseRequestValidator;
        }
        public Resp ProcessRequest(Req request)
        {
            Resp result = null;

            // Validate BaseRequest
            IInputValidationResult baseValidationResult = _baseValidator.Validate(request);

            // If BaseRequest is valid - then validate specific request
            if (baseValidationResult.ValidationResult == ValidationResultType.Success)
            {
                IRequestValidator<Req> validator = GetInputRequestValidator(request);

                InpValRes validationResult = (InpValRes)validator.Validate(request);

                switch (validationResult.ValidationResult)
                {
                    case ValidationResultType.Success:
                        result = HandleValidRequest(request, validationResult);
                        break;
                    case ValidationResultType.Warning:
                        result = HandleWarningRequest(request, validationResult);
                        break;
                    case ValidationResultType.Error:
                        result = HandleInvalidRequest(request, validationResult);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Unknown ValidationResult");
                }
            }
            else
            {
                // Should we handle it here in the base manager or send it back to the implementing class as HandleInvalidRequest ?
                // I think we should handle it here
                // TODO - Decorate response from BaseRequestValidator with enough information to set these properties below with valid
                // information across all interfaces
                result = HandleInvalidBaseRequest(baseValidationResult);
            }

            // TODO Log outgoing request - perhaps? 

            return result;
        }

        private Resp HandleInvalidBaseRequest(IInputValidationResult failedBaseValidation)
        {
            // TODO we may have an issue if the request class suddenly needs parameters in the constructor
            // In that case we may need to "push" the instantiation to the implementer class
            Resp result = (Resp)Activator.CreateInstance(typeof(Resp));
            result.ErrorCode = 1;
            result.ErrorMessage = "Validation of request failed";
            result.ErrorLevel = ErrorLevelType.Error;
            return result;
        }

        protected abstract IRequestValidator<Req> GetInputRequestValidator(Req request);

        protected abstract Resp HandleInvalidRequest(Req request, InpValRes failedValidation);

        protected abstract Resp HandleWarningRequest(Req request, InpValRes warningValidation);

        protected abstract Resp HandleValidRequest(Req request, InpValRes successfulValidation);
    }
}
