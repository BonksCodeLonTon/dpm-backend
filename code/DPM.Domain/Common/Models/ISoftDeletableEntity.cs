namespace DPM.Domain.Common.Models
{
    public interface ISoftDeletableEntity
    {
        public bool IsDeleted { get; set; }
    }
}