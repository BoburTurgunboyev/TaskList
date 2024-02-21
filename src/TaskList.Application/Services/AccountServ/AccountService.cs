using Microsoft.AspNetCore.Identity;
using TaskList.Domain.Dtos;
using TaskList.Domain.Entities;



namespace TaskList.Application.Services.AccountServ
{
    public class AccountService : IAccountService
    {  
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public ValueTask<bool> Login(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> Registor(RegistorDto registorDto)
        {
            throw new NotImplementedException();
        }
    }
}
