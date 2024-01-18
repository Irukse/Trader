using FluentMigrator;

namespace Migrations.Migrations;

[Migration(20122023)]
public class Migrations_20122023 : Migration
{
    public override void Up()
    {
        Create.Table("shares")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ticker").AsString().NotNullable()
            .WithColumn("figi").AsString().NotNullable()
            .WithColumn("currency").AsString().NotNullable()
            .WithColumn("sector").AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("shares");
    }
}