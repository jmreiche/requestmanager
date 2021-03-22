using BusinessLogic.BusinessEntities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests.BusinessEntities
{
    public class MockExternalResponse : ExternalResponseBase
    {
        public string MyOutputString { get; set; }
    }
}
