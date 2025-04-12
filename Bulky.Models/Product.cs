﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Required]
    public string ISBN { get; set; } = string.Empty;
    [Required]
    public string Author { get; set; } = string.Empty;

    [Required]
    [DisplayName("List Price")]
    [Range(1,1000)]
    public double ListPrice { get; set; }

    [Required]
    [DisplayName("List Price for 1-50")]
    [Range(1, 1000)]
    public double Price { get; set; } 

    [Required]
    [DisplayName("List Price for 50+")]
    [Range(1, 1000)]
    public double Price50 { get; set; }

    [Required]
    [DisplayName("List Price for 100+")]
    [Range(1, 1000)]
    public double Price100 { get; set; }



    public int CategoryId { get; set; }
    
    [ForeignKey(nameof(CategoryId))]
    [ValidateNever]
    public Category Category { get; set; }


    [ValidateNever]
    public string ImageUrl { get; set; }
}
