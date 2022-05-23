using System;
using MongoDB.Driver;
using SOSU2022_BacEnd.Domain.IRepositories;
using SOSU2022_BackEnd.Core.Models;
using SOSU2022_BackEnd.DataAcces.Converters;
using SOSU2022_BackEnd.DataAcces.Documents;

namespace SOSU2022_BackEnd.DataAcces.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly IMongoCollection<UserDocument> _users;
        public UserRepository()
        {
            var client = new MongoClient("mongodb+srv://Eksamen2022:UUTu4zvESzEUcL9k@cluster0.oowmj.mongodb.net/SOSU2022?retryWrites=true&w=majority");
            var db = client.GetDatabase("SOSU2022");

            _users = db.GetCollection<UserDocument>("BrugerLogin");
        }
        public User FindByUsernameAndPassWord(string username, string password)
        {
            var user = _users.Find(user => user.Brugernavn == username && user.Adgangskode == password).FirstOrDefault();

            if (user == null)
            {
                throw new NullReferenceException();
            }

            return new User
            {
                Id = user._id.ToString(),
                Username = user.Brugernavn,
                Password = user.Adgangskode,
            };
        }
    }
}