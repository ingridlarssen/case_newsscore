using NewsScoreBackend.API.Models;
using Exception = System.Exception;

namespace NewsScoreBackend.API.Services;

public class NewsscoreService
{
    public Newsscore CalculateNewsScore(MeasurementList measurementList)
    {
        ValidateMeasurementValues(measurementList);

        var score = measurementList.Measurements.Select(measurement =>
        {
            if (measurement.Type == MeasurementType.TEMP)
            {
                return NewsScoreHelper.GetTemperatureScore(measurement.Value);
            }

            if (measurement.Type == MeasurementType.RR)
            {
                return NewsScoreHelper.GetRespiratoryRateScore(measurement.Value);
            }

            if (measurement.Type == MeasurementType.HR)
            {
                return NewsScoreHelper.GetHeartRateScore(measurement.Value);
            }

            return 0;
        });

        return new Newsscore
        {
            Score = score.Sum(),
        };
    }

    private void ValidateMeasurementValues(MeasurementList measurementList)
    {
        foreach (var measurement in measurementList.Measurements)
        {
            if (measurement.Type == MeasurementType.HR && (measurement.Value < 25 || measurement.Value > 220))
            {
                throw new Exception("Invalid value for heartrate");
            }
            
            if (measurement.Type == MeasurementType.RR && (measurement.Value < 3 || measurement.Value > 60))
            {
                throw new Exception($"Invalid value for respiratory rate");
            }

            if (measurement.Type == MeasurementType.TEMP && (measurement.Value < 31 || measurement.Value > 42))
            {
                throw new Exception($"Invalid value for temperature");
            }
            
        }

    }
}