using AutoMapper;
using NUnit.Framework;

namespace MarketApp.Business.Tests.UserServiceTests;

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