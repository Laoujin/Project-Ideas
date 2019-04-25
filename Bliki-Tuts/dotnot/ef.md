EF6:
Install-Package EntityFramework

EF Core 1.0 --> Create separate file

Sql Server
----------
<add name="PitStopContext" connectionString="data source=.\Dev;initial catalog=PitStop;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />

Postgres
--------
Install-Package Npgsql -Version 2.2.5
Install-Package Npgsql.EntityFramework -Version 2.2.5
Version 3+ is for EF Core

using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Sql;
using Npgsql;

public class MyNpgsqlGenerator : NpgsqlMigrationSqlGenerator
{
    public override IEnumerable<MigrationStatement> Generate(IEnumerable<MigrationOperation> operations, string providerManifestToken)
    {
        var statements = new List<MigrationOperation>();
        foreach (var item in operations)
        {
            var migration = item as AlterTableOperation;
            if (migration == null)
            {
                statements.Add(item);
            }
        }
        return base.Generate(statements, providerManifestToken);
    }
}

public class MyDbConfiguration : DbConfiguration
{
    public MyDbConfiguration()
    {
        SetDefaultConnectionFactory(new NpgsqlConnectionFactory());
        SetMigrationSqlGenerator("Npgsql", () => new MyNpgsqlGenerator());
        SetProviderFactory("Npgsql", NpgsqlFactory.Instance);
        SetProviderServices("Npgsql", NpgsqlServices.Instance);
    }
}

SQLite
-------
Install-Package System.Data.SQLite
--> Doesn't work with migrations

MySql
-----
Install-Package MySql.Data
Install-Package MySql.Data.Entity

<configSections>
	<section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
 </configSections>
<connectionStrings>
	<add name="ttc" providerName="MySql.Data.MySqlClient" connectionString="server=localhost;UserId=ttcuser;Password=test123;database=ttc;Port=3306;CharSet=utf8;Persist Security Info=True;Convert Zero Datetime=True" />
</connectionStrings>
<entityFramework>
  <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
    <parameters>
      <parameter value="mssqllocaldb" />
    </parameters>
  </defaultConnectionFactory>
  <providers>
    <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6, Version=6.9.8.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
    <provider invariantName="Npgsql" type="Npgsql.NpgsqlServices, Npgsql.EntityFramework" />
 </providers>
</entityFramework>
<system.data>
   <DbProviderFactories>
     <remove invariant="MySql.Data.MySqlClient" />
     <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.9.8.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
     <add name="Npgsql Data Provider" invariant="Npgsql" description="Data Provider for PostgreSQL" type="Npgsql.NpgsqlFactory, Npgsql" />
   </DbProviderFactories>
</system.data>

[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
internal class TtcDbContext : DbContext
{
	public DbSet<PlayerEntity> Players { get; set; }

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		modelBuilder.HasDefaultSchema("");
		modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		modelBuilder.Types().Configure(c => c.ToTable(ToLowerCaseTableName(c.ClrType)));

		modelBuilder.Entity<ClubLokaal>()
			.HasRequired(c => c.Club)
			.WithMany(l => l.Lokalen)
			.HasForeignKey(x => x.ClubId);
	}

	public TtcDbContext() : base("webConfigConnectionStringName")
	{
		//Configuration.ValidateOnSaveEnabled = false;
		//Configuration.AutoDetectChangesEnabled = false;

		Database.SetInitializer<TtcDbContext>(new CreateDatabaseIfNotExists<TtcDbContext>());
	}

	static TtcDbContext()
	{
		DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
	}
}

Queries
-------
using System.Data.Entity; // Required for context.CollectionName.Include(x => x.ChildCollection);

Migrations
----------
Enable-Migrations
Add-Migration
Update-Database -Verbose
Update-Database -TargetMigration


class Configuration : DbMigrationsConfiguration<TtcDbContext>
public Configuration()
{
	AutomaticMigrationsEnabled = false;
	//CodeGenerator = new MyCodeGenerator();
	//SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
}

class MyCodeGenerator : CSharpMigrationCodeGenerator {}

Code-First
----------
[Key]
[TableName]
[Column]

Separate configuration files:  
public class EntityConfiguration : EntityTypeConfiguration<Entity> {}
modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());


ComplexType
-----------
using System.Data.Entity.ModelConfiguration.Conventions;
public class NoPrefixComplexTypeAttributeConvention : ComplexTypeAttributeConvention
{
  public NoPrefixComplexTypeAttributeConvention()
  {
    Properties().Configure(p => p.HasColumnName(p.ClrPropertyInfo.Name));
  }
}

modelBuilder.Conventions.Remove<ComplexTypeAttributeConvention>();
modelBuilder.Conventions.Add(new NoPrefixComplexTypeAttributeConvention());

public class User
{
	public Address Address { get; set; }
}
[ComplexType]
public class Address
{
	public string Street { get; set; }
}

Enums as NVarchars
------------------
[Column("Language")]
public string LanguageString
{
   get { return Language.ToString(); }
   private set { Language = value.ParseEnum<Language>(); }
}
[NotMapped]
public Language Language { get; set; }

public static T ParseEnum<T>(this string value)
{
   return (T)Enum.Parse(typeof(T), value, true);
}

Fluent configuration & Attributes & Conventions
-----------------------------------------------
public class MyContext : DbContext
{
	public MyContext(string name) : base("name=" + name)
	{
		Configuration.LazyLoadingEnabled = false;
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
      base.OnModelCreating(modelBuilder);

      modelBuilder.HasDefaultSchema("dbo");
	}
}


Utc vs Local time
-----------------
public MyContext(string name) : base("name=" + name)
{
	((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += (sender, e) => DateTimeKindAttribute.Apply(e.Entity);
}

[AttributeUsage(AttributeTargets.Property)]
public class DateTimeKindAttribute : Attribute
{
  public DateTimeKindAttribute()
      : this(DateTimeKind.Utc)
  {
  }

  public DateTimeKindAttribute(DateTimeKind kind)
  {
      Kind = kind;
  }

  public DateTimeKind Kind { get; }

  public static void Apply(object entity)
  {
      if (entity == null)
          return;

      var meta = from prop in entity.GetType().GetProperties()
          from attr in prop.GetCustomAttributes(typeof (DateTimeKindAttribute), true)
          select new {Prop = prop, Attr = (DateTimeKindAttribute) attr};

      foreach (var m in meta)
      {
          var dt = m.Prop.PropertyType == typeof (DateTime?)
              ? (DateTime?) m.Prop.GetValue(entity)
              : (DateTime) m.Prop.GetValue(entity);

          if (dt == null)
              continue;

          m.Prop.SetValue(entity, DateTime.SpecifyKind(dt.Value, m.Attr.Kind));
      }
  }
}

Debugging
---------
Check out: Stackify Prefix

// in MyContext:
public override int SaveChanges()
{
   try
   {
       return base.SaveChanges();
   }
   catch (System.Data.Entity.Validation.DbEntityValidationException ex)
   {
#if DEBUG
       ex.EntityValidationErrors.ToList().ForEach(error =>
       {
           error.ValidationErrors.ToList().ForEach(ve => Debug.WriteLine(ve.ErrorMessage.ToString()));
       });
#endif
       throw;
   }
}