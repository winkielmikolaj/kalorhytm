using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Contracts.Models
{
    public class BodyMeasurementModel
    {
        public Guid Id { get; set; }
        public BodyMeasurementType Type { get; set; }
        public DateTime MeasurementDate { get; set; }
        public double Value { get; set; }
    }
}