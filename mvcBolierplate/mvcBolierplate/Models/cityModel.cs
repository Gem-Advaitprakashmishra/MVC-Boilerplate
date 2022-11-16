using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace mvcBolierplate.Models
{
    public class cityModel
    {
        public int CityId { get; set; }
        [DisplayName("City Name")]
        public string CityName { get; set; }
    }
}