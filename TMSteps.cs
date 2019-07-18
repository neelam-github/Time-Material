using System;
using TechTalk.SpecFlow;

namespace SeleniumFirst
{
    [Binding]
    public class TMSteps
    {
        [Then(@"I would be able to edit a time record sucessfully")]
        public void ThenIWouldBeAbleToEditATimeRecordSucessfully()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
