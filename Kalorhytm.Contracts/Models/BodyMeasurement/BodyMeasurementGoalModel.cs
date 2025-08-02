using Kalorhytm.Domain.Enums;

namespace Kalorhytm.Contracts.Models
{
    public class BodyMeasurementGoalModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public BodyMeasurementType Type { get; set; }
        public double TargetValue { get; set; }
        public DateTime EffectiveFrom  { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}