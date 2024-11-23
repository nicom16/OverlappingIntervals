

namespace OverlappingIntervals
{
    public class FlattenOverlappingIntervalsService : IFlattenOverlappingIntervalsService
    {
        public FlattenOverlappingIntervalsService() { }

        public List<Interval> FlattenOverlappingIntervals(List<Interval> intervals)
        {
            List<Interval> intervalsToCheck = 
                intervals.OrderBy(i => i.Start).ToList();
            List<Interval> flattenedIntervals = new List<Interval>();

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

                foreach (Interval interval in intervalsToSum)
                {
                    intervalsToCheck.Remove(interval);
                }

                intervalsToSum.Add(currentInterval);

                flattenedIntervals.Add(GetSumInterval(intervalsToSum));
            }

            if (flattenedIntervals.HasOverlappingIntervals())
                FlattenOverlappingIntervals(flattenedIntervals);

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
