using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using ShopManagement.Domain.SliderAgg;

namespace ShopManagement.Infrastructure.Efcore.Mapping
{
    public class SliderMapping : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.ToTable("ShopSlider");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(1000).IsRequired();
        }
    }
}
