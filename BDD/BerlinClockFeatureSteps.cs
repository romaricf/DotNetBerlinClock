using System;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock
{
    [Binding]
    public class TheBerlinClockSteps
    {
        private String theTime;
        
        [When(@"the time is ""(.*)""")]
        public void WhenTheTimeIs(string time)
        {
            theTime = time;
        }
        
        [Then(@"the clock should look like")]
        public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
        {
            Assert.AreEqual(BerlinClockTimeConverter.ToBerlinClockTime(theTime), theExpectedBerlinClockOutput);
        }

        [Then(@"there is a format error")]
        public void ThereIsAFormatError()
        {
            try
            {
                BerlinClockTimeConverter.ToBerlinClockTime(theTime);
                Assert.Fail("Expected exception was not thrown.");
            }
            catch(FormatException) { }
            catch(Exception e)
            {
                Assert.Fail("Unexpected exception was thrown. " + e);
            }
        }
    }
}
