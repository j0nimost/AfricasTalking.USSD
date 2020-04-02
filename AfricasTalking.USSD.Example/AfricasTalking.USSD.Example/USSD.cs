using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AfricasTalking.USSD.Example
{
    public class USSD
    {
        [Required]
        public string SessionId { get; set; }
        public string ServiceCode { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Text { get; set; }
    }
}
