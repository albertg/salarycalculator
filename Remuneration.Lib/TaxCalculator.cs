using Quantum.OS.Remuneration.Library.Interfaces;
using System;

namespace Quantum.OS.Remuneration.Library {
    public class TaxCalculator {
        private const int MonthsInYear = 12;        
        private double yearlyGrossPay;
        private double taxableIncome;
        private double taxPayable;
        private double cessOnTax;
        private ITaxDeductions taxDeductions;
        private ITaxVariables taxVariables;

        public TaxCalculator(double yearlyGrossPay, ITaxDeductions taxDeductions, ITaxVariables taxVariables) {
            this.yearlyGrossPay = yearlyGrossPay;
            this.taxDeductions = taxDeductions;
            this.taxVariables = taxVariables;
        }

        public double CalculateYearlyTax() {
            CalculateTaxableIncome();
            ApplyTaxSlabs();
            CalculateCessOnTax();
            return Math.Round(taxPayable + cessOnTax);
        }

        private void CalculateTaxableIncome() {
            taxableIncome = yearlyGrossPay;
            taxPayable = 0;
            ReduceStandardDeductionFromGrossPay();
            ReduceProfessionalTaxFromGrossPay();
            ReduceSec80CInvestmentsFromGrossPay();
            ReduceInterestFromHousingLoanFromGrossPay();
        }

        private void ReduceStandardDeductionFromGrossPay() {
            taxableIncome = taxableIncome - taxVariables.StandardDeduction;
        }

        private void ReduceProfessionalTaxFromGrossPay() {
            taxableIncome = taxableIncome - taxDeductions.ProfessionalTax;
        }

        private void ReduceSec80CInvestmentsFromGrossPay() {
            taxableIncome = taxableIncome - taxDeductions.YearlySec80C;
        }

        private void ReduceInterestFromHousingLoanFromGrossPay() {
            taxableIncome = taxableIncome - taxDeductions.InterestOnHousingLoan;
        }

        private void ApplyTaxSlabs() {
            CalculateTaxFromSlab1();
            CalculateTaxFromSlab2();
            CalculateTaxFromSlab3();
        }

        private void CalculateTaxFromSlab1() {
            if (taxableIncome > taxVariables.Slab1) {
                if (taxableIncome <= taxVariables.Slab2) {
                    taxPayable = 0;
                }
                else {
                    taxPayable = taxPayable + ((taxVariables.Slab2 - taxVariables.Slab1) * taxVariables.Slab1TaxRate);
                }
            }
        }

        private void CalculateTaxFromSlab2() {
            if (taxableIncome > taxVariables.Slab2) {
                if (taxableIncome <= taxVariables.Slab3) {
                    taxPayable = taxPayable + ((taxableIncome - taxVariables.Slab2) * taxVariables.Slab2TaxRate);
                }
                else {
                    taxPayable = taxPayable + ((taxVariables.Slab3 - taxVariables.Slab2) * taxVariables.Slab2TaxRate);
                }
            }
        }

        private void CalculateTaxFromSlab3() {
            if (taxableIncome > taxVariables.Slab3) {
                taxPayable = taxPayable + ((taxableIncome - taxVariables.Slab3) * taxVariables.Slab3TaxRate);
            }
        }

        private void CalculateCessOnTax() {
            cessOnTax = taxPayable * taxVariables.CessOnTax;
        }
    }
}
