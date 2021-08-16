using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
    namespace TojoAPI.Models
{
    public class TojoItem
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(false), Required]
        public bool IsComplete { get; set; }
    }
}
