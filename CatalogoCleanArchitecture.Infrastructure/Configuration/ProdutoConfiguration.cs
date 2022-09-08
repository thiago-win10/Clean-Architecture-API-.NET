using CatalogoCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogoCleanArchitecture.Infrastructure.Configuration
{

    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Preco);
            builder.Property(p => p.ImagemUrl).HasMaxLength(250);
            builder.Property(p => p.Estoque).IsRequired();
            builder.Property(p => p.DataCadastro).IsRequired();


            builder.HasOne(e => e.Categoria).WithMany(e => e.Produtos)
                .HasForeignKey(e => e.CategoriaId);
        }
    }
}
