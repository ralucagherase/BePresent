using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BePresent.Repository.Implementation.Entities;
using BePresent.Repository.Interface;
using BePresent.Services.Interface;
using Microsoft.Extensions.Logging;

namespace BePresent.Services.Implementation
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AttendanceService> _logger;
        private readonly IRepository<Attendance> _attendanceRepository;

        public AttendanceService(IUnitOfWork unitOfWork, ILogger<AttendanceService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _attendanceRepository = _unitOfWork.GetRepository<Attendance>();
        }
        public async Task<IEnumerable<Attendance>> GetAttendances()
        {
            return await _attendanceRepository.GetAllAsync();
        }

        public async Task<Attendance> GetAttendance(DateTime dateTime)
        {
            return await _attendanceRepository.FirstOrDefaultAsync(m => m.DateTime == dateTime);
        }

        public async Task<Attendance> CreateAttendance(Attendance attendance)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAttendance(DateTime dateTime, Attendance attendance)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAttendance(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
