using DevAnalytics.AnalyticsShared;
using NUnit.Framework;

namespace UnitTests
{
    public class DeveloperResolve
    {
        [Test]
        public void CreateDeveloperAndAnnotate()
        {
            var resolver = new DeveloperResolver();

            var developer = resolver.GetOrCreateDeveloperFromId("ziga.osolin@gmail.com");
            Assert.IsNotNull(developer);
            Assert.AreEqual(null, developer.Name);
            Assert.AreEqual(null, developer.Email);
            Assert.AreEqual("ziga.osolin@gmail.com", developer.Id);

            developer.Name = "Ziga";
            Assert.AreEqual("Ziga", resolver.GetOrCreateDeveloperFromId("Ziga").Name);
            
            developer.Email = "ziga.osolin@gmail.com";
            Assert.AreEqual("Ziga", resolver.GetOrCreateDeveloperFromId("ziga.osolin@gmail.com").Name);
        }

        [Test]
        public void AddAdditionalIds()
        {
            var resolver = new DeveloperResolver();

            var developer = resolver.GetOrCreateDeveloperFromId("ziga.osolin");
            Assert.IsNotNull(developer);
            
            resolver.AddDeveloperId(developer, "ziga.osolin@someotherprovider.com");

            var otherDeveloper = resolver.GetOrCreateDeveloperFromId("ziga.osolin@someotherprovider.com");
            Assert.AreEqual(developer, otherDeveloper);
        }
    }
}