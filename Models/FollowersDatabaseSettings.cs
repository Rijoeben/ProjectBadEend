using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestMongoDB.Models
{
    public class FollowersDatabaseSettings : IFollowersDatabaseSettings
    {
        public string FollowersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFollowersDatabaseSettings
    {
        string FollowersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
