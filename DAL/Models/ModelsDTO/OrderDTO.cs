using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.ModelsDTO;

public class OrderDTO
{
    public Guid? CarId { get; set; }
    public Guid? UserId { get; set; }
    public AddFuncDTO AdditionalFunctionalityDTO { get; set; }
    public int CountCars { get; set; }
    public decimal TotalPrice { get; set; }
}
