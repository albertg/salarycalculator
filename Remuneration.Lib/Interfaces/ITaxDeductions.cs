using System;
using System.Collections.Generic;
using System.Text;

namespace Quantum.OS.Remuneration.Library.Interfaces {
    public interface ITaxDeductions {
        double YearlySec80C { get; }

        double InterestOnHousingLoan { get; }

        double ProfessionalTax { get; }
    }
}
