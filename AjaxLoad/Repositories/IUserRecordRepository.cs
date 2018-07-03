using AjaxLoad.Models;
using GenFu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AjaxLoad.Repositories
{
    public interface IUserRecordRepository
    {
        List<UserRecord> GetUserRecords();
    }
}
