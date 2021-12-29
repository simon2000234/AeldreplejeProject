using System;
using System.Collections.Generic;
using AeldreplejeCore.Core.Application.Impl;
using AeldreplejeCore.Core.Entity;
using TechTalk.SpecFlow;
using Xunit;


namespace Spec4TestExam.Steps
{
    [Binding]
    public class NotificationSteps
    {
        private NotificationService ns;
        private User currentUser;
        private PendingShift currentShift;
        private bool result;
        public NotificationSteps()
        {
            ns = new NotificationService();
        }

        [Given(@"i have a qualification level of (.*)")]
        public void GivenIHaveAQualificationLevelOf(int p0)
        {
            Group group = new() {QualificationNumber = p0};
            currentUser = new User() {Group = group};
        }
        
        [Given(@"the shift has as qualification level of (.*)")]
        public void GivenTheShiftHasAsQualificationLevelOf(int p0)
        {
            Shift shift = new() {ShiftQualificationNumber = p0};
            currentShift = new PendingShift() {Shift = shift};
        }

        [When(@"i check qualification")]
        public void WhenICheckQualification()
        {
            result = ns.IsUserQualified(currentShift, currentUser);
        }


        [Then(@"i should be rejected")]
        public void ThenIShouldBeRejected()
        {
            Assert.False(result);
        }
        
        [Then(@"i should be accepted")]
        public void ThenIShouldBeAccepted()
        {
            Assert.True(result);
        }
    }
}
