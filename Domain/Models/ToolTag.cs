using System;

namespace Vuttr.API.Domain.Models
{
    public class ToolTag
    {
        public Guid ToolId { get; set; }
        public Tool Tool { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}