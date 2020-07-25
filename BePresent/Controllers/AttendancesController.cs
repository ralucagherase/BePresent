using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BePresent.Repository.Implementation.Entities;
using BePresent.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BePresent.Controllers
{
    [Route("api/attendances")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private readonly ILogger<AttendancesController> _logger;
        public AttendancesController(IAttendanceService attendanceService, ILogger<AttendancesController> logger)
        {
            _attendanceService = attendanceService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendances()
        {
            var attendances = await _attendanceService.GetAttendances();
            if (attendances.ToList().Any())
            {
                return Ok(attendances);
            } 
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendance([FromBody] DateTime id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendance = await _attendanceService.GetAttendance(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return Ok(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> PostAttendance([FromBody] Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdAttendance = await _attendanceService.CreateAttendance(attendance);

            return CreatedAtAction("GetAttendance", new { id = attendance.DateTime }, createdAttendance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendance([FromRoute] DateTime id, [FromBody] Attendance attendance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attendance.DateTime)
            {
                return BadRequest();
            }

            await _attendanceService.UpdateAttendance(id, attendance);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance([FromRoute] DateTime id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var attendance = await _attendanceService.GetAttendance(id);
            if (attendance == null)
            {
                return NotFound();
            }

            await _attendanceService.DeleteAttendance(id);

            return NoContent();
        }

    }
}