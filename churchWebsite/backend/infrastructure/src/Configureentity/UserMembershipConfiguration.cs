


using domain.src.church;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserMembershipConfiguration
    : IEntityTypeConfiguration<UserMembership>
{
    public void Configure(
        EntityTypeBuilder<UserMembership> builder)
    {
        builder.HasOne<Appuser>()
            .WithMany()
            .HasForeignKey(membership => membership.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(membership => membership.Church)
            .WithMany()
            .HasForeignKey(membership => membership.ChurchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
