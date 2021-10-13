using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneRepositoryLibSql
{
   public class PhoneBookContext:DbContext
    {
        public PhoneBookContext()
               : base("DBConnectionGO")
        { }
        public  DbSet<Note> Notes { get; set; }

    }
}
