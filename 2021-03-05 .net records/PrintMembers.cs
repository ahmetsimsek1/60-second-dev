using System.Text;

public record Browser(string Name, decimal Version, bool IsGood)
{
    protected virtual bool PrintMembers(StringBuilder builder)
    {
        builder.Append($"{Name} v{Version} - this version is {(IsGood ? "Good" : "Crap")}");
        return true;
    }
}