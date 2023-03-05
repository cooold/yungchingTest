using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace yungchingTest.Models
{
    public class Meal
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "最多輸入50個字")]
        public string? Name { get; set; }
        public Nullable<int> Price { get; set; }
        [StringLength(50, ErrorMessage = "最多輸入50個字")]
        public string? Img { get; set; }
        public bool Removed { get; set; }
    }
}
