using AutoMapper;
using NUnit.Framework;

namespace MarketApp.API.Tests.API;

[TestFixture]
public abstract class TestBase {
    [SetUp]
    public abstract void Setup();

    [TearDown]
    public abstract void TearDown();

    protected Mapper CreateMapper(params Profile[] profiles) {
        return new(new MapperConfiguration(cfg => { cfg.AddProfiles(profiles); }));
    }
}