using System;

namespace Kaspersky.Backup.Client.Entities
{
    public readonly struct BackupRecord : IEquatable<BackupRecord>
    {
        public BackupRecord(Guid id, DateTimeOffset created)
        {
            Id = id;
            Created = created;
        }

        public Guid Id { get; }
        
        public DateTimeOffset Created { get; }

        public bool Equals(BackupRecord other)
            => Id.Equals(other.Id) && Created.Equals(other.Created);

        public override bool Equals(object obj)
            => obj is BackupRecord other && Equals(other);

        public override int GetHashCode()
            => (Id.GetHashCode() * 397) ^ Created.GetHashCode();
    }
}