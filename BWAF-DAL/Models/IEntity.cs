namespace BWAF_DAL.Models
{
    using System.ComponentModel.DataAnnotations;
    public interface IEntity
    {
        [Key]
        long Id { get; set; }
    }
}
