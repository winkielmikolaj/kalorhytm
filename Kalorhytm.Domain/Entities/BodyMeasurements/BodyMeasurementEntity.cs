using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Domain.Entities.BodyMeasurements
{
    public class BodyMeasurementEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public BodyMeasurementType Type { get; set; }
        public double Value { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}