using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Domain.Entities.BodyMeasurements
{
    public class BodyMeasurementGoalEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public BodyMeasurementType Type { get; set; }
        public double TargetValue { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}