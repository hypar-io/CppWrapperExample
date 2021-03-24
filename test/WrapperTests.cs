using Xunit;
using System.Collections.Generic;

namespace CppWrapperExample.Tests
{
    public class WrapperTests
    {
        [Fact]
        public void CallsWrapperMethodSuccessfully()
        {
            CppWrapperExample.Execute(new Dictionary<string, Elements.Model>(), new CppWrapperExampleInputs(1, 1, null, null, null, null, null, null));
        }
    }
}