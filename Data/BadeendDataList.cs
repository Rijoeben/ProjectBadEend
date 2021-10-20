using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend
{
    public class BadeendDataList : IBadeendDataContext
    {
        List<Posts> postlist = new List<Posts>();
        List<Users> userlist = new List<Users>();

        public IEnumerable<Posts> GetPosts()
        {
            return postlist;
        }
        public IEnumerable<Posts> GetPosts(int user_id)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(int id, Posts post)
        {
            throw new NotImplementedException();
        }
        public Posts GetPost(int post_id)
        {
            throw new NotImplementedException();
        }
        public void DeletePost(int post_id)
        {
            throw new NotImplementedException();
        }




        public IEnumerable<Users> GetUsers()
        {
            return userlist;
        }
        public Users GetUser(int user_id)
        {
            throw new NotImplementedException();
        }
        public void AddUser(Users user)
        {
            userlist.Add(user);
        }
        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateLastPosted(int user_id, DateTime d)
        {
            throw new NotImplementedException();
        }

        public void AddPost(Posts post)
        {
            postlist.Add(post);
        }

        public void DeleteUser(int user_id)
        {
            throw new NotImplementedException();
        }
    }
}
