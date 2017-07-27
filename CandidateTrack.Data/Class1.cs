using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTrack.Data
{
    public class Repository
    {
        private string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<CandidateDB> getAllCandidate(string action)
        {
            using (var context = new CandidateDBDataContext(_connectionString))
            {
                if(action == "Pending")
                {
                    return context.CandidateDBs.Where(c => c.status == null).ToList();
                }
                else if (action == "Refused")
                {
                    return context.CandidateDBs.Where(c => c.status == false).ToList();
                }
                else
                {
                    return context.CandidateDBs.Where(c => c.status == true).ToList();
                }
            }
        }

        public void AddCandidate(CandidateDB person)
        {
            using (var context = new CandidateDBDataContext(_connectionString))
            {
                context.CandidateDBs.InsertOnSubmit(person);
                context.SubmitChanges();
            }
        }

        public void UpdateCandidate(int Id, bool action)
        {
            using (var context = new CandidateDBDataContext(_connectionString))
            {
                context.ExecuteCommand("UPDATE CandidateDB SET status = {0} WHERE Id = {1}", action, Id);
            }
        }

        public int getPendingCount()
        {
            using (var context = new CandidateDBDataContext(_connectionString))
            {
                return context.CandidateDBs.Where(c => c.status == null).Count(); ;
            }
        }

        public int getRefusedCount()
        {
            using (var context = new CandidateDBDataContext(_connectionString))
            {
                return context.CandidateDBs.Where(c => c.status == false).Count(); ;
            }
        }
        public int getConfirmedCount()
        {
            using (var context = new CandidateDBDataContext(_connectionString))
            {
                return context.CandidateDBs.Where(c => c.status == true).Count(); ;
            }
        }
    }
}
