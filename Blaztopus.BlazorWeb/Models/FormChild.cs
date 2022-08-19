using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blaztopus.BlazorWeb.Models
{
    public class FormChild
    {
        public FormChild()
        {
            Forms = new HashSet<Form>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public ICollection<Form> Forms { get; set; }
    }
}
