using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhoneRepositoryLibSql
{
    public class PhoneDictionary : IPhoneDictionary<Note>
    {
      
    

        public void Create(string surname, string phoneNumber)
        {
            using (PhoneBookContext context = new PhoneBookContext())
            {
                int lastId = context.Notes.Max(maxId => maxId.Id) + 1;
                context.Database.ExecuteSqlCommand($"INSERT INTO Notes  VALUES ({lastId},'{surname}','{phoneNumber}')");
                Save();

            }
        }

        public void Delete(int id)
        {
            using (PhoneBookContext context = new PhoneBookContext())
            {
                foreach (var note in context.Notes)
                {
                    if (note.Id == id)
                    {
                        context.Notes.Remove(note);
                        break;
                    }
                }
                context.SaveChanges();
            }
            Save();
        }

        public Note GetNote(int id)
        {
            using (PhoneBookContext context = new PhoneBookContext())
            {
                var NotesList = context.Notes.ToList();

                foreach (var note in NotesList)
                {
                    if (note.Id == id)
                    {
                        return note;

                    }
                }

            }
             
           
            return null;
        }

        public IEnumerable<Note> GetNotes()
        {
            using (PhoneBookContext context = new PhoneBookContext())
            {
                var NotesList = context.Notes.ToList();
                if (NotesList != null)
                {
                    NotesList.Sort((surname1, surname2) => surname1.Surname.CompareTo(surname2.Surname));
                    return NotesList;

                }
                else return null;
           
            }
          
        }

        public void Save()
        {
            
        }

        public void Update(int id, string surname, string phoneNumber)
        {
            using (PhoneBookContext context = new PhoneBookContext())
            {
                foreach (var note in context.Notes)
                {
                    if (note.Id == id)
                    {
                        note.Surname = surname;
                        note.PhoneNumber = phoneNumber;
                        break;
                    }
                }
                context.SaveChanges();
            }

            Save();
        }
    }
}
