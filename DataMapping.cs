using AutoMapper;
using pra_test.Data;
using pra_test.Models;

namespace pra_test
{
    public class DataMapping:Profile
    {
       public DataMapping() {
            CreateMap<Person, PersonModel>().ReverseMap();
        }
    }
}
