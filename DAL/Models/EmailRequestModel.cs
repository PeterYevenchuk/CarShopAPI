﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class EmailRequestModel
{
    public string RecipientEmail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
