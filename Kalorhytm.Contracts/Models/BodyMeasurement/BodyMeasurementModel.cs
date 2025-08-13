using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Contracts.Models
{
    public class BodyMeasurementModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public BodyMeasurementType Type { get; set; }
        public DateTime MeasurementDate { get; set; } = DateTime.UtcNow;
        public double Value { get; set; }
    }
}