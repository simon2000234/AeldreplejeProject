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
        private List<User> result;
        public NotificationSteps()
        {
            ns = new NotificationService();
            currentUser = new User();
            currentShift = new PendingShift();
        }

        [Given(@"i meet all other requirements")]
        public void GivenIMeetAllOtherRequirements()
        {
            currentUser.Group = new Group() {QualificationNumber = int.MaxValue};
            currentUser.Shifts = new List<Shift>();
            currentShift.Shift = new Shift() {ShiftQualificationNumber = int.MinValue};
        }


        [Given(@"i have a qualification level of (.*)")]
        public void GivenIHaveAQualificationLevelOf(int p0)
        {
            currentUser.Group = new Group() { QualificationNumber = p0 };
        }
        
        [Given(@"the shift has as qualification level of (.*)")]
        public void GivenTheShiftHasAsQualificationLevelOf(int p0)
        {
            currentShift.Shift = new Shift() { ShiftQualificationNumber = p0 };
        }

        [When(@"i try to book the shift")]
        public void WhenITryToBookTheShift()
        {
            result = ns.GetValidUsers(currentShift, new List<User> {currentUser}, 5);
        }

        [Then(@"i should be rejected")]
        public void ThenIShouldBeRejected()
        {
            Assert.DoesNotContain(currentUser, result);
        }
        
        [Then(@"i should be accepted")]
        public void ThenIShouldBeAccepted()
        {
            Assert.Contains(currentUser, result);
        }

        [Given(@"i have a shift next week")]
        public void GivenIHaveAShiftNextWeek()
        {
            currentUser.Shifts.Add(new Shift(){Date = DateTime.Today.AddDays(7)});
        }

        [Given(@"there is a shift available tomorrow from (.*) to (.*)")]
        public void GivenThereIsAShiftAvailableTomorrowFromTo(int p0, int p1)
        {
            currentShift.Shift.Date = DateTime.Today.AddDays(1);
            currentShift.Shift.TimeStart = DateTime.Today.AddDays(1).AddHours(p0);
            currentShift.Shift.TimeEnd = DateTime.Today.AddDays(1).AddHours(p1);
        }

        [Given(@"i have a shift tomorrow from (.*) to (.*)")]
        public void GivenIHaveAShiftTomorrowFromTo(int p0, int p1)
        {
            Shift myShift = new Shift
            {
                Date = DateTime.Today.AddDays(1),
                TimeStart = DateTime.Today.AddDays(1).AddHours(p0),
                TimeEnd = DateTime.Today.AddDays(1).AddHours(p1)
            };

            currentUser.Shifts.Add(myShift);
        }


        [Given(@"i have (.*) shifts tomorrow")]
        public void GivenIHaveShiftsNextWeek(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                currentUser.Shifts.Add(new Shift{
                    Date = DateTime.Today.AddDays(1), 
                    TimeStart = DateTime.Today.AddDays(1).AddHours(i), 
                    TimeEnd = DateTime.Today.AddDays(1).AddHours(i+1)

                });
            }
        }

        [Given(@"there is a shift available tomorrow")]
        public void GivenThereIsAShiftAvailableNextWeek()
        {
            currentShift.Shift.Date = DateTime.Today.AddDays(1);
            currentShift.Shift.TimeStart = DateTime.Today.AddDays(1).AddHours(20);
            currentShift.Shift.TimeEnd = DateTime.Today.AddDays(1).AddHours(22);
        }



    }
}
