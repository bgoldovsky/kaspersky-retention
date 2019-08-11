using System;
using System.Collections.Generic;
using System.Linq;
using Kaspersky.Backup.Client.Contracts;
using Kaspersky.Backup.Client.Entities;

namespace Kaspersky.Backup.Client
{
    public sealed class BackupServiceClient : IBackupServiceClient
    {
        private readonly object _lockObject = new object();
        private readonly IList<BackupRecord> _backupRecords = new List<BackupRecord>();

        public IReadOnlyCollection<BackupRecord> Get()
        {
            lock (_lockObject)
                return _backupRecords.ToArray();
        }

        public void Add(BackupRecord backup)
        {
            lock (_lockObject)
                _backupRecords.Add(backup);
        }

        public void Remove(Guid id)
        {
            lock (_lockObject)
            {
                var backup = _backupRecords.SingleOrDefault(x => x.Id.Equals(id));
                if (backup.Equals(default))
                    return;

                _backupRecords.Remove(backup);
            }
        }
    }
}