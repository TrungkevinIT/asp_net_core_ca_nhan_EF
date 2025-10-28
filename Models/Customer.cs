using System;
using System.Collections.Generic;

namespace BaiTapQuayVideo_EF.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string HashedPassword { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string CustomerAddress { get; set; } = null!;

    public byte? States { get; set; }
}
