using AutoMapper;
using Core.Dto.DtoBookingDetail;
using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly IRepository<BookingDetailEntity> _bookingDetailRepository;
        private readonly IMapper _mapper;

        public BookingDetailService(IRepository<BookingDetailEntity> bookingDetailRepository, IMapper mapper)
        {
            _bookingDetailRepository = bookingDetailRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDetailDto>> GetAllBookingDetailsAsync()
        {
            var bookingDetails = await _bookingDetailRepository.GetAll();
            return _mapper.Map<IEnumerable<BookingDetailDto>>(bookingDetails);
        }

        public async Task<BookingDetailDto> GetBookingDetailByIdAsync(int id)
        {
            var bookingDetail = await _bookingDetailRepository.GetByID(id);
            return _mapper.Map<BookingDetailDto>(bookingDetail);
        }

        public async Task CreateBookingDetailAsync(CreateBookingDetailDto createBookingDetailDto)
        {
            var bookingDetail = _mapper.Map<BookingDetailEntity>(createBookingDetailDto);
            await _bookingDetailRepository.Insert(bookingDetail);
            await _bookingDetailRepository.Save();
        }

        public async Task UpdateBookingDetailAsync(UpdateBookingDetailDto updateBookingDetailDto)
        {
            var bookingDetail = await _bookingDetailRepository.GetByID(updateBookingDetailDto.Id);
            if (bookingDetail == null)
                throw new KeyNotFoundException("BookingDetail not found.");

            _mapper.Map(updateBookingDetailDto, bookingDetail);
            await _bookingDetailRepository.Update(bookingDetail);
        }

        public async Task DeleteBookingDetailAsync(int id)
        {
            var bookingDetail = await _bookingDetailRepository.GetByID(id);
            if (bookingDetail == null)
                throw new KeyNotFoundException("BookingDetail not found.");

            await _bookingDetailRepository.Delete(bookingDetail);
        }
    }
}
