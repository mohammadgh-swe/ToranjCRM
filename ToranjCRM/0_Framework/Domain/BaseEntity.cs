namespace ProjectFramework.Domain
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreatedBy { get; set; }   //By Author name
        public DateTime UpdateAt { get; set; }
        public string UpdatedBy { get; set; }   //By Author name
        public bool IsDeleted { get; set; }


        public BaseEntity()
        {
            CreateAt = DateTime.Now;
            CreatedBy = " ";
            UpdateAt = CreateAt;
            UpdatedBy = " ";
            IsDeleted = false;
        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
