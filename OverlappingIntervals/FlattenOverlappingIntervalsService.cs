

namespace OverlappingIntervals
{
    public class FlattenOverlappingIntervalsService : IFlattenOverlappingIntervalsService
    {
        public FlattenOverlappingIntervalsService() { }

        public List<Interval> FlattenOverlappingIntervals(List<Interval> intervals)
        {
            List<Interval> flattenedIntervals = GetFlattenedIntervals(intervals);

            if (!flattenedIntervals.HasOverlappingIntervals())
                return flattenedIntervals;

            return FlattenOverlappingIntervals(flattenedIntervals);
        }

        private List<Interval> GetFlattenedIntervals(List<Interval> intervals)
        {
            List<Interval> flattenedIntervals = new List<Interval>();
            List<Interval> intervalsToCheck = intervals.OrderBy(i => i.Start).ToList(); 

            while (intervalsToCheck.Any())
            {
                Interval currentInterval = intervalsToCheck.First();
                intervalsToCheck.Remove(currentInterval);

                if (!intervalsToCheck.HasIntervalsOverlappingInterval(currentInterval))
                {
                    flattenedIntervals.Add(currentInterval);
                    continue;
                }

                List<Interval> intervalsToSum = 
                    intervalsToCheck.GetIntervalsOverlappingInterval(currentInterval);
                intervalsToCheck.RemoveAll(i => intervalsToSum.Contains(i));
                intervalsToSum.Add(currentInterval);

                Interval sumInterval = GetSumInterval(intervalsToSum);
                flattenedIntervals.Add(sumInterval);
            }

            return flattenedIntervals;
        }

        private Interval GetSumInterval(List<Interval> intervalsToSum) 
        {
            return new Interval()
            {
                Start = intervalsToSum.Min(i => i.Start),
                End = intervalsToSum.Max(i => i.End)
            };
        }
    }
}
