using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AsosUAT.Spec
{
    [Binding]
    public class BagSteps
    {
        private Website _website = new Website();

        private string _addedItem;

        [Given(@"I am viewing an item I wish to buy")]
        public void GivenIAmViewingAnItemIWishToBuy()
        {
            _website.GoToHomePage();
            _website.GoToGender("men");
            _website.ViewJeanCategory();
        }
        
        [When(@"I press ADD TO BAG")]
        public void WhenIPressADDTOBAG()
        {
            _website.ViewFirstItem();

            _addedItem = _website.GetItemName();

            _website.AddItemToBag();
        }
        
        [Then(@"the item should be added to my bag")]
        public void ThenTheItemShouldBeAddedToMyBag()
        {
            var bag = _website.GetBagContents().ToArray();
            Assert.That(bag[0], Is.EqualTo(_addedItem));
        }

        [AfterScenario]
        public void CloseBrowserWindow()
        {
            _website.CloseBrowser();
        }
    }
}
