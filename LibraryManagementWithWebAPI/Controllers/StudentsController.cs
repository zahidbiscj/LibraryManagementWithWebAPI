using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagementWithWebAPI;

namespace LibraryManagementWithWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IMembershipService _MembershipService;

        public StudentsController(IMembershipService membership)
        {
            _MembershipService = membership;
        }

        // GET api/Student
        [HttpGet]
        public ActionResult<IList<Student>> Get()
        {
            return _MembershipService.ShowAllStudent();
        }

        // GET api/Students/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            return _MembershipService.ShowMemberProfile(id);
        }

        // POST api/Students
        [HttpPost]
        public ActionResult Post([FromBody] Student student)
        {
            try
            {
               var IsEnrollled = _MembershipService.EnrollMembership(student.Id, student.Name);
                if (IsEnrollled) { return Ok("Saved Successfully"); }
                else { return NotFound(); }
            }
            catch (Exception e)
            { 
                return BadRequest(e.Message);
            }
           
        }



        // PUT api/Students/UpdateStudent
        [HttpPut("/api/Students/UpdateStudent/{id}")]
        public ActionResult Put(int id, [FromBody] Student student)
        {
            
            try
            {
                bool IsUpdated = _MembershipService.UpdateProfile(id, student);
                if (IsUpdated)
                {
                    return Ok("Updated Successfully");
                }
                else
                {
                    return NotFound("ID = "+id+" Not found");
                }
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // DELETE api/Students/DeleteStudent/5
        [HttpDelete("/api/Students/DeleteStudent/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _MembershipService.DeleteStudent(id);
                return Ok("Deleted Successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }
    }
}
