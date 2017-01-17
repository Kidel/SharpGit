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

        public User CreateUser(string email, string userName, string fullName, string accountType)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var user = new User
                    {
                        Email = email,
                        UserName = userName,
                        Name = fullName,
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
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        public List<User> GetUserList()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<User>();
            }
        }

        public User GetFirstUser()
        {
            try
            {
                return _dbContext.Users.First();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public User GetUser(int id)
        {
            try
            {
                return _dbContext.Users
                    .Single(b => b.UserId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                return _dbContext.Users
                    .Single(b => b.Email == email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public User GetUserByUserName(string username)
        {
            try
            {
                return _dbContext.Users
                    .Single(b => b.UserName == username);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public User UpdateUser(User user)
        {
            return UpdateUser(user.UserId, user.Email, user.UserName, user.Name, user.AccountType, user.LastFolderUsed);
        }

        public User UpdateUser(int id, string email="", string userName="", string fullName="", string accountType="", string lastFolderUsed="")
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var user = GetUser(id);

                    if (fullName != "")
                        user.Name = fullName;
                    if (email != "")
                        user.Email = email;
                    if (userName != "")
                        user.UserName = userName;
                    if (accountType != "")
                        user.AccountType = accountType;
                    if (lastFolderUsed != "")
                        user.LastFolderUsed = lastFolderUsed;

                    _dbContext.Update(user);
                    _dbContext.SaveChanges();

                    transaction.Commit();
                    return user;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var user = GetUser(id);
                    _dbContext.Remove(user);
                    _dbContext.SaveChanges();

                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
