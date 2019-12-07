//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Entity.ContextModel
//{
//    public class MyHistoryRepository : SqlServerHistoryRepository
//    {
//        public MyHistoryRepository(
//            IDatabaseCreator databaseCreator, IRawSqlCommandBuilder rawSqlCommandBuilder,
//            ISqlServerConnection connection, IDbContextOptions options,
//            IMigrationsModelDiffer modelDiffer,
//            IMigrationsSqlGenerator migrationsSqlGenerator,
//            IRelationalAnnotationProvider annotations,
//            ISqlGenerationHelper sqlGenerationHelper)
//            : base(databaseCreator, rawSqlCommandBuilder, connection, options,
//                modelDiffer, migrationsSqlGenerator, annotations, sqlGenerationHelper)
//        {
//        }

//        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
//        {
//            base.ConfigureTable(history);

//            history.Property(h => h.MigrationId).HasColumnName("Id");
//        }
//    }

//}
