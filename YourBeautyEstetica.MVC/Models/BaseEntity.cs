using System.ComponentModel.DataAnnotations;

namespace YourBeautyEstetica.MVC.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
} 