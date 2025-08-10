

namespace Dashboard.Application.DTOs.ExpertNotes
{
    public sealed class UpdateExpertNote
    {
        public int Id { get; private set; }
        public string? Note { get; private set; }
        public int UpdaterId { get; private set; }
        public int CustomerId { get; set; }


    }
}
