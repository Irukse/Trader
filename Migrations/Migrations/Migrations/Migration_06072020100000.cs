using FluentMigrator;

namespace Migrations.Migrations;

[Migration(06072020100000)]
public class Migration_06072020100000 : Migration
{
    public override void Up()
    {
        Create.Table("Employee")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Age").AsInt32().Nullable()
            .WithColumn("Agess").AsInt32().Nullable();
    }

    public override void Down()
    {
        Delete.Table("Employee");
    }
}