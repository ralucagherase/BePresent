using BePresent.Repository.Implementation.Entities;
using BePresent.Repository.Interface;
using BePresent.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BePresent.Services.Implementation
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AttendanceService> _logger;
        private readonly IRepository<Attendance> _attendanceRepository;
        private readonly IRepository<Card> _cardRepository;

        public AttendanceService(IUnitOfWork unitOfWork, ILogger<AttendanceService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _attendanceRepository = _unitOfWork.GetRepository<Attendance>();
            _cardRepository = _unitOfWork.GetRepository<Card>();
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
            attendance.DateTime = System.DateTime.Now;
            Card card = await _cardRepository.FirstOrDefaultAsync(m => m.CardNo == attendance.CardNo);

            if (card == null)
            {
                card = new Card { CardNo = attendance.CardNo };

                await _cardRepository.AddAsync(card);
                await _unitOfWork.SaveChangesAsync();
            }

            await _attendanceRepository.AddAsync(attendance);
            await _unitOfWork.SaveChangesAsync();

            return await _attendanceRepository.FirstOrDefaultAsync(m=>m.DateTime == attendance.DateTime);
        }

        public async Task UpdateAttendance(DateTime dateTime, Attendance attendance)
        {
            var att = await _attendanceRepository.FirstOrDefaultAsync(m => m.DateTime == dateTime);
            att = attendance;

            _attendanceRepository.Update(att);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAttendance(Attendance attendance)
        {
             _attendanceRepository.Delete(attendance);
             await _unitOfWork.SaveChangesAsync();
        }
    }
}
