using Quantum.OS.Remuneration.Library.Interfaces;

namespace Quantum.OS.Remuneration.Library {
    public class TaxVariables : ITaxVariables {
        public double Slab1TaxRate => 5 / 100.00;

        public double Slab2TaxRate => 20.00 / 100.00;

        public double Slab3TaxRate => 30.00 / 100.00;

        double ITaxVariables.CessOnTax => 4.00 / 100.00;

        double ITaxVariables.Slab1 => 250000.00;

        double ITaxVariables.Slab2 => 500000.00;

        double ITaxVariables.Slab3 => 1000000.00;

        double ITaxVariables.StandardDeduction => 50000.00;
    }
}
