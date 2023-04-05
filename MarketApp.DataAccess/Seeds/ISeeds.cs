using Microsoft.EntityFrameworkCore;

namespace TestAPIMarket.Data.Seeds;

public interface ISeeds {
    ModelBuilder Seed(ModelBuilder builder);
}