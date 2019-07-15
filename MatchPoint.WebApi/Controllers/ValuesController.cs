using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchPoint.Core.Models;
using MatchPoint.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MatchPoint.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly MatchPointContext context;
        public ValuesController(MatchPointContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<Match[]> Get()
        {
            var matches = this.context.Matches.Include(m => m.Template).ToArray();
            return matches;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
