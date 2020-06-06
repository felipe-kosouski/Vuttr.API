using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vuttr.API.Domain.Models
{
    public class Tool
    {
        public Tool()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
        
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "{0} is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the {0} field is {1} characters")]
        public string Title { get; set; }
        
        public string Link { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}