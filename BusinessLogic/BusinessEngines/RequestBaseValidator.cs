using BusinessLogic.BusinessEntities;
using BusinessLogic.BusinessEntities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessEngines
{
    public class RequestBaseValidator : IRequestValidator<RequestBase>
    {
        public virtual IInputValidationResult Validate(RequestBase request)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
