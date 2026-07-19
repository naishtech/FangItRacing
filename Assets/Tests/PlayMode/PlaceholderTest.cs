using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace FangItRacing.Tests.PlayMode
{
    [TestFixture]
    public class PlaceholderTest
    {
        [UnityTest]
        public IEnumerator Placeholder_AlwaysPasses()
        {
            yield return null;
            Assert.IsTrue(true);
        }
    }
}
