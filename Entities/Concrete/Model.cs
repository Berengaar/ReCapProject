using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Model : IEntity
    {
        public int ModelId { get; set; }
        public string ModelYear { get; set; }
        public int BrandId { get; set; }
        public int ModelTypeId { get; set; }
        public string ModelName { get; set; }

    }
}
