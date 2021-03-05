using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ModelDetailDto : IDto
    {
        public int ModelId { get; set; }
        public string BrandName { get; set; }
        public int ModelTypeId { get; set; }
        public string ModelName { get; set; }
        public string ModelYear { get; set; }

    }
}
