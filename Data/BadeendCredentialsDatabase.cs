using Bad_eend.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend.Data
{
    
    public class BadeendCredentialsDatabase : IBadeendCredentials
    {

        public LiteDatabase database = new LiteDatabase(@"credentials.db");

        public void AddCredentials(Credentials creds)
        {
            HashingHandler hasher = new HashingHandler();
            creds.Salt = hasher.getSalt();
            creds.Password = hasher.Encrypt_Data(creds.Password + creds.Salt);

            database.GetCollection<Credentials>("Credentials").Insert(creds);
        }

        public void DeleteCredentials(int id)
        {
            database.GetCollection<Credentials>("Credentials").Delete(id);
        }

        public List<string> FindCredentials(string username)
        {
            Credentials entity = database.GetCollection<Credentials>("Credentials").Find(s => s.Username.Equals(username)).First();
            List<String> info = new List<string>();
            info.Add(entity.Password);
            info.Add(entity.Salt);
            info.Add(entity.Role);
            return info;
        }

        IEnumerable<Credentials> IBadeendCredentials.GetCredentials()
        {
            return database.GetCollection<Credentials>("Credentials").FindAll();
        }
    }
}
