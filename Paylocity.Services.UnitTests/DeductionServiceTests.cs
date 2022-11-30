using Paylocity.Domain.Enums;
using Paylocity.Domain.Implementations;
using Paylocity.Services.Constants;
using Paylocity.Services.Impementations;
using Paylocity.Services.UnitTests.Helpers;

namespace Paylocity.Services.UnitTests
{
    public class DeductionServiceTests
    {
        private Employee _testEmployee { get; set; }
        private DeductionService _deductionService { get; set; }

        public DeductionServiceTests()
        {
            _testEmployee = ServiceTestHelpers.GetEmployee();
            _deductionService = new DeductionService();
        }

        [Fact]
        public void Discount_Rate_Calculator_Test()
        {
            decimal employeeDiscountRate = _deductionService.GetDiscountRate(_testEmployee);
            Assert.Equal(DiscountRates.TEN_PERCENT_DISCOUNT, employeeDiscountRate);

            decimal spouseDiscountRate = _deductionService.GetDiscountRate(_testEmployee.Dependents[0]);
            Assert.Equal(DiscountRates.NO_DISCOUNT, spouseDiscountRate);

            decimal childOneRate = _deductionService.GetDiscountRate(_testEmployee.Dependents[1]);
            Assert.Equal(DiscountRates.TEN_PERCENT_DISCOUNT, childOneRate);

            decimal childTwoRate = _deductionService.GetDiscountRate(_testEmployee.Dependents[2]);
            Assert.Equal(DiscountRates.NO_DISCOUNT, childTwoRate);
        }

        [Fact]
        public void Deduction_Amount_Test()
        {
            decimal employeeDeductionAmount = _deductionService.GetDeductionCost(_testEmployee);
            Assert.Equal(DeductionCosts.EMPLOYEE_COST, employeeDeductionAmount);

            decimal spouseDeductionAmount = _deductionService.GetDeductionCost(_testEmployee.Dependents[0]);
            Assert.Equal(DeductionCosts.SPOUSE_COST, spouseDeductionAmount);

            decimal childOneDeductionAmount = _deductionService.GetDeductionCost(_testEmployee.Dependents[1]);
            Assert.Equal(DeductionCosts.CHILD_COST, childOneDeductionAmount);

            decimal childTwoDeductionAmount = _deductionService.GetDeductionCost(_testEmployee.Dependents[2]);
            Assert.Equal(DeductionCosts.CHILD_COST, childTwoDeductionAmount);
        }

        [Fact]
        public void Monthly_Payperiod_Deduction_Amount_Test()
        {
            // Employee With 10% Discount
            _testEmployee.PayFrequency = PayFrequency.Monthly;
            var deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee, _testEmployee.PayFrequency);
            Assert.Equal(75.00m, deductionAmount);

            // Employee Without 10% Discount
            _testEmployee.Name = "Random Emp";
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee, _testEmployee.PayFrequency);
            Assert.Equal(83.33m, deductionAmount);

            // Dependent Without 10% Discount
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee.Dependents[0], _testEmployee.PayFrequency);
            Assert.Equal(41.67m, deductionAmount);

            // Dependent With 10% Discount
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee.Dependents[1], _testEmployee.PayFrequency);
            Assert.Equal(37.50m, deductionAmount);
        }

        [Fact]
        public void Weekly_Payperiod_Deduction_Amount_Test()
        {
            // Employee With 10% Discount
            _testEmployee.PayFrequency = PayFrequency.Weekly;
            var deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee, _testEmployee.PayFrequency);
            Assert.Equal(17.31m, deductionAmount);

            // Employee Without 10% Discount
            _testEmployee.Name = "Random Emp";
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee, _testEmployee.PayFrequency);
            Assert.Equal(19.23m, deductionAmount);

            // Dependent Without 10% Discount
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee.Dependents[0], _testEmployee.PayFrequency);
            Assert.Equal(9.62m, deductionAmount);

            // Dependent With 10% Discount
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee.Dependents[1], _testEmployee.PayFrequency);
            Assert.Equal(8.65m, deductionAmount);
        }

        [Fact]
        public void BiWeekly_Payperiod_Deduction_Amount_Test()
        {
            // Employee With 10% Discount
            _testEmployee.PayFrequency = PayFrequency.BiWeekly;
            var deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee, _testEmployee.PayFrequency);
            Assert.Equal(34.62m, deductionAmount);

            // Employee Without 10% Discount
            _testEmployee.Name = "Random Emp";
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee, _testEmployee.PayFrequency);
            Assert.Equal(38.46m, deductionAmount);

            // Dependent Without 10% Discount
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee.Dependents[0], _testEmployee.PayFrequency);
            Assert.Equal(19.23m, deductionAmount);

            // Dependent With 10% Discount
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee.Dependents[1], _testEmployee.PayFrequency);
            Assert.Equal(17.31m, deductionAmount);
        }

        [Fact]
        public void Yearly_Payperiod_Deduction_Amount_Test()
        {
            // Employee With 10% Discount
            _testEmployee.PayFrequency = PayFrequency.Yearly;
            var deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee, _testEmployee.PayFrequency);
            Assert.Equal(900.0m, deductionAmount);

            // Employee Without 10% Discount
            _testEmployee.Name = "Random Emp";
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee, _testEmployee.PayFrequency);
            Assert.Equal(1000.0m, deductionAmount);

            // Dependent Without 10% Discount
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee.Dependents[0], _testEmployee.PayFrequency);
            Assert.Equal(500.0m, deductionAmount);

            // Dependent With 10% Discount
            deductionAmount = _deductionService.CalculateDeductionPerPerson(_testEmployee.Dependents[1], _testEmployee.PayFrequency);
            Assert.Equal(450.0m, deductionAmount);
        }
    }
}