using Microsoft.AspNetCore.Mvc;
using MyBeloved.API.DataContext;
using MyBeloved.API.DTOs;
using MyBeloved.API.Models;
using MyBeloved.API.Services.AccountsServices;

namespace MyBeloved.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("CreateAccount")]
        public async Task<ActionResult<Response<Account>>> CreateAccount(AccountDTO newAccount)
        {
            return Ok(await _accountService.CreateAccountAsync(newAccount));
        }

        [HttpGet("GetAccount")]
        public async Task<ActionResult<Response<Account>>> GetAccountById(int id)
        {
            return Ok(await _accountService.GetAccountByIdAsync(id));
        }

        [HttpGet("GetAllAccounts")]
        public async Task<ActionResult<Response<List<Account>>>> GetAllAccounts()
        {
            return Ok(await _accountService.GetAllAccountsAsync());
        }

        [HttpDelete("DeleteAccount")]
        public async Task<ActionResult<Response<List<Account>>>> DeleteAccountById(int id)
        {
            return Ok(await _accountService.DeleteAccountByIdAsync(id));
        }

        [HttpPut("UpdateAccount")]
        public async Task<ActionResult<Response<Account>>> UpdateAccountById(AccountEditDTO editedAccount)
        {
            return Ok(await _accountService.UpdateAccountByIdAsync(editedAccount));
        }
    }
}
