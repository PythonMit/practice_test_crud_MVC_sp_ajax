using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using pra_test.Data;
using pra_test.Interface;
using pra_test.Models;
using System.Data;

namespace pra_test.Service
{
    public class PersonManagement : IPerson
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;
        public PersonManagement(IConfiguration configuration,IMapper mapper)
        {
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("Pra_test");
        }
        public void AddPerson(PersonModel person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_AddPerson", new { person.Name, person.Email, person.PhoneNo, person.Address, person.State, person.City }, commandType: CommandType.StoredProcedure);
            }
            // throw new NotImplementedException();
        }

        public void DeletePerson(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_DeletePerson", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
            // throw new NotImplementedException();
        }

        public IEnumerable<PersonModel> GetPeople()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var data= connection.Query<PersonModel>("sp_GetPeople", commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
          //  throw new NotImplementedException();
        }

        public PersonModel GetPersonById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var data=connection.QuerySingleOrDefault<Person>("sp_GetPersonById", new { Id = id }, commandType: CommandType.StoredProcedure);
                var mappingData = _mapper.Map<PersonModel>(data);
                return mappingData;
            }
            // throw new NotImplementedException();
        }

        public void UpdatePerson(PersonModel person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_UpdatePerson", new { person.Id, person.Name, person.Email, person.PhoneNo, person.Address, person.State, person.City }, commandType: CommandType.StoredProcedure);
            }
            //throw new NotImplementedException();
        }
    }
}
