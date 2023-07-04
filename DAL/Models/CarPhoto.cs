using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class CarPhoto
{
    public Guid Id { get; set; }
    public string URLPhoto { get; set; }
    public Car Car { get; set; }
}
