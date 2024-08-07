﻿using GenVibeServer.Asset.DAL.Database;
using GenVibeServer.Asset.DTO.Common;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using BCrypt.Net;
using GenVibeServer.Asset.DAL.IAuth;

namespace GenVibeServer.Asset.DAL.Auth
{
    public class AuthDAO : IAuthDAO
    {
        #region Singleton
        /*
        * @attribute error - contain error message
        */
        public string Error {  get; set; }
        public string User { get; set; }

        private IMongoCollection<UserDTO>? collection;
        AuthDAO()
        {
            var connector = Connector.Instance;
            this.collection = connector.Database.GetCollection<UserDTO>("User");
        }
        private static AuthDAO instance = null;
        private static readonly object Lock = new object();
        public static AuthDAO Instance
        {
            get
            {
                lock (Lock)
                {
                    return (instance == null) ? new AuthDAO() : instance;
                }
            }
        }
        #endregion

        #region Features

        /**
         * Login account to website
         * 
         * Check username and password match with data of user in database (db).
         * @return 
         *      - true: username and password match with data of user in db.
         *      - false: username and password do not match.
         * @params username - username need to check.
         * @params password - password need to check.
         */
        public bool Login(string username, string password)
        {
            try
            {
                // Check username in database
                var user = collection.Find(s => s.Username == $"{username}").FirstOrDefault();
                if (user == null)
                {
                    this.Error = "The username does not exist.";
                    return false;
                }

                // Check password input with password of object User
                bool isPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (!isPassword)
                {
                    this.Error = "Username or password incorrect.";
                    return false;
                }

                this.User = user.ToJson();
                return true;
            }
            catch (Exception)
            {
                this.Error = "Internal server error";
                return false;
            }
        }

        /**
         * Register new account
         * 
         * It will have checked all information that is valid before it's
         * created new account and save in database.
         * 
         * @return
         *      - true: create new account successfully.
         *      - false: can not create new account with some problem.
         * @params User - object User has all informatiom to create account.
         */
        public bool Register(UserDTO User)
        {
            try
            {
                // Check username of user
                var filter = Builders<UserDTO>.Filter.Eq(u => u.Username, $"{User.Username}");
                var exist = collection.Find(filter).FirstOrDefault();
                if (exist != null)
                {
                    this.Error = "The username has existed.";
                    return false;
                }

                // Hash password of user to security
                string hashed = BCrypt.Net.BCrypt.HashPassword(User.Password);
                User.Password = hashed;

                // Set avatar for user profile
                User.Avatar = "https://avatar.iran.liara.run/username?username=" + User.Username;

                collection.InsertOne(User);

                this.User = User.ToJson();
                return true;
            }
            catch (Exception)
            {
                this.Error = "Internal server error";
                return false;
            }
        }
        #endregion
    }
}
