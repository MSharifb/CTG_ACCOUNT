using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System;

namespace VistaGL.Migrations
{
    public static class MigrationExtention
    {
        public static void CreateTableWithIdentity(this MigrationBase m, string tableName, string idCol, string schema, Action<ICreateTableWithColumnSyntax> addCols)
        {
            if (string.IsNullOrWhiteSpace(schema)) schema = "dbo";

            addCols(m.IfDatabase(Utils.AllExceptOracle)
                    .Create.Table(tableName).InSchema(schema)
                    .WithColumn(idCol).AsInt32().Identity().PrimaryKey().NotNullable());

            addCols(m.IfDatabase("Oracle")
                .Create.Table(tableName)
                .WithColumn(idCol).AsInt32().PrimaryKey().NotNullable());

            Utils.AddOracleIdentity(m, tableName, idCol);

        }

        public static void CreateTableWithIdentityAndMaster(this MigrationBase m, string tableName, string idCol, string masterTable, string masterTableIdInThisTable, Action<ICreateTableWithColumnSyntax> addCols)
        {
            addCols(m.IfDatabase(Utils.AllExceptOracle)
                    .Create.Table(tableName)
                    .WithColumn(idCol).AsInt32().Identity().PrimaryKey().NotNullable());

            addCols(m.IfDatabase("Oracle")
                .Create.Table(tableName)
                .WithColumn(idCol).AsInt32().PrimaryKey().NotNullable());

            Utils.AddOracleIdentityWithMasterTable(m, tableName, idCol, masterTable, masterTableIdInThisTable);

        }

        public static void CreateForeignKey(this MigrationBase m, string fromTable, string fkCol)
        {

            CreateForeignKey(m, fromTable, fkCol, fkCol.Substring(0, fkCol.Length - 2), "Id");

        }

        public static void CreateForeignKey(this MigrationBase m, string schema, string fromTable, string fkCol)
        {
            var fkName = GetFKName(fromTable, fkCol);
            var toTable = fkCol.Substring(0, fkCol.Length - 2);
            m.Create.ForeignKey(fkName)
                .FromTable(fromTable).InSchema(schema).ForeignColumn(fkCol)
                .ToTable(toTable).InSchema(schema).PrimaryColumn("Id");

        }

        public static void CreateForeignKey(this MigrationBase m, string schema, string fromTable, string fkCol, string toTable)
        {

            m.Create.ForeignKey(GetFKName(fromTable, fkCol))
                .FromTable(fromTable).InSchema(schema).ForeignColumn(fkCol)
                .ToTable(toTable).InSchema(schema).PrimaryColumn("Id");

        }

        private static string GetFKName(string fromTable, string fkCol)
        {
            //if (fromTable.Length > 18)
            //    fromTable = fromTable.Substring(fromTable.Length - 18);

            var fkName = "FK_" + fkCol + "_" + fromTable;
            //if (fkName.Length > 30)
            //    fkName = fkName.Substring(0, 30);
            return fkName;
        }

        public static ICreateTableWithColumnSyntax CommonFields(this ICreateTableWithColumnSyntax e)
        {
            return e.WithColumn("Remarks").AsString(500).Nullable()
                    .WithColumn("IUser").AsString(50).Nullable()
                    .WithColumn("EUser").AsString(50).Nullable()
                    .WithColumn("IDate").AsDateTime().Nullable().WithDefault(SystemMethods.CurrentDateTime)
                    .WithColumn("EDate").AsDateTime().Nullable();

        }
        public static ICreateTableWithColumnSyntax CaptureLogFields(this ICreateTableWithColumnSyntax e)
        {
            return e.WithColumn("OperationType").AsInt16().NotNullable()
                .WithColumn("ChangingUserId").AsInt32().Nullable()
                .WithColumn("ValidFrom").AsDateTime().NotNullable()
                .WithColumn("ValidUntil").AsDateTime().NotNullable();

        }


    }


    public class MigrationAttribute : FluentMigrator.MigrationAttribute
    {
        public MigrationAttribute(long version)
            : base(version)
        {
            if (version < 20000101000000 ||
                version > 99990101000000)
                throw new Exception("Migration versions must be in yyyyMMddHHmmss format! Version " + version + " is incorrect.");
        }

        public MigrationAttribute(int year, int month, int day, int hour, int minute, int second = 0)
            : this(year * 10000000000 + month * 100000000 + day * 1000000 + hour * 10000 + minute * 100 + second)
        {
        }
    }
}