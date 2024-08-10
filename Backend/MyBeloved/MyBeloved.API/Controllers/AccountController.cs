using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<Response<Account>>> CreateAccount(string nickname, string email)
        {
            return Ok(await _accountService.CreateAccountAsync(nickname, email));
        }

        [HttpGet("GetAccount/{id}")]
        public async Task<ActionResult<Response<Account>>> GetAccountById(int id)
        {
            return Ok(await _accountService.GetAccountByIdAsync(id));
        }

        [HttpGet("GetAccounts")]
        public async Task<ActionResult<Response<List<Account>>>> GetAllAccounts()
        {
            return Ok(await _accountService.GetAllAccountsAsync());
        }

        [HttpDelete("DeleteAccount/{id}")]
        public async Task<ActionResult<Response<List<Account>>>> DeleteAccountById(int id)
        {
            return Ok(await _accountService.DeleteAccountByIdAsync(id));
        }

        [HttpPut("UpdateAccount/{id}")]
        public async Task<ActionResult<Response<Account>>> UpdateAccountById(AccountDTO editedAccount)
        {
            return Ok(await _accountService.UpdateAccountByIdAsync(editedAccount));
        }

        [HttpPatch("GenerateNewInviteLink/{id}")]
        public async Task<ActionResult<Response<Account>>> GenerateNewInviteLink(int id)
        {
            return Ok(await _accountService.GenerateNewPartnerLinkById(id));
        }
    }
}
