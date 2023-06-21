using FluentMigrator;

namespace Migrations.Migrations;

[Migration(202312061900)]
public class Migration_202312061900 : Migration
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