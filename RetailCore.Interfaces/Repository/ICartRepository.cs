﻿using RetailCore.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailCore.Interfaces.Repository
{
    public interface ICartRepository : IRepository<RetailCore.Entities.EntityModels.Cart>
    {

    }
}