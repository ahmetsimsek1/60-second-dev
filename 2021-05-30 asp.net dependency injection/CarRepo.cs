using Microsoft.AspNetCore.Http;

public class CarRepo
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public CarRepo(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;
    public string GetCarModel() 
    {
        var httpContext = _httpContextAccessor.HttpContext;
        switch (httpContext.Request.Query["name"])
        {
            case "Joe": return "Mustang";
            default: return "Pinto";
        }
    }
}