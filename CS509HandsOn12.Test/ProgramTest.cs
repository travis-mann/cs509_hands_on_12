using Xunit;
using FluentAssertions;
using CS509HandsOn12;

namespace CS509HandsOn12.Test
{
    public class TestProgram
    {
        [Fact]
        public void MultiplyReturnsProductOfArguments()
        {
            Program.Multiply(3, 4).Should().Be(12);
        }
    }
}
