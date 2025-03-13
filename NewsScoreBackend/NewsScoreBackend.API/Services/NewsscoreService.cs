using NewsScoreBackend.API.Models;

namespace NewsScoreBackend.API.Services;

public class NewsscoreService
{
    public int CalculateNewsScore(Measurements measurements)
    {
        ValidateMeasurementValues(measurements);
        
        var temperatureScore = NewsScoreHelper.GetTemperatureScore(measurements.Temperature);
        var heartRateScore = NewsScoreHelper.GetHeartRateScore(measurements.Heartrate);
        var respiratoryRate = NewsScoreHelper.GetRespiratoryRateScore(measurements.RespiratoryRate);
        
        return temperatureScore + heartRateScore + respiratoryRate;
    }

    private void ValidateMeasurementValues(Measurements measurements)
    {
        if (measurements.Heartrate < 25 || measurements.Heartrate > 220)
        {
            throw new Exception($"Invalid value for heartrate");
        }
        if (measurements.RespiratoryRate < 3 || measurements.RespiratoryRate > 60)
        {
            throw new Exception($"Invalid value for respiratory rate");
        }

        if (measurements.Temperature < 31 || measurements.Temperature > 42)
        {
            throw new Exception($"Invalid value for temperature");
        }
    }
}