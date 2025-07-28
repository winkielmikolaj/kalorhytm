using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Contracts.Models
{
    public class BodyMeasurementGoalModel
    {
        public Guid Id { get; set; }
        public BodyMeasurementType Type { get; set; }
        public double TargetValue { get; set; }
        public DateTime EffectiveFrom  { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}