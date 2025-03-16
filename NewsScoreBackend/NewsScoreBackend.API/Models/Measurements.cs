using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;

namespace NewsScoreBackend.API.Models;

public class Newsscore
{
    public int Score { get; set; }
}

public class MeasurementList
{
    public IEnumerable<Measurement> Measurements { get; set; }
}

public class Measurement
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MeasurementType Type { get; set; }
    public double Value { get; set; }
}

public enum MeasurementType
{
    TEMP,
    HR,
    RR,
}