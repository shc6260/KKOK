using AutoMapper;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Create;
using OracleEFCore5.Application.Features.DbTestTable.Queries.Gets;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<TestTable, TestTablesData>().ReverseMap();
            CreateMap<CreateTestTableCommand, TestTable>().ReverseMap();
        }
    }

}
