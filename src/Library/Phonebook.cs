using System.Collections.Generic;

namespace Library;

public class Phonebook
{
    private List<Contact> persons;
    public Contact Owner { get; }
    
    public Phonebook(Contact owner)
    {
        Owner = owner;
        persons = new List<Contact>();
    }

   

    public List<Contact> Search(string[] names)
    {
        List<Contact> result = new List<Contact>();

        foreach (Contact person in this.persons)
        {
            foreach (string name in names)
            {
                if (person.Name.Equals(name))
                {
                    result.Add(person);
                }
            }
        }

        return result;
    }


    public void AddContact(Contact contact) 
    {
        if (!persons.Contains(contact))
        {
            persons.Add(contact);
        }
    }
    public void RemoveContact(Contact contact) 
    {
        if (persons.Contains(contact))
        {
            persons.Remove(contact);
        }  
    }
    
    public void SendMessage(Message message, string[] names, EnumSendType sendType)
    {
        WhatsAppChannel whatsApp = new WhatsAppChannel();

        List<Contact> recievers = Search(names);

        foreach (Contact reciever in recievers)
        {
            Message msg = new Message(Owner.Name, reciever.Name);
            msg.Text = message.Text;
            whatsApp.Send(msg, reciever);
        }
    }
}