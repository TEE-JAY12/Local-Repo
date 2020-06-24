using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using To_show.Models;

namespace To_show.Controllers.API
{
    public class TestController : ApiController
    {

        private ApplicationDbContext _context;

        public TestController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {

            var gig = _context.info
                .Single(g => g.Id == id);

            if (gig.IsCanceled)
                return NotFound();


            gig.IsCanceled = true;

            _context.SaveChanges();
            return Ok();
        }
    }
}
