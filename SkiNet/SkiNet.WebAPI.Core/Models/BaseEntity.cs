using System.ComponentModel.DataAnnotations.Schema;

namespace SkiNet.WebAPI.Core.Models
{
    public class BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
