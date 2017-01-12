using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGit.Model.Facade
{
    public class UserFacade
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        public User CreateUser(string email, string userName, string firstName, string lastName, string accountType)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                var user = new User
                {
                    Email = email,
                    UserName = userName,
                    Name = $"{firstName} {lastName}",
                    AccountType = accountType
                };
                _dbContext.Add(user);
                _dbContext.SaveChanges();

                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                transaction.Commit();
                return user;
            }
        }
        public List<User> GetUserList()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUser(int Id)
        {
            return _dbContext.Users
                .Single(b => b.UserId == Id);
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users
                .Single(b => b.Email == email);
        }

        public User UpdateUser(User user)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.Update(user);
                _dbContext.SaveChanges();

                transaction.Commit();
                return user;
            }
        }

        public bool DeleteUser(User user)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                _dbContext.Remove(user);
                _dbContext.SaveChanges();

                transaction.Commit();
                return true;
            }
        }
    }
}
