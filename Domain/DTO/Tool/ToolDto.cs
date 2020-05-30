using System;
using System.Collections.Generic;

namespace Vuttr.API.Domain.DTO.Tool
{
    public class ToolDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
    }
}