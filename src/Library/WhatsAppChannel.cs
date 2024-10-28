using WhatsAppApiUCU;

namespace Library;

public class WhatsAppChannel : IMessageChannel
{
    /// <summary>
    /// Instancia de la API de WhatsApp.
    /// </summary>
    private WhatsAppApi whatsApp = new WhatsAppApi();


    /// <summary>
    /// Env�a un mensaje a un contacto espec�fico.
    /// </summary>
    /// <param name="message">El mensaje que se enviar�.</param>
    /// <param name="reciever">El contacto que recibir� el mensaje.</param>
    public void Send(Message message, Contact reciever)
    {
        whatsApp.Send(reciever.Phone, message.Text);
    }
}