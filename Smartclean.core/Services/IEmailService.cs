using Smartclean.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartclean.core.Services
{
    public interface IEmailService
    {
        Task SendEmail(EmailDTO emailDTO);
    }
}
