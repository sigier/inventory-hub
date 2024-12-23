﻿using IMS.CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.UseCases.Activity.Interfaces
{
    public interface IProduceProductUseCase
    {
        Task ExecuteAsync(string productionNumber, Product product, int quantity, string doneBy);
    }
}
