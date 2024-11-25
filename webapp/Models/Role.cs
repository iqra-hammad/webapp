using System;
using System.Collections.Generic;

namespace webapp.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? URole { get; set; }

    public virtual ICollection<Userdata> Userdata { get; set; } = new List<Userdata>();
}
