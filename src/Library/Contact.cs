namespace Library;

public class Contact
{
    public Contact(string name)
    {
        this.Name = name;
    }

    public Contact(string name, string phone)   // Cree 2 constructores mas solo por comodidad
    {
        this.Name = name;
        this.Phone = phone;
    }

    public Contact(string name, string phone, string email)
    {
        this.Name = name;
        this.Phone = phone;
        this.Email = email;
    }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }
}