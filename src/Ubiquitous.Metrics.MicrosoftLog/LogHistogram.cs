using System.Diagnostics;
using Ubiquitous.Metrics.InMemory;

namespace Ubiquitous.Metrics.MicrosoftLog;

class LogHistogram(MetricDefinition metricDefinition, ILogger log)
    : LoggingMetric(metricDefinition, log), IHistogramMetric {
    readonly InMemoryHistogram _histogram = new();

    double Sum   => _histogram.Sum;
    long   Count => _histogram.Count;

    public void Observe(Stopwatch stopwatch, string[]? labels = null, int count = 1) {
        _histogram.Observe(stopwatch, labels, count);
        LogCurrent(labels);
    }

    public void Observe(DateTimeOffset when, string[]? labels = null, int count = 1) {
        _histogram.Observe(when, labels, count);
        LogCurrent(labels);
    }

    public void Observe(TimeSpan duration, string[]? labels = null, int count = 1) {
        _histogram.Observe(duration, labels, count);
        LogCurrent(labels);
    }

    void LogCurrent(string[]? labels)
        => Log.LogInformation(
            "Histogram {Name}: sum {Sum}, count {Count}, labels {Labels}",
            Definition.Name,
            Sum,
            Count,
            LabelsString(labels)
        );
}
