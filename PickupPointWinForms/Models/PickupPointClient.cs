using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickupPointWinForms.Models
{
    public class PickupPointClient
    {
        public int Id { get; set; }             
        public string Name { get; set; }        
        public string Address { get; set; }     
        public string OpeningHours { get; set; } 
        public string ContactNumber { get; set; } 
    }
}
