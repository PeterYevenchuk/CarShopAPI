using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class CarPhoto
{
    public int Id { get; set; }
    public int IdCar { get; set; }
    public string URLPhoto { get; set; }
}
