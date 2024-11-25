using System;
using System.Collections.Generic;

namespace webapp.Models;

public partial class Suggestion
{
    public int SuggestionId { get; set; }

    public string? Suggestions { get; set; }

    public virtual ICollection<Userdata> Userdata { get; set; } = new List<Userdata>();
}
