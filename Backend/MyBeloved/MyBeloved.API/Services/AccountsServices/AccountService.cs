﻿using Microsoft.EntityFrameworkCore;
using MyBeloved.API.DataContext;
using MyBeloved.API.DTOs;
using MyBeloved.API.Models;

namespace MyBeloved.API.Services.AccountsServices
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;

        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<Account>> CreateAccountAsync(string nickname, string email)
        {
            Response<Account> response = new Response<Account>();
            AccountDTO newAccount = new AccountDTO
            {
                NickName = nickname,
                Email = email
            };

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

                if (account == null)
                {
                    response.Message = "Account not found";
                    response.Success = false;
                    return response;
                }

                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();

                response.Data = _context.Accounts.OrderBy(a => a.Id).ToList();

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
                Account account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);

                if (account == null)
                {
                    response.Message = "Account not found";
                    response.Success = false;
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

        public async Task<Response<Account>> UpdateAccountByIdAsync(AccountDTO editedAccount)
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
                response.Data = _context.Accounts.OrderBy(a => a.Id).ToList();

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

        public async Task<Response<Account>> GenerateNewPartnerLinkById(int id)
        {
            Response<Account> response = new Response<Account>();

            try
            {
                Account account = _context.Accounts.FirstOrDefault(a => a.Id == id);

                if (account == null)
                {
                    response.Message = "Account not found";
                    response.Success = false;
                    return response;
                }

                account.InvitePartnerLink = Guid.NewGuid();
                account.UpdatedAt = DateTime.UtcNow;
                _context.Accounts.Update(account);
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
    }
}
