﻿using APIv2.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IHistorialsectorService
    {
        public List<HistorialsectorDTO> GetManyByLegajo(int legajoEmp);
    }
}

