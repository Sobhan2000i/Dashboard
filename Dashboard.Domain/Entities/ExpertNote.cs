using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.Domain.Entities
{
    public sealed class ExpertNote
    {
        public int Id { get; private set; }
        public int CustomerId { get; private set; }
        public string? Note { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public string? CreaterId { get; private set; }
        public Customer? Customer { get; private set; }

        private ExpertNote() { }
        public ExpertNote( int customerId, string note, string createrId)
        { 

            if (customerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(customerId), "CustomerId must be greater than zero.");

            if (string.IsNullOrWhiteSpace(note))
                throw new ArgumentException("Note cannot be empty.", nameof(note));

            if (string.IsNullOrWhiteSpace(CreaterId))
                throw new ArgumentException("CreaterId cannot be empty.", nameof(CreaterId));

            CustomerId = customerId;
            Note = note;
            CreaterId = createrId;
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow;
        }
        public void Update(int customerId, string note, string createrId)
        {
            if (customerId <= 0)
                throw new ArgumentOutOfRangeException(nameof(customerId), "CustomerId must be greater than zero.");

            if (string.IsNullOrWhiteSpace(note))
                throw new ArgumentException("Note cannot be empty.", nameof(note));

            if (string.IsNullOrWhiteSpace(createrId))
                throw new ArgumentException("CreaterId cannot be empty.", nameof(createrId));

            CustomerId = customerId;
            Note = note;
            CreaterId = createrId;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
