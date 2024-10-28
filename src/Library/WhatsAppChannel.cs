using WhatsAppApiUCU;

namespace Library;

public class WhatsAppChannel : IMessageChannel
{
    /// <summary>
    /// Instancia de la API de WhatsApp.
    /// </summary>
    private WhatsAppApi whatsApp = new WhatsAppApi();


    /// <summary>
    /// Envía un mensaje a un contacto específico.
    /// </summary>
    /// <param name="message">El mensaje que se enviará.</param>
    /// <param name="reciever">El contacto que recibirá el mensaje.</param>
    public void Send(Message message, Contact reciever)
    {
        whatsApp.Send(reciever.Phone, message.Text);
    }
}