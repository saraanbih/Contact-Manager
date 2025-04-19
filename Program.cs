using Contact_Manager;
using System.Linq;

namespace Contact_Manager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILogger logger = new Logger();
            IServices contactService = new Services(logger);

            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("\n--- Contact Manager ---");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Edit Contact");
                Console.WriteLine("3. Delete Contact");
                Console.WriteLine("4. View All Contacts");
                Console.WriteLine("5. Search Contacts");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        contactService.AddContact(new Contact { Name = name, Phone = phone, Email = email });
                        break;

                    case "2":
                        Console.Write("Enter Contact ID to edit: ");
                        if (!int.TryParse(Console.ReadLine(), out int editId))
                        {
                            Console.WriteLine("Invalid ID");
                            break;
                        }
                        Console.Write("New Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("New Phone: ");
                        string newPhone = Console.ReadLine();
                        Console.Write("New Email: ");
                        string newEmail = Console.ReadLine();

                        contactService.EditContact(editId, new Contact { Name = newName, Phone = newPhone, Email = newEmail });
                        break;

                    case "3":
                        Console.Write("Enter Contact ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            Console.WriteLine("Invalid ID");
                            break;
                        }
                        contactService.DeleteContact(deleteId);
                        break;

                    case "4":
                        var contacts = contactService.GetAllContacts();
                        if (contacts.Count == 0)
                        {
                            Console.WriteLine("There are no contacts :-)");
                            break;
                        }
                        foreach (var c in contacts)
                        {
                            Console.WriteLine($"ID: {c.Id}, Name: {c.Name}, Phone: {c.Phone}, Email: {c.Email}");
                        }
                        break;

                    case "5":
                        Console.Write("Enter search term: ");
                        string term = Console.ReadLine() ?? string.Empty;
                        var results = contactService.GetAllContacts()
                            .Where(c => c.Name.Contains(term, StringComparison.OrdinalIgnoreCase)
                                     || c.Email.Contains(term, StringComparison.OrdinalIgnoreCase)
                                     || c.Phone.Contains(term, StringComparison.OrdinalIgnoreCase))
                            .ToList();
                        if (results.Count == 0)
                            Console.WriteLine("No matching contacts.");
                        else
                            foreach (var c in results)
                                Console.WriteLine($"ID: {c.Id}, Name: {c.Name}, Phone: {c.Phone}, Email: {c.Email}");
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
    }
}