namespace OverlappingIntervals.Tests
{
    [TestFixture]
    public class FlattenOverlappingIntervalsServiceTests
    {
        private IFlattenOverlappingIntervalsService _flattenOverlappingIntervalsService;
        private DateTime _now = DateTime.Now;

        [SetUp]
        public void Setup()
        {
            _flattenOverlappingIntervalsService = new FlattenOverlappingIntervalsService();
        }

        [Test]
        public void FlattenOverlappingIntervals_OnOverlappingIntervals_RetursMerge()
        {
            List<Interval> intervals = new List<Interval>()
            {
                new Interval() { Start = _now.AddMinutes(-5), End = _now.AddMinutes(5) }, 
                new Interval() { Start = _now.AddMinutes(-3), End = _now.AddMinutes(10) }, 
            };

            List<Interval> flattendIntervals = 
                _flattenOverlappingIntervalsService.FlattenOverlappingIntervals(intervals);

            Assert.IsFalse(flattendIntervals.HasOverlappingIntervals());
            Assert.IsTrue(flattendIntervals.Count == 1);
        }

        [Test]
        public void FlattenOverlappingIntervals_OnThreeOverlappingIntervals_RetursMerge()
        {
            List<Interval> intervals = new List<Interval>()
            {
                new Interval() { Start = _now.AddMinutes(-5), End = _now.AddMinutes(5) }, 
                new Interval() { Start = _now.AddMinutes(-3), End = _now.AddMinutes(10) }, 
                new Interval() { Start = _now.AddMinutes(8), End = _now.AddMinutes(12) }, 
            };

            List<Interval> flattendIntervals = 
                _flattenOverlappingIntervalsService.FlattenOverlappingIntervals(intervals);

            Assert.IsFalse(flattendIntervals.HasOverlappingIntervals());
            Assert.IsTrue(flattendIntervals.Count == 1);
        }
    }
}