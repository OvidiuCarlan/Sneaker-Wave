using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string firstName { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string lastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string salt { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }       
        public string phone { get; set; }
    }
}
