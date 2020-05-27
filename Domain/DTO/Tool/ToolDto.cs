using System;
using System.Collections.Generic;
using Vuttr.API.Domain.DTO.Tag;

namespace Vuttr.API.Domain.DTO.Tool
{
    public class ToolDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public IList<TagDto> Tags { get; set; }
    }
}