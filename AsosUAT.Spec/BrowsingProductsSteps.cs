using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AsosUAT.Spec
{
    [Binding]
    public class BrowsingProductsSteps
    {
        private Website _website = new Website();

        [Given(@"I am on the ASOS homepage")]
        public void GivenIAmOnTheASOSHomepage()
        {
            _website.GoToHomePage();
        }
        
        [When(@"I click on the '(.*)'s jeans category")]
        public void WhenIClickOnTheGenderJeansCategory(string gender)
        {
            _website.GoToGender(gender);
            _website.ViewJeanCategory();
        }

        [Then(@"I should see a list of jeans")]
        public void ThenIShouldSeeAListOfJeans()
        {
            var jeans = _website.GetJeans();

            Assert.That(jeans, Is.Not.Empty);
        }

        [AfterScenario]
        public void CloseBrowserWindow()
        {
            _website.CloseBrowser();
        }
    }
}
