using PunchcodeStudios.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchcodeStudios.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(PunchcodeEmail email);
    }
}
