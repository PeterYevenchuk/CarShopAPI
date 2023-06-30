using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdCar { get; set; }
    public int CountCars { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime DateOrdered { get; set; }
    public User User { get; set; }
    public Car Car { get; set; }
}
