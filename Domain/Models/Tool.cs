using System;
using System.Collections.Generic;

namespace Vuttr.API.Domain.Models
{
    public class Tool
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public IList<string> Tags { get; set; }
    }
}