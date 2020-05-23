using System;
using System.Collections.Generic;

namespace Vuttr.API.Domain.Models
{
    public class Tool
    {
        public Tool()
        {
            CreatedAt = DateTime.Now;
        }
        
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public IList<string> Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}