using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlappingIntervals.Tests
{
    [TestFixture]
    internal class IntervalHelpersTests
    {
        private DateTime _now = DateTime.Now;

        [Test]
        public void IntervalsOverlap_OnStartComprised_ReturnsTrue()
        {
            Interval interval1 = 
                new Interval(_now, _now.AddMinutes(5));
            Interval interval2 = 
                new Interval(_now.AddMinutes(4), _now.AddMinutes(10));

            Assert.IsTrue(IntervalHelpers.IntervalsOverlap(interval1, interval2));
        }

        [Test]
        public void IntervalsOverlap_OnEndComprised_ReturnsTrue()
        {
            Interval interval1 = 
                new Interval(_now, _now.AddMinutes(5));
            Interval interval2 = 
                new Interval(_now.AddMinutes(-10), _now.AddMinutes(1));

            Assert.IsTrue(IntervalHelpers.IntervalsOverlap(interval1, interval2));
        }

        [Test]
        public void IntervalsOverlap_OnOuterStartEnd_ReturnsTrue()
        {
            Interval interval1 = 
                new Interval(_now, _now.AddMinutes(5));
            Interval interval2 = 
                new Interval(_now.AddMinutes(-10), _now.AddMinutes(10));

            Assert.IsTrue(IntervalHelpers.IntervalsOverlap(interval1, interval2));
        }

        [Test]
        public void IntervalsOverlap_OnSameEndStart_ReturnsTrue()
        {
            Interval interval1 = 
                new Interval(_now, _now.AddMinutes(5));
            Interval interval2 = 
                new Interval(_now.AddMinutes(-10), _now);

            Assert.IsTrue(IntervalHelpers.IntervalsOverlap(interval1, interval2));
        }

        [Test]
        public void IntervalsOverlap_OnSameStartEnd_ReturnsTrue()
        {
            Interval interval1 = 
                new Interval(_now, _now.AddMinutes(5));
            Interval interval2 = 
                new Interval(_now.AddMinutes(5), _now.AddMinutes(15));

            Assert.IsTrue(IntervalHelpers.IntervalsOverlap(interval1, interval2));
        }

        [Test]
        public void IntervalsOverlap_OnSameInterval_ReturnsTrue()
        {
            Interval interval1 = 
                new Interval(_now, _now.AddMinutes(5));
            Interval interval2 = 
                new Interval(_now, _now.AddMinutes(5));

            Assert.IsTrue(IntervalHelpers.IntervalsOverlap(interval1, interval2));
        }

        [Test]
        public void IntervalsOverlap_OnDifferentInterval_ReturnsFalse()
        {
            Interval interval1 = 
                new Interval(_now, _now.AddMinutes(5));
            Interval interval2 = 
                new Interval(_now.AddMinutes(10), _now.AddMinutes(20));

            Assert.IsFalse(IntervalHelpers.IntervalsOverlap(interval1, interval2));
        }
    }
}
