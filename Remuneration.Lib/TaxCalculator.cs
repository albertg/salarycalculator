using Quantum.OS.Remuneration.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quantum.OS.Remuneration.Library {
    public class TaxCalculator {
        private const int MonthsInYear = 12;
        private const double TaxSlab1 = 5 / 100.00;
        private const double TaxSlab2 = 20.00 / 100.00;
        private const double TaxSlab3 = 30.00 / 100.00;
        private const double CessOnTax = 4.00 / 100.00;
        private const double Slab1 = 250000.00;
        private const double Slab2 = 500000.00;
        private const double Slab3 = 1000000.00;
        private const double StandardDeduction = 50000.00;
        private double taxableIncome;
        private double taxPayable;
        private double cessOnTax;
        private ITaxComponent taxComponent;

        public TaxCalculator(ITaxComponent taxComponent) {
            this.taxComponent = taxComponent;
        }

        public double CalculateYearlyTax() {
            CalculateTaxableIncome();
            ApplyTaxSlabs();
            CalculateCessOnTax();
            return Math.Round(taxPayable + cessOnTax);
        }

        private void CalculateTaxableIncome() {
            taxableIncome = taxComponent.YearlyGrossPay;
            taxPayable = 0;
            ReduceStandardDeductionFromGrossPay();
            ReduceProfessionalTaxFromGrossPay();
            ReduceSec80CInvestmentsFromGrossPay();
            ReduceInterestFromHousingLoanFromGrossPay();
        }

        private void ReduceStandardDeductionFromGrossPay() {
            taxableIncome = taxableIncome - StandardDeduction;
        }

        private void ReduceProfessionalTaxFromGrossPay() {
            taxableIncome = taxableIncome - taxComponent.ProfessionalTax;
        }

        private void ReduceSec80CInvestmentsFromGrossPay() {
            taxableIncome = taxableIncome - taxComponent.YearlySec80C;
        }

        private void ReduceInterestFromHousingLoanFromGrossPay() {
            taxableIncome = taxableIncome - taxComponent.InterestOnHousingLoan;
        }

        private void ApplyTaxSlabs() {
            CalculateTaxFromSlab1();
            CalculateTaxFromSlab2();
            CalculateTaxFromSlab3();
        }

        private void CalculateTaxFromSlab1() {
            if (taxableIncome > Slab1) {
                if (taxableIncome <= Slab2) {
                    taxPayable = 0;
                }
                else {
                    taxPayable = taxPayable + ((Slab2 - Slab1) * TaxSlab1);
                }
            }
        }

        private void CalculateTaxFromSlab2() {
            if (taxableIncome > Slab2) {
                if (taxableIncome <= Slab3) {
                    taxPayable = taxPayable + ((taxableIncome - Slab2) * TaxSlab2);
                }
                else {
                    taxPayable = taxPayable + ((Slab3 - Slab2) * TaxSlab2);
                }
            }
        }

        private void CalculateTaxFromSlab3() {
            if (taxableIncome > Slab3) {
                taxPayable = taxPayable + ((taxableIncome - Slab3) * TaxSlab3);
            }
        }

        private void CalculateCessOnTax() {
            cessOnTax = taxPayable * CessOnTax;
        }
    }
}
