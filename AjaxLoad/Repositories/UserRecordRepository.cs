using AjaxLoad.Models;
using GenFu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxLoad.Repositories
{
    public class UserRecordRepository : IUserRecordRepository
    {
        private List<UserRecord> _records;

        public UserRecordRepository()
        {
            _records = A.ListOf<UserRecord>(100);
        }

        public List<UserRecord> GetUserRecords() => _records;
    }
}
