
// Step 1: Define the custom attribute
[AttributeUsage(AttributeTargets.Module)]
public class ModuleInfoAttribute : Attribute
{
    public string Description { get; }

    public ModuleInfoAttribute(string description)
    {
        Description = description;
    }
}
