using Dolittle.Strings;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace Dolittle.Applications.for_ApplicationLocationResolver
{

    public class when_asking_if_can_be_resolved_without_any_formats_matching : given.one_format
    {
        static Mock<ISegmentMatches> segment_matches;
        static bool result;

        Establish context = () => 
        {
            
            segment_matches = new Mock<ISegmentMatches>();
            format.Setup(_ => _.Match(typeof(object).Namespace)).Returns(segment_matches.Object);
            segment_matches.SetupGet(_ => _.HasMatches).Returns(false);
        };

        Because of = () => result = resolver.CanResolve(typeof(object));

        It should_consider_not_able_to_resolve = () => result.ShouldBeFalse();
    }
}