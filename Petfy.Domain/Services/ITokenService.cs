using Petfy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
