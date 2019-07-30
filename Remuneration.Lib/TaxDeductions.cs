using Quantum.OS.Remuneration.Library.Interfaces;

namespace Quantum.OS.Remuneration.Library {
    public class TaxDeductions : ITaxDeductions {
        public TaxDeductions(double yearlySec80C, double interestOnHousingLoan, double professionalTax) {
            this.YearlySec80C = yearlySec80C;
            this.InterestOnHousingLoan = interestOnHousingLoan;
            this.ProfessionalTax = professionalTax;
        }

        public double YearlySec80C { get; private set; }

        public double InterestOnHousingLoan { get; private set; }

        public double ProfessionalTax { get; private set; }
    }
}
