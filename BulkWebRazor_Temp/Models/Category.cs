﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkWebRazor_Temp.Models;

public class Category
{
    public int Id { get; set; }
    [Required]
    [DisplayName("Category Name")]
    [MaxLength(30)]
    public string Name { get; set; } = string.Empty;
    [DisplayName("Display Order")]
    [Range(1,100, ErrorMessage ="Display Order must be between 1-100")]
    public int DisplayOrder { get; set; }
}
