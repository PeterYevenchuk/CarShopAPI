using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class AdditionalFunctionalityDTO
{
    public string? Color { get; set; }
    public bool GPSNavigation { get; set; }
    public bool ParkingSensors { get; set; }
    public bool PremiumSoundSystem { get; set; }
    public bool LeatherSeats { get; set; }
}
