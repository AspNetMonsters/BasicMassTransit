using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Messages.Commands
{
    public interface AddUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string EmailAddress { get; set; }
    }
}
