using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Seeds;

public static class SeedExtension {
    public static ModelBuilder Seed(this ModelBuilder builder, ISeeds seeds) {
        seeds.Seed(builder);
        return builder;
    }
}