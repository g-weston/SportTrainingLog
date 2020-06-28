using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace SportTrainingLog
{
    public class SessionLogDataBase
    {
        readonly SQLiteAsyncConnection _database;

        public SessionLogDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Session>().Wait();
        }

        public Task<List<Session>> GetSessionsAsync()
        {
            return _database.Table<Session>().ToListAsync();
        }

        public Task<Session> GetSessionAsync(int id)
        {
            return _database.Table<Session>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveSessionAsync(Session session)
        {
            if (session.ID != 0)
            {
                return _database.UpdateAsync(session);
            }
            else
            {
                return _database.InsertAsync(session);
            }
        }

        public Task<int> DeleteSessionAsync(Session session)
        {
            return _database.DeleteAsync(session);
        }
    }
}
