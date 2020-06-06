using System.ComponentModel.DataAnnotations;

namespace Vuttr.API.Domain.DTO.Tool
{
    public class ToolForManipulationDto
    {
        [Required(ErrorMessage = "Tool {0} is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for the {0} field is {1} characters")]
        public string Title { get; set; }
        
        [MaxLength(255, ErrorMessage = "Maximum length for the {0} field is {1} characters")]
        public string Description { get; set; }
        
        [MaxLength(100, ErrorMessage = "Maximum length for the {0} field is {1} characters")]
        public string Link { get; set; }
        
        public string[] Tags { get; set; }
    }
}