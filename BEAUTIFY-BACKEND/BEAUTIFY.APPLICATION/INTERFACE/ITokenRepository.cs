using BEAUTIFY.DOMAIN.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEAUTIFY.APPLICATION.INTERFACE
{
    public interface ITokenRepository
    {

        string GenerateAccessToken(AppUser user);
        string GenerateRefreshToken();
        Task<bool> ValidateRefreshToken(string token);
    }

}
