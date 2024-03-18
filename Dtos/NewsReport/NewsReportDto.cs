using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Mappers;
namespace Backend.Dtos.NewsReport
{
    public class NewsReportDto
    {
        public int Id { get; set; }
        
        public string Text { get; set; } = string.Empty;
        public DateTime? DateOfReport { get; set; }
        
        public string Reporter { get; set; } = string.Empty;

        public string? ReporterTelephoneNumber { get; set; }
    
        public string? Email { get; set; }
    }
}
//