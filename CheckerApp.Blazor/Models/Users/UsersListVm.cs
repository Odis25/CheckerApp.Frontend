using System.Collections.Generic;

namespace CheckerApp.Blazor.Models.Users
{
    public class UsersListVm
    {
        public ICollection<UserDto> Users { get; set; }
    }
}
