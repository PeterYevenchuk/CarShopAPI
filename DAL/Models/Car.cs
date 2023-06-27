using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model{ get; set; }
    public string Category { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}
