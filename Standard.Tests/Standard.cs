using System;
using Xunit;

namespace Standard.Tests
{
    using Standard;

    public class TStandard
    {
        [Fact]
        public void IsPrime_Prime()
        {
            var math = new MyMaths();
            math.IsPrime(2);
        }
    }
}
