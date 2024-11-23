namespace OverlappingIntervals
{
    public class Interval
    {
        public DateTime Start;
        public DateTime End;

        public Interval() { }

        public Interval(DateTime start, DateTime end) 
        { 
            Start = start; 
            End = end; 
        }

        public bool Overlaps(Interval interval)
        { 
            if (this.Start <= interval.Start && interval.Start <= this.End) 
                return true;

            if (this.Start <= interval.End && interval.End <= this.End)
                return true;

            if (interval.Start <= this.Start && interval.End >= this.End)
                return true;

            return false;
        }
    }
}
