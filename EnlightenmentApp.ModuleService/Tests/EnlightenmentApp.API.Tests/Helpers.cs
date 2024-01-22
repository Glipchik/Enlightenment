using AutoFixture;
using AutoFixture.Xunit2;

namespace EnlightenmentApp.API.Tests
{
    public class AutoControllerDataAttribute() : AutoDataAttribute(() =>
        new Fixture().Customize(new OmitOnRecursionCustomization())
    );

    public class OmitOnRecursionCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
