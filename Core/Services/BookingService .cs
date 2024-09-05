using AutoMapper;
using Core.Dto.DtoBooking;
using Core.Entities;
using Core.Interfaces;
using Data.Entities;

namespace Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRepository<BookingEntity> _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IRepository<BookingEntity> bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAll();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetByID(id);
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<int> CreateBookingAsync(CreateBookingDto createBookingDto)
        {
            var booking = _mapper.Map<BookingEntity>(createBookingDto);
            booking.BookingDetails = createBookingDto.BookingDetails.Select(bd =>
                new BookingDetailEntity
                {
                    ServiceId = bd.ServiceId,
                    ScheduledDate = bd.ScheduledDate,
                    Address = bd.Address,
                    Price = bd.Price
                }).ToList();

            await _bookingRepository.Insert(booking);
            await _bookingRepository.Save();

            return booking.Id; 
        }

        public async Task UpdateBookingAsync(UpdateBookingDto updateBookingDto)
        {
            var booking = await _bookingRepository.GetByID(updateBookingDto.Id);
            if (booking == null)
                throw new KeyNotFoundException("Booking not found.");

            _mapper.Map(updateBookingDto, booking);

            
            await _bookingRepository.Update(booking);
        }
        public async Task UpdatePaymentStatusAsync(int id, string status)
        {
            var booking = await _bookingRepository.GetByID(id);
            if (booking == null)
                throw new KeyNotFoundException("Booking not found.");

            booking.PaymentStatus = status;
            await _bookingRepository.Update(booking);
            await _bookingRepository.Save();
        }
        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _bookingRepository.GetByID(id);
            if (booking == null)
                throw new KeyNotFoundException("Booking not found.");

            await _bookingRepository.Delete(booking);
        }
    }
}
