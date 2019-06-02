using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy;
using Nancy.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nancy.Api
{
    [TestClass]
    public class TestHelloWorld
    {

        private Browser _browser;

        [TestInitialize]
        public void Init()
        {
            var bootstrapper = new DefaultNancyBootstrapper();
            _browser = new Browser(bootstrapper);
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            _browser = null;
        }

        [TestMethod]
        public void If_HelloWord_Is_Called_Then_Return_OK_And_ExpectedResult()
        {
            var name = "Test";
            var expectedResponse = string.Format("Hello {0} ! ", name);

            var route = "/v1/hello/{0}";
            var request = string.Format(route, name);
            var result = _browser.Get(request, with =>
                 {
                     with.HttpRequest();
                 });

            var response = result.Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.Body.AsString().Equals(expectedResponse));
        }
    }
}
