using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nancy.Api
{
    public class HelloWorldModule : NancyModule
    {
        public HelloWorldModule()
        {
            Get("v1/hello/{name}", args =>
            {
                string name = args.name;
                var response = string.Format("Hello {0} ! ", name);
                return response;
            });
        }
    }
}
