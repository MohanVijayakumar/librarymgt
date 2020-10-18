using System.Collections.Generic;

using Npgsql;
using NPoco;
using NPoco.FluentMappings;

using lmgtpersistence.Mapping;
using lmgtconfiguration;
namespace lmgtpersistence.PostgreSql
{
    public class PostgreSqlDatabaseFactoryProvider : IDatabaseFactoryProvider
    {
        
        public PostgreSqlDatabaseFactoryProvider(DtoMappings mappings,List<IMapDto> mapDtos,DatabaseConfiguration databaseConfiguration)
        {
            foreach(var dMap in mapDtos)
            {
                dMap.Map(mappings);
            }

            _Mappings = mappings;
            _DatabaseConfiguration = databaseConfiguration;
        }

        private DtoMappings _Mappings;
        private DatabaseConfiguration _DatabaseConfiguration;
        public DatabaseFactory Factory {get;private set;}

        private bool _HasFactorySet;
        public void Setup()
        {
            if(_HasFactorySet)
            {
                return;
            }
            var fC = FluentMappingConfiguration.Configure(_Mappings);
            Factory = DatabaseFactory.Config(x => 
            {
                x.UsingDatabase(() =>
                {
                    var conStr = _DatabaseConfiguration.ConnectionString;
                    var db = new Database(conStr,DatabaseType.PostgreSQL,NpgsqlFactory.Instance);
                    db.EnableAutoSelect = false;
                    return db;
                });
                x.WithFluentConfig(fC);
            });

            _HasFactorySet = true;
        }
    }
}