using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Contact_Manager
{
    interface IServices
    {
        void AddContact(Contact Contact);
        void EditContact(int Id,Contact UpdatedContact);
        void DeleteContact(int Id);
        List<Contact> GetAllContacts();
    }
    class Services : IServices
    {
        private const string FilePath = "contacts.json";
        private readonly List<Contact> _contacts;
        private readonly ILogger _logger;
        private int _idCounter = 1;
        public Services(ILogger logger)
        {
            _logger = logger;
            _contacts = new List<Contact>();
            LoadContacts();
            _idCounter = _contacts.Any() ? _contacts.Max(c => c.Id) + 1 : 1;
        }

        public void AddContact(Contact contact)
        {
            contact.Id = _idCounter++;
            _contacts.Add(contact);
            SaveContacts();
            _logger.Log($"Added contact: {contact.Name}");
        }

        public void EditContact(int id, Contact updatedContact)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                contact.Name = updatedContact.Name;
                contact.Phone = updatedContact.Phone;
                contact.Email = updatedContact.Email;
                SaveContacts();
                _logger.Log($"Edited contact with ID {id}");
            }
        }

        public void DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
            {
                _contacts.Remove(contact);
                SaveContacts();
                _logger.Log($"Deleted contact with ID {id}");
            }
        }

        public List<Contact> GetAllContacts() => _contacts;
        
        private void LoadContacts()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var json = File.ReadAllText(FilePath);
                    var contacts = JsonSerializer.Deserialize<List<Contact>>(json);
                    if (contacts != null)
                        _contacts.AddRange(contacts);
                }
                catch (Exception ex)
                {
                    _logger.Log($"Error loading contacts: {ex.Message}");
                }
            }
        }

        private void SaveContacts()
        {
            try
            {
                var json = JsonSerializer.Serialize(_contacts, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                _logger.Log($"Error saving contacts: {ex.Message}");
            }
        }
    }
}
