using System;
using System.Collections.Generic;
using Application.Common.DTOs.Common;

namespace Application.Common.DTOs.Cinema;

public class CreateCinemaDTO : ICinemaDTO
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
}

