
namespace PizzaFlow.Intranet.ViewModels.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MaskAttribute : Attribute
{
    public string Pattern { get; }

    public MaskAttribute(string pattern)
    {
        Pattern = pattern;
    }
}