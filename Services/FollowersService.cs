using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Bad_eend.Models;

namespace Bad_eend.Services
{
    public class FollowersService
    {
        private readonly IMongoCollection<Followers> _followers;

        public FollowersService(IFollowersDatabaseSettings settings)
        {

            MongoClientSettings setting = MongoClientSettings.FromConnectionString("mongodb+srv://Admin:Opperbadeend@socialconnections.bidnv.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            MongoClient client = new MongoClient(setting);
            var database = client.GetDatabase("FollowersDb");


            /*MongoClient client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("FollowersDb");*/


            _followers = database.GetCollection<Followers>("Followers");
        }

        public List<Followers> Get() =>
            _followers.Find(followers => true).ToList();

        public Followers Get(string id) =>
            _followers.Find<Followers>(followers => followers.Id == id).FirstOrDefault();

        public void Create(string userId)
        {
            Followers user = new Followers();
            user.Id = userId;
            user.list_followers = new List<string>();
            _followers.InsertOne(user);
        }

        internal void Update(string id, string follower)
        {
            Followers flw = _followers.Find<Followers>(followers => followers.Id == id).FirstOrDefault();
            flw.list_followers.Add(follower);
            _followers.ReplaceOne(followers => followers.Id == id, flw);
        }

        /*public void Update(string id, string follower) =>
            _followers.InsertOne(follower);*/

        public void Remove(Followers followersIn) =>
            _followers.DeleteOne(followers => followers.Id == followersIn.Id);

        public void Remove(string id) =>
            _followers.DeleteOne(followers => followers.Id == id);
    }
}
