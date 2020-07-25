using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BePresent.Repository.Implementation.Entities;

namespace BePresent.Services.Interface
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAttendances();
        Task<Attendance> GetAttendance(DateTime dateTime);
        Task<Attendance> CreateAttendance(Attendance attendance);
        Task UpdateAttendance(DateTime dateTime, Attendance attendance);
        Task DeleteAttendance(DateTime dateTime);
    }
}
