﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bad_eend
{
    public interface IBadeendDataContext
    {
        // Posts methods
        IEnumerable<Posts> GetPosts();
        IEnumerable<Posts> GetPosts(int user_id);
        Posts GetPost(int post_id);

        void AddPost(Posts post);
        void UpdatePost(int id, Posts post);
        void UpdateLastPosted(int user_id, DateTime d);
        void DeletePost(int post_id);

        // User methods
        IEnumerable<Users> GetUsers();
        Users GetUser(int user_id);
        void AddUser(Users user);
<<<<<<< HEAD
        void UpdateLastPosted(int user_id, DateTime d);
        void DeletePost(int post_id);
        void DeleteUser(int id);
=======
        void DeleteUser(int user_id);
>>>>>>> c00321f90174c076738d382b88dbb57f47c8c2a8
    }
}
