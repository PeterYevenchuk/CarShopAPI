﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class Order
{
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime DateOrdered { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CarId { get; set; }
    public Guid? AdditionalFunctionalityId { get; set; }
    public Car Car { get; set; }
    public User User { get; set; }
    public AddFunc AdditionalFunctionality { get; set; }
}
