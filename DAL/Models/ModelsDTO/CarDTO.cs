using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.ModelsDTO;

public class CarDTO
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Category { get; set; }
    public string DateCreated { get; set; }
    public string StandartColor { get; set; }
    public int Count { get; set; }
    public decimal Price { get; set; }
}
