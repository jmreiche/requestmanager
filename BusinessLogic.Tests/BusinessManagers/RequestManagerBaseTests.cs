using System;
using BusinessLogic.BusinessEngines;
using BusinessLogic.BusinessEntities;
using BusinessLogic.Tests.BusinessEngines;
using BusinessLogic.Tests.BusinessEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests.BusinessManagers
{
    [TestClass]
    public class RequestManagerBaseTests
    {
        [TestMethod]
        public void TestMockRequestManager_InvalidRequest()
        {
            ExternalRequestBaseValidator baseValidator = new ExternalRequestBaseValidator();
            MockRequestValidator mockRequestValidator = new MockRequestValidator();
            MockRequestManager mockRequestManager = new MockRequestManager(baseValidator, mockRequestValidator);

            MockExternalRequest mockExternalRequest = new MockExternalRequest { ApplicationId = 0 };

            MockExternalResponse result = mockRequestManager.ProcessRequest(mockExternalRequest);
            Assert.AreEqual(1, result.ErrorCode);
            Assert.AreEqual(ErrorLevelType.Error, result.ErrorLevel);
            Assert.AreEqual("Validation of request failed", result.ErrorMessage);
        }

        [TestMethod]
        public void TestMockRequestManager_ValidRequest()
        {
            ExternalRequestBaseValidator baseValidator = new ExternalRequestBaseValidator();
            HeavyWorkMockRequestValidator mockRequestValidator = new HeavyWorkMockRequestValidator();
            HeavyValidationMockRequestManager mockRequestManager = new HeavyValidationMockRequestManager(baseValidator, mockRequestValidator);

            MockExternalRequest mockExternalRequest = new MockExternalRequest { MyInputString = "Success", ApplicationId = 1 };

            MockExternalResponse result = mockRequestManager.ProcessRequest(mockExternalRequest);
            Assert.AreEqual(0, result.ErrorCode);
            Assert.AreEqual(ErrorLevelType.Info, result.ErrorLevel);
            Assert.AreEqual("Success", result.MyOutputString);
        }
    }
}
