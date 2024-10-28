using System.Collections.Generic;

namespace Library;

/// <summary>
/// Representa una libreta de contactos, permitiendo agregar, buscar, eliminar contactos, y enviar mensajes.
/// </summary>
public class Phonebook
{
    /// <summary>
    /// Lista privada de contactos almacenados en la libreta.
    /// </summary>
    private List<Contact> persons;

    /// <summary>
    /// Propiedad que obtiene el dueño de la libreta de contactos.
    /// </summary>
    public Contact Owner { get; }

    /// <summary>
    /// Constructor que inicializa la libreta de contactos con el dueño.
    /// </summary>
    /// <param name="owner">El dueño de la libreta de contactos.</param>
    public Phonebook(Contact owner)
    {
        Owner = owner;
        persons = new List<Contact>();
    }

    /// <summary>
    /// Busca contactos en la libreta que coincidan con los nombres dados.
    /// </summary>
    /// <param name="names">Array de nombres a buscar.</param>
    /// <returns>Lista de contactos que coinciden con los nombres especificados.</returns>
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

    /// <summary>
    /// Agrega un nuevo contacto a la libreta si no existe ya.
    /// </summary>
    /// <param name="contact">El contacto a agregar.</param>
    public void AddContact(Contact contact)
    {
        if (!persons.Contains(contact))
        {
            persons.Add(contact);
        }
    }

    /// <summary>
    /// Elimina un contacto de la libreta si existe.
    /// </summary>
    /// <param name="contact">El contacto a eliminar.</param>
    public void RemoveContact(Contact contact)
    {
        if (persons.Contains(contact))
        {
            persons.Remove(contact);
        }
    }

    /// <summary>
    /// Envía un mensaje a los contactos especificados en la libreta utilizando un tipo de envío.
    /// </summary>
    /// <param name="message">El mensaje a enviar.</param>
    /// <param name="names">Array de nombres de los contactos destinatarios.</param>
    /// <param name="sendType">Tipo de envío para el mensaje.</param>
    public void SendMessage(Message message, string[] names, EnumSendType sendType)
    {
        IMessageChannel channel = sendType == EnumSendType.whatsapp ? new WhatsAppChannel() : new EmailChannel(); // Envia por defecto por mail

        List<Contact> recievers = Search(names);

        foreach (Contact reciever in recievers)
        {
            Message msg = new Message(Owner.Name, reciever.Name);
            msg.Text = message.Text;
            channel.Send(msg, reciever);
        }
    }
}
