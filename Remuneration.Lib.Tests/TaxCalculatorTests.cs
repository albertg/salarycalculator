using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quantum.OS.Remuneration.Library;
using Quantum.OS.Remuneration.Library.Interfaces;

namespace Remuneration.Lib.Tests {
    /// <summary>
    /// Summary description for TaxCalculatorTests
    /// </summary>
    [TestClass]
    public class TaxCalculatorTests {
        public TaxCalculatorTests() {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void CalculateYearlyTaxAtSlab3WithHousingLoanInterestAndSec80CTest() {
            double yearlyPay = 2511444;
            double yearlySec80C = 150000;
            double interestOnHousingLoan = 200000;
            double professionalTax = 2400.00;
            ITaxDeductions taxDeductions = new TaxDeductions(yearlySec80C, interestOnHousingLoan, professionalTax);
            TaxCalculator taxCalculator = new TaxCalculator(yearlyPay, taxDeductions);
            double expectedTaxWithCess = 463022;
            double actualTaxWithCess = taxCalculator.CalculateYearlyTax();
            Assert.AreEqual(expectedTaxWithCess, actualTaxWithCess, $"CalculateYearlyTaxAtSlab3WithHousingLoanInterestAndSec80CTest test failed. Expected: {expectedTaxWithCess}, but got: {actualTaxWithCess}");
        }

        [TestMethod]
        public void CalculateYearlyTaxConsistencyTest() {
            double yearlyPay = 2511444;
            double yearlySec80C = 150000;
            double interestOnHousingLoan = 200000;
            double professionalTax = 2400.00;
            ITaxDeductions taxDeductions = new TaxDeductions(yearlySec80C, interestOnHousingLoan, professionalTax);
            TaxCalculator taxCalculator = new TaxCalculator(yearlyPay, taxDeductions);
            double expectedTaxWithCess = 463022;
            double actualTaxWithCess = taxCalculator.CalculateYearlyTax();
            Assert.AreEqual(expectedTaxWithCess, actualTaxWithCess, $"CalculateYearlyTaxConsistencyTest test failed at first assert. Expected: {expectedTaxWithCess}, but got: {actualTaxWithCess}");

            actualTaxWithCess = taxCalculator.CalculateYearlyTax();
            Assert.AreEqual(expectedTaxWithCess, actualTaxWithCess, $"CalculateYearlyTaxConsistencyTest test failed at second assert. Expected: {expectedTaxWithCess}, but got: {actualTaxWithCess}");
        }

        [TestMethod]
        public void CalculateYearlyTaxAtSlab3WithoutHousingLoanInterestAndSec80CTest() {
            double yearlyPay = 2511444;
            double yearlySec80C = 0;
            double interestOnHousingLoan = 0;
            double professionalTax = 2400.00;
            ITaxDeductions taxDeductions = new TaxDeductions(yearlySec80C, interestOnHousingLoan, professionalTax);
            TaxCalculator taxCalculator = new TaxCalculator(yearlyPay, taxDeductions);
            double expectedTaxWithCess = 572222;
            double actualTaxWithCess = taxCalculator.CalculateYearlyTax();
            Assert.AreEqual(expectedTaxWithCess, actualTaxWithCess, $"CalculateYearlyTaxAtSlab3WithoutHousingLoanInterestAndSec80CTest test failed. Expected: {expectedTaxWithCess}, but got: {actualTaxWithCess}");
        }

        [TestMethod]
        public void CalculateYearlyTaxAtSlab2WithHousingLoanInterestAndSec80CTest() {
            double yearlyPay = 1391340;
            double yearlySec80C = 150000;
            double interestOnHousingLoan = 200000;
            double professionalTax = 2400.00;
            ITaxDeductions taxDeductions = new TaxDeductions(yearlySec80C, interestOnHousingLoan, professionalTax);
            TaxCalculator taxCalculator = new TaxCalculator(yearlyPay, taxDeductions);
            double expectedTaxWithCess = 114700;
            double actualTaxWithCess = taxCalculator.CalculateYearlyTax();
            Assert.AreEqual(expectedTaxWithCess, actualTaxWithCess, $"CalculateYearlyTaxAtSlab2WithHousingLoanInterestAndSec80CTest test failed. Expected: {expectedTaxWithCess}, but got: {actualTaxWithCess}");
        }

        [TestMethod]
        public void CalculateYearlyTaxAtSlab2WithoutHousingLoanInterestAndSec80CTest() {
            double yearlyPay = 1391340;
            double yearlySec80C = 0;
            double interestOnHousingLoan = 0;
            double professionalTax = 2400.00;
            ITaxDeductions taxDeductions = new TaxDeductions(yearlySec80C, interestOnHousingLoan, professionalTax);
            TaxCalculator taxCalculator = new TaxCalculator(yearlyPay, taxDeductions);
            double expectedTaxWithCess = 222749;
            double actualTaxWithCess = taxCalculator.CalculateYearlyTax();
            Assert.AreEqual(expectedTaxWithCess, actualTaxWithCess, $"CalculateYearlyTaxAtSlab2WithoutHousingLoanInterestAndSec80CTest test failed. Expected: {expectedTaxWithCess}, but got: {actualTaxWithCess}");
        }

        [TestMethod]
        public void CalculateYearlyTaxAtSalaryLessThanSlab2WithSec80CTest() {
            double yearlyPay = 542100;
            double yearlySec80C = 150000;
            double interestOnHousingLoan = 0;
            double professionalTax = 2400.00;
            ITaxDeductions taxDeductions = new TaxDeductions(yearlySec80C, interestOnHousingLoan, professionalTax);
            TaxCalculator taxCalculator = new TaxCalculator(yearlyPay, taxDeductions);
            double expectedTaxWithCess = 0;
            double actualTaxWithCess = taxCalculator.CalculateYearlyTax();
            Assert.AreEqual(expectedTaxWithCess, actualTaxWithCess, $"CalculateYearlyTaxAtSalaryLessThanSlab2WithSec80CTest test failed. Expected: {expectedTaxWithCess}, but got: {actualTaxWithCess}");
        }

        [TestMethod]
        public void CalculateYearlyTaxAtSalaryLessThanSlab2WithoutSec80CTest() {
            double yearlyPay = 542100;
            double yearlySec80C = 150000;
            double interestOnHousingLoan = 0;
            double professionalTax = 2400.00;
            ITaxDeductions taxDeductions = new TaxDeductions(yearlySec80C, interestOnHousingLoan, professionalTax);
            TaxCalculator taxCalculator = new TaxCalculator(yearlyPay, taxDeductions);
            double expectedTaxWithCess = 0;
            double actualTaxWithCess = taxCalculator.CalculateYearlyTax();
            Assert.AreEqual(expectedTaxWithCess, actualTaxWithCess, $"CalculateYearlyTaxAtSalaryLessThanSlab2WithoutSec80CTest test failed. Expected: {expectedTaxWithCess}, but got: {actualTaxWithCess}");
        }
    }
}
