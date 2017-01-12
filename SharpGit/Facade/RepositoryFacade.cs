using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGit.Model.Facade
{
    class RepositoryFacade
    {
        private readonly DatabaseContext _dbContext = new DatabaseContext();

        public Repository CreateRepository(string name, string path)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    var repository = new Repository { Name = name, Path = path };
                    _dbContext.Add(repository);
                    _dbContext.SaveChanges();

                    // Commit transaction if all commands succeed, transaction will auto-rollback
                    // when disposed if either commands fails
                    transaction.Commit();
                    return repository;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public List<Repository> GetRepositoryList()
        {
            try
            {
                return _dbContext.Repositories.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public Repository GetRepository(int Id)
        {
            try
            {
                return _dbContext.Repositories
                    .Single(b => b.RepositoryId == Id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public Repository GetRepositorybyName(string name)
        {
            try
            {
                return _dbContext.Repositories
                    .Single(b => b.Name == name);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public Repository UpdateRepository(Repository repository)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    _dbContext.Update(repository);
                    _dbContext.SaveChanges();

                    transaction.Commit();
                    return repository;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public bool DeleteRepository(Repository repository)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    _dbContext.Remove(repository);
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
