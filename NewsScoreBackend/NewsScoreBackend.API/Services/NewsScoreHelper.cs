namespace NewsScoreBackend.API.Services;

public static class NewsScoreHelper
{
    public static int GetTemperatureScore(int temperature)
    {
        var temperatureScores = new List<Interval>
        {
            new Interval { Score = 2, Min = 31, Max = 35 },
            new Interval { Score = 1, Min = 35, Max = 36 },
            new Interval { Score = 0, Min = 36, Max = 38 },
            new Interval { Score = 1, Min = 38, Max = 39 },
            new Interval { Score = 2, Min = 39, Max = 42 }
        };
        
        return temperatureScores.First(x => temperature > x.Min && temperature <= x.Max).Score;
    }
    
    public static int GetHeartRateScore(int heartRate)
    {
        var heartRateScores = new List<Interval>
        {
            new Interval { Score = 3, Min = 25, Max = 40 },
            new Interval { Score = 1, Min = 40, Max = 50 },
            new Interval { Score = 0, Min = 50, Max = 90 },
            new Interval { Score = 1, Min = 90, Max = 110 },
            new Interval { Score = 2, Min = 110, Max = 130 },
            new Interval { Score = 3, Min = 130, Max = 220 }
        };
        
        return heartRateScores.First(x => heartRate > x.Min && heartRate <= x.Max).Score;
    }
    
    public static int GetRespiratoryRateScore(int respiratoryRate)
    {
        var respiratoryRateScores = new List<Interval>
        {
            new Interval { Score = 3, Min = 3, Max = 8 },
            new Interval { Score = 1, Min = 8, Max = 11 },
            new Interval { Score = 0, Min = 11, Max = 20 },
            new Interval { Score = 2, Min = 20, Max = 24 },
            new Interval { Score = 3, Min = 24, Max = 60 },
        };
        
        return respiratoryRateScores.First(x => respiratoryRate > x.Min && respiratoryRate <= x.Max).Score;
    }
    
    private class Interval
    {
        public int Score;
        public int Min;
        public int Max;
    }
    
}