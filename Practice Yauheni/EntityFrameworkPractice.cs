using Microsoft.EntityFrameworkCore;

namespace Yauheni;

public class EntityFrameworkPractice
{
    
}

public class MyDbContext : DbContext
{
    // DbConnectionString
    protected MyDbContext() : base()
    {
        
    }
}