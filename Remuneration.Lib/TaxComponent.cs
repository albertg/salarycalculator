using Quantum.OS.Remuneration.Library.Interfaces;

namespace Quantum.OS.Remuneration.Library {
    public class TaxComponent : ITaxComponent {
        public TaxComponent(double yearlyGrossPay, double yearlySec80C, double interestOnHousingLoan, double professionalTax) {
            this.YearlyGrossPay = yearlyGrossPay;
            this.YearlySec80C = yearlySec80C;
            this.InterestOnHousingLoan = interestOnHousingLoan;
            this.ProfessionalTax = professionalTax;
        }

        public double YearlyGrossPay { get; private set; }

        public double YearlySec80C { get; private set; }

        public double InterestOnHousingLoan { get; private set; }

        public double ProfessionalTax { get; private set; }
    }
}
