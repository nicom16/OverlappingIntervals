namespace OverlappingIntervals
{
    public interface IFlattenOverlappingIntervalsService
    {
        List<Interval> FlattenOverlappingIntervals(List<Interval> intervals);
    }
}
