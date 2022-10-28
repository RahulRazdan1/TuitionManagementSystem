using Application.Data;
using AutoMapper;

namespace Application.Common
{
    
    public class Providers
    {
        public Providers(ApplicationDbContext db, IMapper mapper)
        {
           Database = db;
           Mapper = mapper;
        }
        public ApplicationDbContext Database { get; private set; }
        public IMapper Mapper { get; private set; }
    }


}
