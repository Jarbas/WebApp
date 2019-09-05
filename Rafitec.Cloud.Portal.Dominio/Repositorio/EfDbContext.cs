using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Rafitec.Cloud.Portal.Dominio.Entidades;

namespace Rafitec.Cloud.Portal.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        //    public DbSet<Cidade> Cidades { get; set; }
        //    public DbSet<Estado> Estados { get; set; }
        //    public DbSet<Entidade> Entidades { get; set; }
        //    public DbSet<Pais> Paises { get; set; }
        //   public DbSet<UnidadeNegocio> UnidadesNegocio { get; set; }
        //    public DbSet<UnidadeVenda> UnidadesVenda { get; set; }
        //     public DbSet<ProdutoTipo> ProdutosTipo { get; set; }
        //    public DbSet<Produto> Produtos { get; set; }
        //     public DbSet<Pedido> Pedidos { get; set; }
        //    public DbSet<UnidadeMedida> UnidadesMedida { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet <OsStatus> OsStatus { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public OsTi OsTi { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = true;

            //modelBuilder.HasDefaultSchema("RAFITEC");
            modelBuilder.HasDefaultSchema("PROPEX");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Usuario>().ToTable("USUARIOS");
            modelBuilder.Entity<OsStatus>().ToTable("OS_STATUS");
            modelBuilder.Entity<Setor>().ToTable("SETORES");
            modelBuilder.Entity<OsTi>().ToTable("OS_TI").Property(ot => ot.IdOsTi).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None); // NECESSARIO PARA PEGAR O GET SEQUENCIA NO CÓDIGO
            //    modelBuilder.Entity<Estado>().ToTable("UNIDADES_FEDERACAO");
            //     modelBuilder.Entity<Entidade>().ToTable("ENTIDADES");
            //    modelBuilder.Entity<Pais>().ToTable("PAISES");
            //    modelBuilder.Entity<Usuario>().ToTable("USUARIOS");
            //    modelBuilder.Entity<UnidadeNegocio>().ToTable("UNIDADES_NEGOCIO");
            //    modelBuilder.Entity<UnidadeVenda>().ToTable("UNIDADES_VENDA");
            //    modelBuilder.Entity<ProdutoTipo>().ToTable("PRODUTOS_TIPO");
            //    modelBuilder.Entity<Produto>().ToTable("PRODUTOS");
            //    modelBuilder.Entity<Pedido>().ToTable("PEDIDOS");
            //    modelBuilder.Entity<UnidadeMedida>().ToTable("UNIDADES_MEDIDA");
            //    modelBuilder.Entity<OrdemProducaoAcompanhamento>().ToTable("ORDEM_PRODUCAO_ACOMPANHAMENTO");
        }
        
    }
}
