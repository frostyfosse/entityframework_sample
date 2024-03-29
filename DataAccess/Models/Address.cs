﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Address : ModelBase
    {
        [Required]
        [MaxLength(200)]
        public string? StreetAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string? City { get; set; }

        [Required]
        [MaxLength(50)]
        public string? State { get; set; }

        [Required]
        [MaxLength(10)] // 12345-0000
        [Column(TypeName = "varchar(10)")]
        public string? ZipCode { get; set; }
    }
}
