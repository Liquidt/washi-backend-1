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
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccountResponse> SaveAsync(Account account)
        {
            try
            {
                Account _account = null;
                bool result = account.AccountType.Equals("Musician");
                if (result == true)
                {
                    _account = new Customer();
                }
                else
                {
                    _account = new Laundry();
                }
                await _accountRepository.AddAsync(account);
                await _unitOfWork.CompleteAsync();

                return new AccountResponse(account);
            }
            catch (Exception ex)
            {
                return new AccountResponse($"An error ocurred while saving the account: {ex.Message}");
            }
        }

        public async Task<AccountResponse> GetByIdAsync(int id)
        {
            var existingAccount = await _accountRepository.FindById(id);

            if (existingAccount == null)
                return new AccountResponse("Account not found");
            return new AccountResponse(existingAccount);
        }

        public async Task<IEnumerable<Account>> ListAsync()
        {
            return await _accountRepository.ListAsync();
        }
    }
}
