using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PowerDiary.TestApp.Shared
{
    public class PaginationDto
    {
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }

        [JsonIgnore]
        public int ToSkip { get { return PageSize * (PageNumber - 1); } }
    }
}
