using Microsoft.EntityFrameworkCore;
using MyBeloved.API.DataContext;
using MyBeloved.API.DTOs;
using MyBeloved.API.Models;
using MyBeloved.API.Validation;

namespace MyBeloved.API.Services.AccountsServices
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly ValidationEmptyOrNull<Account> _validation = new ValidationEmptyOrNull<Account>();

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Account>> CreateAccountAsync(AccountDTO newAccount)
        {
            Response<Account> response = new Response<Account>();

            try
            {
                if (newAccount == null)
                {
                    response.Message = "Account is null";
                    response.Success = false;
                    return response;
                }
                
                Account account = new Account
                {
                    NickName = newAccount.NickName,
                    Email = newAccount.Email
                };

                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                response.Data = account;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<List<Account>>> DeleteAccountByIdAsync(int id)
        {
            Response<List<Account>> response = new Response<List<Account>>();

            try
            {
                Account account = _context.Accounts.FirstOrDefault(a => a.Id == id);

                response = _validation.MultipleCheckIfNullOrEmpty(account);
                if (!response.Success)
                {
                    return response;
                }

                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();

                response.Data = _context.Accounts.ToList();

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<Account>> GetAccountByIdAsync(int id)
        {
            Response<Account> response = new Response<Account>();

            try
            {
                Account account = _context.Accounts.FirstOrDefault(a => a.Id == id);

                response = _validation.CheckIfNullOrEmpty(account);
                if (!response.Success)
                {
                    return response;
                }

                response.Data = account;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<Account>> UpdateAccountByIdAsync(AccountEditDTO editedAccount)
        {
            Response<Account> response = new Response<Account>();

            try
            {
                Account account = _context.Accounts.AsNoTracking().FirstOrDefault(a => a.Id == editedAccount.Id);
                
                if (editedAccount == null)
                {
                    response.Message = "Account not found";
                    response.Success = false;
                    return response;
                }

                account.NickName = editedAccount.NickName;
                account.Email = editedAccount.Email;
                account.UpdatedAt = DateTime.UtcNow;

                _context.Accounts.Update(account);
                await _context.SaveChangesAsync();

                response.Data = _context.Accounts.FirstOrDefault(a => a.Id == editedAccount.Id);
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }

        public async Task<Response<List<Account>>> GetAllAccountsAsync()
        {
            Response<List<Account>> response = new Response<List<Account>>();

            try
            {
                response.Data = _context.Accounts.ToList();

                if (response.Data.Count() == 0)
                {
                    response.Message = "No accounts found";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }
    }
}
