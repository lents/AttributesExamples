namespace Attributes.WebApplication
{
    [Flags]
    public enum Roles { 
        None =0,
        User = 1,
        Customer = 2,
        Moderator = 4,
        Admin = 8,
        Employee = 16,
        Manager = 32,
        Client = User | Customer | Moderator,
        Support = Admin | Employee | Manager,
    }
    

}
