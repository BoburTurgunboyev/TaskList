using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskList.Domain.Dtos;

namespace TaskList.Application.Services.AccountServ
{
    public interface IAccountService
    {
        public ValueTask<bool> Login(LoginDto loginDto);
        public ValueTask<bool> Registor(RegistorDto registorDto);
    }
}
