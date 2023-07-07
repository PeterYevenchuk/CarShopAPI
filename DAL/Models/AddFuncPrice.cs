using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class AddFuncPrice
{
    public Guid Id { get; set; }
    public decimal ColorPrice { get; set; }
    public decimal GPSNavigationPrice { get; set; }
    public decimal ParkingSensorsPrice { get; set; }
    public decimal PremiumSoundSystemPrice { get; set; }
    public decimal LeatherSeatsPrice { get; set; }
    public Guid? CarId { get; set; }
    public Car Car { get; set; }
}
