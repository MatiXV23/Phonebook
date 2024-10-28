using WhatsAppApiUCU;

namespace Library;

public class WhatsAppChannel : IMessageChannel
{
    WhatsAppApi whatsApp = new WhatsAppApi();
    
    public void Send(Message message, Contact reciever)
    {
        whatsApp.Send(reciever.Phone, message.Text);
    }
}