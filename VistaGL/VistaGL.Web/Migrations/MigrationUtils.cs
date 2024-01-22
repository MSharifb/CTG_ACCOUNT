using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using System;
using System.Collections.Generic;

namespace VistaGL.Migrations
{
	public static class Utils
	{
        public static void CreateTableWithId32(
    this MigrationBase migration, string table, string idField,
    Action<ICreateTableColumnOptionOrWithColumnSyntax> addColumns, string schema = null, bool checkExists = false)
        {
            CreateTableWithId(migration, table, idField, addColumns, schema, 32, checkExists);
        }

        public static void CreateTableWithId64(
            this MigrationBase migration, string table, string idField,
            Action<ICreateTableColumnOptionOrWithColumnSyntax> addColumns, string schema = null, bool checkExists = false)
        {
            CreateTableWithId(migration, table, idField, addColumns, schema, 64, checkExists);
        }

        private static void CreateTableWithId(
            MigrationBase migration, string table, string idField,
            Action<ICreateTableColumnOptionOrWithColumnSyntax> addColumns, string schema, int size, bool checkExists = false)
        {
            Func<ICreateTableColumnAsTypeSyntax, ICreateTableColumnOptionOrWithColumnSyntax> addAsType =
                col =>
                {
                    if (size == 64)
                        return col.AsInt64();
                    else if (size == 16)
                        return col.AsInt16();
                    else
                        return col.AsInt32();
                };

            Func<ICreateTableWithColumnOrSchemaOrDescriptionSyntax, ICreateTableWithColumnSyntax> addSchema =
                syntax =>
                {
                    if (schema != null)
                        return syntax.InSchema(schema);
                    else
                        return syntax;
                };

            if (checkExists)
            {
                if (schema != null && migration.Schema.Schema(schema).Table(table).Exists())
                    return;

                if (schema == null && migration.Schema.Table(table).Exists())
                    return;
            }

            addColumns(
                addAsType(
                    addSchema(migration
                        .Create.Table(table))
                            .WithColumn(idField))
                            .Identity().PrimaryKey().NotNullable());

            //addColumns(
            //    addAsType(
            //        addSchema(migration.IfDatabase("Oracle")
            //            .Create.Table(table))
            //                .WithColumn(idField))
            //                .PrimaryKey().NotNullable());

            //AddOracleIdentity(migration, table, idField);
        }


        public static string[] AllExceptOracle =
		{
			"SqlServer",
			"SqlServer2000",
			"SqlServer2008",
			"SqlServerCe",
			"Postgres",
			"MySql",
			"Jet",
			"Sqlite",
			"SAP HANA"
		};

		public static void AddOracleIdentity(MigrationBase migration,
			string table, string id)
		{
			var seq = table.Replace(" ", "_").Replace("\"", "");
			//seq = seq.Substring(0, Math.Min(28, seq.Length));
			string trg = seq + "_T";
			seq = seq + "_S";

			migration.IfDatabase("Oracle")
				.Execute.Sql($"CREATE SEQUENCE {seq} START WITH 1000 INCREMENT BY 1");

			migration.IfDatabase("Oracle")
				.Execute.Sql($@"
CREATE OR REPLACE TRIGGER {trg}
BEFORE INSERT ON {table}
FOR EACH ROW
BEGIN
	IF :new.{id} IS NULL THEN
		SELECT {seq}.nextval INTO :new.{id} FROM DUAL;
	END IF;
END;");

			migration.IfDatabase("Oracle")
				.Execute.Sql(@"ALTER TRIGGER " + trg + " ENABLE");
		}

		public static void AddOracleIdentityWithMasterTable(MigrationBase migration,
			string table, string id, string masterTable, string masterTableIdInThisTable)
		{
			var seq = table.Replace(" ", "_").Replace("\"", "");
			//seq = seq.Substring(0, Math.Min(28, seq.Length));
			string trg = seq + "_T";
			seq = seq + "_S";

			migration.IfDatabase("Oracle")
					.Execute.Sql($"CREATE SEQUENCE {seq} START WITH 1000 INCREMENT BY 1");

			migration.IfDatabase("Oracle")
			.Execute.Sql($@"
CREATE OR REPLACE
TRIGGER {trg}
BEFORE INSERT ON {table}
FOR EACH ROW
BEGIN
	IF :new.{id} IS NULL THEN
		SELECT {seq}.nextval INTO :new.{id} FROM DUAL;

	  IF :new.{masterTableIdInThisTable} = 0 THEN
		SELECT {masterTable}_S.currval INTO :new.{masterTableIdInThisTable} FROM DUAL;
	  END IF;
	END IF;
END;");

			migration.IfDatabase("Oracle")
				.Execute.Sql(@"ALTER TRIGGER " + trg + " ENABLE");
		}
	}
}
