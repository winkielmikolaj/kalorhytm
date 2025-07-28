using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Domain.Entities.BodyMeasurements
{
    public class BodyMeasurementEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public BodyMeasurementType Type { get; set; }
        public double Value { get; set; }
        public DateTime MeasurementDate { get; set; }
    }
}