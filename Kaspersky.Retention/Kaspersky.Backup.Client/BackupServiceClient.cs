using System;
using System.Collections.Generic;
using System.Linq;
using Kaspersky.Backup.Client.Contracts;
using Kaspersky.Backup.Client.Entities;

namespace Kaspersky.Backup.Client
{
    public sealed class BackupServiceClient : IBackupServiceClient
    {
        private static readonly object LockObject = new object();
        private static readonly IList<BackupRecord> BackupRecords = new List<BackupRecord>();

        public IReadOnlyCollection<BackupRecord> Get()
        {
            lock (LockObject)
                return BackupRecords.ToArray();
        }

        public void Add(BackupRecord backup)
        {
            lock (LockObject)
                BackupRecords.Add(backup);
        }

        public void Remove(Guid id)
        {
            lock (LockObject)
            {
                var backup = BackupRecords.SingleOrDefault(x => x.Id.Equals(id));
                if (backup.Equals(default))
                    return;

                BackupRecords.Remove(backup);
            }
        }
    }
}