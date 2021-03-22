using BusinessLogic.BusinessEntities;
using BusinessLogic.BusinessEntities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessEngines
{
    /// <summary>
    /// Base validator for external requests
    /// </summary>
    public class ExternalRequestBaseValidator : RequestBaseValidator
    {
        /// <summary>
        /// Validate the ExternalRequestBase object
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public override IInputValidationResult Validate(RequestBase request)
        {
            // TODO Implement proper logic to validate real properties from ExternalRequstBase
            if (((ExternalRequestBase)request).ApplicationId > 0)
                return new InputValidationResult() { ValidationResult = ValidationResultType.Success };
            else
                return new InputValidationResult() { ValidationResult = ValidationResultType.Error };
            
        }
    }
}
