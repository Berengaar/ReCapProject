using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ListOfCarDetail:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string ModelYear { get; set; }
        public int ModelId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryId { get; set; }
        public decimal DailyPrice { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
