using Microsoft.EntityFrameworkCore;

namespace TestAPIMarket.Data.Seeds;

public static class SeedExtension {
    public static ModelBuilder Seed(this ModelBuilder builder, ISeeds seeds) {
        seeds.Seed(builder);
        return builder;
    }
}