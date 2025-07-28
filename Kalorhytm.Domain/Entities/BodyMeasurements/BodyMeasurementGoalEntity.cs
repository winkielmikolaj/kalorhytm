using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Domain.Entities.BodyMeasurements
{
    public class BodyMeasurementGoalEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public BodyMeasurementType Type { get; set; }
        public double TargetValue { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}