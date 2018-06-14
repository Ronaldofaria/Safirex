using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

public class SafirexContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public SafirexContext() : base("name=SafirexContext")
    {
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        modelBuilder.Properties()
            .Where(p => p.Name == p.ReflectedType.Name + "Id")
            .Configure(p => p.IsKey());

        modelBuilder.Properties<string>()
            .Configure(p => p.HasColumnType("varchar"));

        modelBuilder.Properties<string>()
            .Configure(p => p.HasMaxLength(100));

    }

    public override int SaveChanges()
    {
        try
        {
            return base.SaveChanges();
        }
        catch (Exception)
        {
            throw new Exception("Ocorreu um erro durante o processo, verifique por favor!");
        }
    }
    public System.Data.Entity.DbSet<Safirex.Models.Domain.Usuario> Usuarios { get; set; }

    public System.Data.Entity.DbSet<Safirex.Models.ClassificacaoOrigem.Esfera> Esferas { get; set; }

    public System.Data.Entity.DbSet<Safirex.Models.ClassificacaoOrigem.Gestao> Gestaos { get; set; }

    public System.Data.Entity.DbSet<Safirex.Models.ClassificacaoEstrutura.Governo> Governos { get; set; }

    public System.Data.Entity.DbSet<Safirex.Models.ClassificacaoEstrutura.Secretaria> Secretarias { get; set; }
}
