using TechTalk.SpecFlow;
using NUnit.Framework;

namespace AsosUAT.Spec
{
    [Binding]
    public class BrowsingProductsSteps
    {
        private Website _website = new Website();

        [Given(@"I have gone to the Asos website")]
        public void GivenIHaveGoneToTheAsosWebsite()
        {
            _website.GoToHomePage();
        }
        
        [When(@"I click on the women's jean category")]
        public void WhenIClickOnTheWomenJeanCategory()
        {
            _website.ViewJeanCategory();
        }
        
        [Then(@"I should see a list of jeans")]
        public void ThenIShouldSeeAListOfJeans()
        {
            var jeans=_website.GetJeans();

            Assert.That(jeans, Is.Not.Empty);
        }
    }
}
