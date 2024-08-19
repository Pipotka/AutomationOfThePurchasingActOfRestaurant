using AutomationOfThePurchasingActOfRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Drawing;

namespace AutomationOfThePurchasingActOfRestaurant.DBConfigurations
{
    public class SignatureConfiguration : IEntityTypeConfiguration<Signature>
    {
        public void Configure(EntityTypeBuilder<Signature> builder)
        {
            builder.HasKey(s => s.SignatureId);

            builder.Property(s => s.Points)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<Point[]>(v))
                .Metadata.SetValueComparer(new ValueComparer<Point[]>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode()))
                    , c => c.ToArray()));

            builder.HasOne(s => s.Approver)
                .WithMany(a => a.Signatures)
                .HasForeignKey(s => s.ApproverId);
        }
    }
}
