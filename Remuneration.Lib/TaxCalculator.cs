using Quantum.OS.Remuneration.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quantum.OS.Remuneration.Library {
    public class TaxCalculator {
        private const int MonthsInYear = 12;        
        private double yearlyGrossPay;
        private double taxableIncome;
        private double taxPayable;
        private double cessOnTax;
        private ITaxDeductions taxDeductions;

        public TaxCalculator(double yearlyGrossPay, ITaxDeductions taxDeductions) {
            this.yearlyGrossPay = yearlyGrossPay;
            this.taxDeductions = taxDeductions;
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
            taxableIncome = taxableIncome - TaxComponents.StandardDeduction;
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
            if (taxableIncome > TaxComponents.Slab1) {
                if (taxableIncome <= TaxComponents.Slab2) {
                    taxPayable = 0;
                }
                else {
                    taxPayable = taxPayable + ((TaxComponents.Slab2 - TaxComponents.Slab1) * TaxComponents.TaxSlab1);
                }
            }
        }

        private void CalculateTaxFromSlab2() {
            if (taxableIncome > TaxComponents.Slab2) {
                if (taxableIncome <= TaxComponents.Slab3) {
                    taxPayable = taxPayable + ((taxableIncome - TaxComponents.Slab2) * TaxComponents.TaxSlab2);
                }
                else {
                    taxPayable = taxPayable + ((TaxComponents.Slab3 - TaxComponents.Slab2) * TaxComponents.TaxSlab2);
                }
            }
        }

        private void CalculateTaxFromSlab3() {
            if (taxableIncome > TaxComponents.Slab3) {
                taxPayable = taxPayable + ((taxableIncome - TaxComponents.Slab3) * TaxComponents.TaxSlab3);
            }
        }

        private void CalculateCessOnTax() {
            cessOnTax = taxPayable * TaxComponents.CessOnTax;
        }
    }
}
