using BEAUTIFY.APPLICATION.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEAUTIFY.APPLICATION.INTERFACE
{

    public interface IAuthRepository
    {
        Task<AuthResultDto> RegisterAsync(RegisterModel model);
        Task<AuthResultDto> LoginAsync(LoginDto model);
        Task<bool> IsLockedOutAsync(string userId);
        Task<bool> ValidateCaptchaAsync(string captchaResponse);
    }

}
