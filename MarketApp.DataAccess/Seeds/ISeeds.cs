using Microsoft.EntityFrameworkCore;

namespace MarketApp.DataAccess.Seeds;

public interface ISeeds {
    ModelBuilder Seed(ModelBuilder builder);
}