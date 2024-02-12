namespace Ubiquitous.Metrics.NoMetrics;

class NoHistogram : IHistogramMetric {
    internal NoHistogram(MetricDefinition _) { }

    public void Observe(Stopwatch stopwatch, string[]? labels = null, int count = 1) { }
        
    public void Observe(Stopwatch stopwatch, string? label = null, int count = 1) { }

    public void Observe(DateTimeOffset when, string[]? labels = null, int count = 1) { }
        
    public void Observe(DateTimeOffset when, string? label = null, int count = 1) { }

    public void Observe(TimeSpan duration, string[]? labels = null, int count = 1) { }
        
    public void Observe(TimeSpan duration, string? label = null, int count = 1) { }
}