﻿using KKKKPPP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KKKKPPP.Data.Models.ClientSide;

namespace KKKKPPP.Data.Interfaces
{
    public interface IСвязь_Материал_Картина
    {
        IEnumerable<Связь_Материал_Картина> Pic_Material { get; }
    }
}
