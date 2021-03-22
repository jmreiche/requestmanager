using System;
using BusinessLogic.BusinessEngines;
using BusinessLogic.BusinessEntities;
using BusinessLogic.BusinessEntities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests.BusinessEngines
{
    [TestClass]
    public class ExternalRequestBaseValidatorTests
    {
        [TestMethod]
        public void TestExternalRequestBaseValidator_ValidRequest()
        {
            // Initalize
            ExternalRequestBaseValidator externalRequestBaseValidator = new ExternalRequestBaseValidator();
            // Create valid request (This is simple as we made ApplicationId > 0 equal success
            ExternalRequestBase externalRequest = new ExternalRequestBase() { ApplicationId = 1 };
            // Validate our complicated request
            IInputValidationResult result = externalRequestBaseValidator.Validate(externalRequest);
            // We expect this to be successful
            Assert.AreEqual(ValidationResultType.Success, result.ValidationResult);
        }

        [TestMethod]
        public void TestExternalRequestBaseValidator_InvalidRequest()
        {
            // Initalize
            ExternalRequestBaseValidator externalRequestBaseValidator = new ExternalRequestBaseValidator();
            // Create invalid request (This is simple as we made ApplicationId > 0 equal success
            ExternalRequestBase externalRequest = new ExternalRequestBase() { ApplicationId = 0 };
            // Validate our complicated request
            IInputValidationResult result = externalRequestBaseValidator.Validate(externalRequest);
            // We expect this to be error
            Assert.AreEqual(ValidationResultType.Error, result.ValidationResult);
        }
    }
}
