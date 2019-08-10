using System;
using System.Collections.Generic;
using Kaspersky.Backup.Client.Entities;

namespace Kaspersky.Backup.Client.Contracts
{
    public interface IBackupServiceClient
    {
        IReadOnlyCollection<BackupRecord> Get();

        void Add(BackupRecord backup);

        void Remove(Guid id);
    }
}