using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PETITEC
{
    public interface IGoogleFitService
    {
        Task InitializeGoogleFit();
        Task<bool> AuthenticateAndSaveToken();
        Task<bool> IsAuthenticatedAsync();
    }
}
