using Bad_eend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend.Data
{
    public interface IBadeendCredentials
    {
        IEnumerable<Credentials> GetCredentials();
        void DeleteCredentials(int id);
        void AddCredentials(Credentials creds);

        List<string> FindCredentials(string credString);
    }
}
