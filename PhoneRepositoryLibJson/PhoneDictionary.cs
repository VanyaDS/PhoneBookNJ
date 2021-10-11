using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhoneRepositoryLibJson
{
    class PhoneDictionary : IPhoneDictionary<Note>
    {
        public List<Note> Notes;
        public PhoneDictionary()
        {
            using (StreamReader fs = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\notes.json"))

            {
                if (Notes == null)
                    Notes = new List<Note>();

                JsonTextReader jsonTextReader = new JsonTextReader(fs);
                JsonSerializer jsonSerializer = new JsonSerializer();
                Notes = jsonSerializer.Deserialize<List<Note>>(jsonTextReader);
                Notes.Sort((surname1, surname2) => surname1.Surname.CompareTo(surname2.Surname));
            }
        }

        public void Create(string surname, string phoneNumber)
        {
            int lastId = Notes.Max(maxId => maxId.Id);
            Note note = new Note(lastId + 1, surname, phoneNumber);
            Notes.Add(note);
            Notes.Sort((surname1, surname2) => surname1.Surname.CompareTo(surname2.Surname));
            Save();
        }

        public void Delete(int id)
        {
            foreach (var note in Notes)
            {
                if (note.Id == id)
                {
                    Notes.Remove(note);
                    break;
                }
            }
            Notes.Sort((surname1, surname2) => surname1.Surname.CompareTo(surname2.Surname));
            Save();
        }

        public Note GetNote(int id)
        {
            foreach (var note in Notes)
            {
                if (note.Id == id)
                {
                    return note;
                    
                }
            }
            return null;
        }

        public IEnumerable<Note> GetNotes()
        {
            if (Notes != null)
                return Notes;
            else return null;
        }

        public void Save()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\notes.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Notes);
            }
        }

        public void Update(int id, string surname, string phoneNumber)
        {
            foreach (var note in Notes)
            {
                if (note.Id == id)
                {
                    note.Surname = surname;
                    note.PhoneNumber = phoneNumber;
                    break;
                }
            }
            Notes.Sort((surname1, surname2) => surname1.Surname.CompareTo(surname2.Surname));
            Save();
        }
    }
}
