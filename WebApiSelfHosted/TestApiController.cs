using System.Collections.Generic;
using System.Web.Http;

namespace WebApiSelfHosted
{
    public class TestApiController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "item 1", "item 2" };
        }

        public string Get(int id)
        {
            return string.Format("item with id = {0}", id);
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
