using Microsoft.EntityFrameworkCore;

namespace Kreata.Backend.Context
{
    public class KretaInMemoryContext : KretaContext
    {
        public KretaInMemoryContext(DbContextOptions<KretaContext> options) : base(options)
        {
        }
    }
}
