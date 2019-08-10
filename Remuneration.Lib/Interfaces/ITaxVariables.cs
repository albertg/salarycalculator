namespace Quantum.OS.Remuneration.Library.Interfaces {
    public interface ITaxVariables {
        double Slab1TaxRate { get; }
        double Slab2TaxRate { get; }
        double Slab3TaxRate { get; }
        double CessOnTax { get; }
        double Slab1 { get; }
        double Slab2 { get; }
        double Slab3 { get; }
        double StandardDeduction { get; }
    }
}
