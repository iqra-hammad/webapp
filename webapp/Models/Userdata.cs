using System;
using System.Collections.Generic;

namespace webapp.Models;

public partial class Userdata
{
    public int UId { get; set; }

    public string? UName { get; set; }

    public string? UEmail { get; set; }

    public int? Userrole { get; set; }

    public int? Usersuggestion { get; set; }

    public virtual Role? UserroleNavigation { get; set; }

    public virtual Suggestion? UsersuggestionNavigation { get; set; }
}
