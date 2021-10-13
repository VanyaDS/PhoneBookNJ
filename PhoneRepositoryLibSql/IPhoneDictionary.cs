using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneRepositoryLibSql
{
    public interface IPhoneDictionary<T> where T: class 
    {
        IEnumerable<T> GetNotes();
        T GetNote(int id);
        void Create( string item1, string item2);
        void Update(int id, string item1, string item2);
        void Delete(int id);
        void Save();
    }
}
