using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public class CardDTO
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string SecurityNumber { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
