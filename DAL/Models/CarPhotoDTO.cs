﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class CarPhotoDTO
{
    public string URLPhoto { get; set; }
    public Guid? CarId { get; set; }
}
