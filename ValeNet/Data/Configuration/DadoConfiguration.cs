using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValeNet.Models;

namespace ValeNet.Data.Configuration
{
    public class DadoConfiguration : IEntityTypeConfiguration<Dado>
    {
        public void Configure(EntityTypeBuilder<Dado> builder)
        {
            builder.ToTable("Dados");

            builder
                .Property(a => a.Id)
                .HasColumnType("INT")
                .IsRequired();

            builder
                .Property(a => a.Comprador)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder
                .Property(a => a.Descricao)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder
                .Property(a => a.PrecoUnitario)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder
                .Property(a => a.Quantidade)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(a => a.Endereco)
                .HasColumnType("varchar(500)")
                .IsRequired();

            builder
                .Property(a => a.Fornecedor)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder
                .Property(a => a.NomeArquivo)
                .HasColumnType("varchar(700)")
                .IsRequired();

            builder
                .Property(a => a.Guid)
                .HasColumnType("varchar(700)")
                .IsRequired();

            builder
                .Property(a => a.Criacao)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.HasKey(pk => pk.Id)
                    .HasName("PK_Dados");

        }
    }
}
