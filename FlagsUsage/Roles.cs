namespace FlagsUsage
{
    using System;

    [Flags]
    public enum Roles
    {
        None = 0,
        User = 1 << 0, // 1
        Customer = 1 << 1, // 2
        Moderator = 1 << 2, // 4
        Admin = 1 << 3, // 8
        Employee = 1 << 4, // 16
        Manager = 1 << 5, // 32
        Support = Admin | Employee | Manager // Combination of Admin, Employee, and Manager
    }

}
