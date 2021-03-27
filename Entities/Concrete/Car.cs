﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int CategoryId { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
    }
}
