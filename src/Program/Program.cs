using System;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear el contacto dueño
            Contact owner = new Contact("Matias");
            // Crear MSG a Enviar 
            Message msg = new Message(owner.Name, "receptor");
            msg.Text = "Hola Esta funcando";
            // Crear la lista de contactos
            Phonebook phonebook = new Phonebook(owner);
            // Agregar contactos a la lista
            phonebook.AddContact(new Contact("Mati", "+59898067422"));
            phonebook.AddContact(new Contact("Mate", "+59898067422"));
            phonebook.AddContact(new Contact("Mat", "+59898067422"));

            // Enviar un WhatsApp a algunos contactos
            phonebook.SendMessage(msg, ["Mati","Mate","Mat"], EnumSendType.whatsapp);
        }
    }
}