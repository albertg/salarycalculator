using Quantum.OS.Remuneration.Library.Interfaces;

namespace Quantum.OS.Remuneration.Library {
    public class TaxComponent : ITaxComponent {
        public TaxComponent(double yearlyPay, double yearlySec80C, double interestOnHousingLoan, double professionalTax) {
            this.YearlyPay = yearlyPay;
            this.YearlySec80C = yearlySec80C;
            this.InterestOnHousingLoan = interestOnHousingLoan;
            this.ProfessionalTax = professionalTax;
        }

        public double YearlyPay { get; private set; }

        public double YearlySec80C { get; private set; }

        public double InterestOnHousingLoan { get; private set; }

        public double ProfessionalTax { get; private set; }
    }
}
