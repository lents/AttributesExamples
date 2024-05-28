namespace FlagsUsage
{
    using System;

    public class RoleOperations
    {
        public static Roles AddRole(Roles currentRoles, Roles newRole)
        {
            return currentRoles | newRole;
        }

        public static Roles RemoveRole(Roles currentRoles, Roles roleToRemove)
        {
            return currentRoles & ~roleToRemove;
        }

        public static bool HasRole(Roles currentRoles, Roles roleToCheck)
        {
            return (currentRoles & roleToCheck) == roleToCheck;
        }

        public static Roles ToggleRole(Roles currentRoles, Roles roleToToggle)
        {
            return currentRoles ^ roleToToggle;
        }

        public static void Main()
        {
            Roles roles = Roles.None;

            roles = AddRole(roles, Roles.User);
            roles = AddRole(roles, Roles.Customer);
            roles = AddRole(roles, Roles.Moderator);

            Console.WriteLine($"Current roles: {roles}");

           
            Console.WriteLine($"Has User role: {HasRole(roles, Roles.User)}");
            Console.WriteLine($"Has Admin role: {HasRole(roles, Roles.Admin)}");

           
            roles = RemoveRole(roles, Roles.Customer);
            Console.WriteLine($"Current roles after removing Customer: {roles}");

           
            roles = ToggleRole(roles, Roles.Moderator);
            Console.WriteLine($"Current roles after toggling Moderator: {roles}");

            
            roles = AddRole(roles, Roles.Support);
            Console.WriteLine($"Current roles after adding Support: {roles}");
            Console.WriteLine($"Has Support role: {HasRole(roles, Roles.Support)}");
        }
    }

}
