using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class Order
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public int IdCar { get; set; }
    public int CountCars { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime DateOrdered { get; set; }
}
