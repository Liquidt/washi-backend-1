using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Domain.Repositories;
using Washi.API.Domain.Services;
using Washi.API.Domain.Services.Communications;

namespace Washi.API.Services
{
    public class LaundryService : ILaundryService
    {
        private readonly ILaundryRepository _laundryRepository;
        public readonly IUnitOfWork _unitOfWork;

        public LaundryService(ILaundryRepository laundryRepository, IUnitOfWork unitOfWork)
        {
            _laundryRepository = laundryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Laundry>> ListAsync()
        {
            return await _laundryRepository.ListAsync();
        }

        public async Task<LaundryResponse> GetByIdAsync(int id)
        {
            var existingLaundry = await _laundryRepository.FindById(id);

            if (existingLaundry == null)
                return new LaundryResponse("Laundry not found");
            return new LaundryResponse(existingLaundry);
        }

        public async Task<LaundryResponse> UpdateAsync(int id, Laundry laundry)
        {
            var existingLaundry = await _laundryRepository.FindById(id);

            if (existingLaundry == null)
                return new LaundryResponse("Laundry not found");
            existingLaundry.Address = laundry.Address;
            existingLaundry.CorporationName = laundry.CorporationName;
            existingLaundry.FirstName = laundry.LastName;
            existingLaundry.PhoneNumber = laundry.PhoneNumber;
            existingLaundry.LastName = laundry.LastName;
            try
            {
                _laundryRepository.Update(existingLaundry);
                await _unitOfWork.CompleteAsync();

                return new LaundryResponse(existingLaundry);
            }
            catch (Exception ex)
            {
                return new LaundryResponse($"An error has ocurred while updating laundry: {ex.Message}");
            }
        }

        public async Task<LaundryResponse> DeleteAsync(int id)
        {
            var existingLaundry = await _laundryRepository.FindById(id);

            if (existingLaundry == null)
                return new LaundryResponse("Laundry not found");

            try
            {
                _laundryRepository.Remove(existingLaundry);
                await _unitOfWork.CompleteAsync();

                return new LaundryResponse(existingLaundry);
            }
            catch (Exception ex)
            {
                return new LaundryResponse($"An error has ocurred while deleting laundry: {ex.Message}");
            }
        }
    }
}