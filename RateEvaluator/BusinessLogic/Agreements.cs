using RateEvaluator.SharedModels;
using System;

namespace RateEvaluator.BusinessLogic
{
    public class Agreements
    {

        public static AgreementExtended GetExtendedAgreement(Agreement agreement, BaseRate.RateType newBaseRateType, float oldBaseRateValue, float newBaseRateValue)
        {
            var agremeentExtended = new AgreementExtended(agreement, newBaseRateType);

            agremeentExtended.CurrentInterestRate = CalculateInterestRate(oldBaseRateValue, agremeentExtended.Margin);
            agremeentExtended.NewInterestRate = CalculateInterestRate(newBaseRateValue, agremeentExtended.Margin);

            agremeentExtended.DifferenceBetweenInterestRates = 
                CalculateDifference(agremeentExtended.CurrentInterestRate, agremeentExtended.NewInterestRate);

            return agremeentExtended;
        }

        private static float CalculateInterestRate(float baseRateValue, float margin)
        {
            return baseRateValue + margin;
        }
        
        private static float CalculateDifference(float value1, float value2)
        {
            return Math.Abs(value1 - value2);
        }      
    }
}