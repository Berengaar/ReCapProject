using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        //Veri tabanı tablosu olmadığı için IEntity inheritance'ı verilmez
        //Dto join tablolarıdır.

        public int CarId { get; set; }
        public int CategoryId { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public int ColorId { get; set; }
    }
}
