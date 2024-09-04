using System.ComponentModel.DataAnnotations;

namespace ChangeRequestAPI.Data
{
   
    public class ChangeRequest
    {
        [Key, Required]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public string Category { get; set; }

        public string Status {  get; set; }

    }
}
