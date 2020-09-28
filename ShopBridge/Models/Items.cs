using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridge.Models
{
    public class Items
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(1500)]
        public string Desc { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime? DateModify { get; set; }
    }
}