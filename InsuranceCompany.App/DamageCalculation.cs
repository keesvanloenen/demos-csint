namespace InsuranceCompany.App;
// payout = uitkering = Auzahuring
// deductible = eigen risico
// applied deductible = toegepast eigen risico

public static class DamageCalculation
{
    public static (decimal payout, decimal appliedDeductible) CalculatePayout(decimal damageAmount, decimal deductible)
    {
        const decimal MaxDeductible = 500m;
        decimal appliedDeductible = Math.Min(deductible, MaxDeductible);

        decimal payout = damageAmount - appliedDeductible;
            
        if (payout < 0)
        {
            payout = 0;
        }

        return (payout, appliedDeductible);     // 👈 return tuple
    }

}
