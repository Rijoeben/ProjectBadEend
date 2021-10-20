using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteDB;

namespace Bad_eend
{
    public class BadeendDatabase : IBadeendDataContext
    {
        LiteDatabase database = new LiteDatabase(@"data.db");

        IEnumerable<Posts> IBadeendDataContext.GetPosts()
        {
            return database.GetCollection<Posts>("Posts").FindAll();
        }

        IEnumerable<Posts> IBadeendDataContext.GetPosts(int user_id)
        {
            return database.GetCollection<Posts>("Posts").Find(p => p.User_Id == user_id);
        }
        Posts IBadeendDataContext.GetPost(int post_id)
        {
            return database.GetCollection<Posts>("Posts").FindById(post_id);
        }

        void IBadeendDataContext.AddPost(Posts post)
        {
            Users u = database.GetCollection<Users>("Users").FindById(post.User_Id);
            if (u.Last_Posted.AddDays(1) < DateTime.Now) database.GetCollection<Posts>("Posts").Insert(post);
        }

        void IBadeendDataContext.UpdatePost(int id, Posts post)
        {
            Posts entity = database.GetCollection<Posts>("Posts").FindById(id);
            entity.Title = post.Title;
            entity.Content = post.Content;
            entity.Likes = post.Likes;

            database.GetCollection<Posts>("Posts").Update(entity);
        }
        void IBadeendDataContext.DeletePost(int post_id) 
        {
            database.GetCollection<Posts>("Posts").Delete(post_id);
        }


        IEnumerable<Users> IBadeendDataContext.GetUsers()
        {
            return database.GetCollection<Users>("Users").FindAll();
        }
        Users IBadeendDataContext.GetUser(int user_id)
        {
            return database.GetCollection<Users>("Users").FindById(user_id);
        }
        void IBadeendDataContext.AddUser(Users user)
        {
            database.GetCollection<Users>("Users").Insert(user);
        }
        void IBadeendDataContext.DeleteUser(int id)
        {
            database.GetCollection<Users>("Users").Delete(id);
        }
        void IBadeendDataContext.UpdateLastPosted(int user_id, DateTime d)
        {
            Users u = database.GetCollection<Users>("Users").FindById(user_id);
            u.Last_Posted = d;

            database.GetCollection<Users>("Users").Update(u);
        }

        public void DeleteUser(int user_id)
        {
            database.GetCollection<Users>("Users").Delete(user_id);
        }
    }
}
