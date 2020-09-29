namespace Seamless.Model.Dtos
{
    public class DeleteResult
    {
        public DeleteResult(bool deleted)
        {
            this.Deleted = deleted;
        }
        public bool Deleted { get; set; }
    }
}
