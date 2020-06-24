using Gig_website.Dtos;
using Gig_website.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Gig_website.Controllers
{ 


    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost] 
        //public IHttpActionResult Attend ([FromBody]int gigId)
        public IHttpActionResult Attend(AttendanceDto dto)
        {   var userId = User.Identity.GetUserId();

            //var exists = _context.Attendance.Any(a => a.AttendeeId == userId && a.GigId == gigid);


            var exists = _context.Attendance.Any(a => a.AttendeeId == userId  && a.GigId == dto.GigId);

            if (exists)
                return BadRequest("The  attendance already exists.");
            var attendance = new Attendance
            {
               // GigId=gigId,
                GigId = dto.GigId,
                AttendeeId =userId
            };
            _context.Attendance.Add(attendance);
            _context.SaveChanges();
            return Ok(); 
        }
    }  
}
