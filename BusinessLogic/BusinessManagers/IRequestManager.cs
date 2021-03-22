using BusinessLogic.BusinessEntities.Base;

namespace BusinessLogic.BusinessManagers
{
    public interface IRequestManager<Req, Resp> where Req : RequestBase where Resp : ResponseBase
    {
        Resp ProcessRequest(Req request);
    }
}
