using System;
using System.Collections.Generic;

namespace SamShop.Domain.Core.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public string Message { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
