using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class Car
{
    public Guid Id { get; set; }
    public string Brand { get; set; }
    public string Model{ get; set; }
    public string Category { get; set; }
    public string DateCreated { get; set; }
    public string StandartColor { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}
