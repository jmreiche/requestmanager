using BusinessLogic.BusinessEntities;
using BusinessLogic.BusinessEntities.Base;

namespace BusinessLogic.BusinessEngines
{
    /// <summary>
    /// Interface for request validators
    /// </summary>
    /// <typeparam name="Req"></typeparam>
    public interface IRequestValidator<Req> where Req : RequestBase
    {
        IInputValidationResult Validate(Req request);
    }
}
