using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverlappingIntervals
{
    public static class IntervalHelpers
    {
        public static bool IntervalsOverlap(Interval interval1, Interval interval2)
        {
            if (interval1.Start <= interval2.Start && interval2.Start <= interval1.End) 
                return true;

            if (interval1.Start <= interval2.End && interval2.End <= interval1.End)
                return true;

            if (interval2.Start <= interval1.Start && interval2.End >= interval1.End)
                return true;

            return false;
        }

        public static bool HasOverlappingIntervals(this List<Interval> intervals)
        {
            foreach (Interval interval in intervals)
            {
                if (intervals.HasIntervalsOverlappingInterval(interval))
                    return true;
            }

            return false;
        }

        public static List<Interval> GetIntervalsOverlappingInterval(this List<Interval> intervals, Interval interval)
        {
            return intervals 
                .Where(i => i != interval && IntervalHelpers.IntervalsOverlap(interval, i))
                .ToList();
        }

        public static bool HasIntervalsOverlappingInterval(this List<Interval> intervals, Interval interval)
        {
            return intervals.GetIntervalsOverlappingInterval(interval).Any();
        }
    }
}
