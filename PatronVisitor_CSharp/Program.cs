using System;
using System.Collections.Generic;
using System.Globalization;
namespace Earning_TaxationInIndiaWithVisitorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee
            {
                EmployeeId = "20197623",
                EmployeeName = "Rubens Antonio Martinez Mora"
            };
            AddDataForEmployee(emp);
            var netAnnualEarningVisitor = new NetAnnualEarningVisitor();
            var annualTaxableAmount = new TaxableAmountVisitor();
            emp.Accept(netAnnualEarningVisitor);
            emp.Accept(annualTaxableAmount);
            Console.WriteLine("Annual Net Earning Amount : {0}", netAnnualEarningVisitor.NetEarningoftheYear);
            Console.WriteLine("Annual Taxable Amount : {0}", annualTaxableAmount.TaxableAmount);
            Console.ReadKey();
        }
        private static void AddDataForEmployee(Employee emp)
        {
            for (int i = 1; i <= 12; i++)
            {
                emp.Salaries.Add(new MonthlySalary_Earning
                {
                    MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                    BasicSalary = 120000,
                    HRAExemption = 50000,
                    ConveyanceAllowance = 1600,
                    PersonalAllowance = 45000,
                    MedicalAllowance = 1500,
                    TelephoneBill = 2500,
                    FoodCard_Bill = 3000,
                    OtherBills = 35000
                });
                emp.Salaries.Add(new MonthlySalary_Deduction
                {
                    MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(i),
                    ProvidentFund_EmployeeContribution = 8000,
                    ProvidentFund_EmployerContribution = 8000,
                    OtherDeduction = 700,
                    ProfessionTax = 200,
                    TDS = 15000
                });
                emp.Salaries.Add(new MonthlyExpense
                {
                    MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(1),
                    MonthlyRent = 10000
                });
            }
            emp.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "MediclaimPolicy",
                InvestmentAmmount = 15000
            });
            emp.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "MediclaimPolicyforParents",
                InvestmentAmmount = 25000
            });
            emp.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "HouseLoan",
                InvestmentAmmount = 0.0
            });
            emp.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "EducationLoan",
                InvestmentAmmount = 0.0
            });
            emp.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "OtherInvestment",
                InvestmentAmmount = 5000
            });
            emp.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "RGESS",
                InvestmentAmmount = 5500
            });
            emp.Salaries.Add(new AnnualInvestment
            {
                InvestmentDetails = "Section80Cn80CCD_ExceptPF",
                InvestmentAmmount = 100000
            });
        }
    }
    public class NetAnnualEarningVisitor : IVisitor
    {
        public double NetEarningoftheYear
        {
            get;
            set;
        }
        public void Visit(MonthlySalary_Earning monthlySalary_Earning)
        {
            NetEarningoftheYear += (monthlySalary_Earning.BasicSalary + monthlySalary_Earning.ConveyanceAllowance + monthlySalary_Earning.FoodCard_Bill + monthlySalary_Earning.HRAExemption + monthlySalary_Earning.MedicalAllowance + monthlySalary_Earning.OtherBills + monthlySalary_Earning.PersonalAllowance + monthlySalary_Earning.TelephoneBill);
        }
        public void Visit(MonthlySalary_Deduction monthlySalary_Deduction)
        {
            NetEarningoftheYear -= (monthlySalary_Deduction.ProvidentFund_EmployeeContribution + monthlySalary_Deduction.ProvidentFund_EmployerContribution + monthlySalary_Deduction.ProfessionTax + monthlySalary_Deduction.OtherDeduction);
        }
        public void Visit(AnnualInvestment annualInvestment)
        {
            // do nothing  
        }
        public void Visit(MonthlyExpense monthlyExpense)
        {
            //do nothing  
        }
    }
    public class TaxableAmountVisitor : IVisitor
    {
        public double TaxableAmount
        {
            get;
            set;
        }
        public void Visit(MonthlySalary_Earning monthlySalary_Earning)
        {
            TaxableAmount += (monthlySalary_Earning.BasicSalary + monthlySalary_Earning.HRAExemption + monthlySalary_Earning.MedicalAllowance + monthlySalary_Earning.PersonalAllowance);
        }
        public void Visit(MonthlySalary_Deduction monthlySalary_Deduction)
        {
            TaxableAmount -= (monthlySalary_Deduction.ProvidentFund_EmployeeContribution + monthlySalary_Deduction.ProvidentFund_EmployerContribution + monthlySalary_Deduction.ProfessionTax + monthlySalary_Deduction.OtherDeduction);
        }
        public void Visit(MonthlyExpense monthlyExpense)
        {
            TaxableAmount -= monthlyExpense.MonthlyRent;
        }
        public void Visit(AnnualInvestment annualInvestment)
        {
            TaxableAmount -= annualInvestment.InvestmentAmmount;
        }
    }
    public interface ISalary
    {
        void Accept(IVisitor visitor);
    }
    public interface IVisitor
    {
        void Visit(MonthlySalary_Earning monthlySalary_Earning);
        void Visit(MonthlySalary_Deduction monthlySalary_Deduction);
        void Visit(MonthlyExpense monthlyExpense);
        void Visit(AnnualInvestment annualInvestment);
    }
}

namespace Earning_TaxationInIndiaWithVisitorPattern
{
    #region Employee
    public class Employee : ISalary
    {
        public string EmployeeId
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public List<ISalary> Salaries = new List<ISalary>();
        public void Accept(IVisitor visitor)
        {
            foreach (var salary in Salaries)
            {
                salary.Accept(visitor);
            }
        }
    }
    #endregion
    #region MonthlySalary_Earning  
}

namespace Earning_TaxationInIndiaWithVisitorPattern
{
    public class MonthlySalary_Earning : ISalary
    {
        public string MonthName
        {
            get;
            set;
        }
        public double BasicSalary
        {
            get;
            set;
        }
        public double HRAExemption
        {
            get;
            set;
        }
        public double ConveyanceAllowance
        {
            get;
            set;
        }
        public double PersonalAllowance
        {
            get;
            set;
        }
        public double MedicalAllowance
        {
            get;
            set;
        }
        public double TelephoneBill
        {
            get;
            set;
        }
        public double FoodCard_Bill
        {
            get;
            set;
        }
        public double OtherBills
        {
            get;
            set;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    #endregion
    #region MonthlySalary_Deduction  
    public class MonthlySalary_Deduction : ISalary
    {
        public string MonthName
        {
            get;
            set;
        }
        public double ProvidentFund_EmployeeContribution
        {
            get;
            set;
        }
        public double ProvidentFund_EmployerContribution
        {
            get;
            set;
        }
        public double ProfessionTax
        {
            get;
            set;
        }
        public double TDS
        {
            get;
            set;
        }
        public double OtherDeduction
        {
            get;
            set;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    #endregion
    #region AnnualInvestment  
    public class AnnualInvestment : ISalary
    {
        public string InvestmentDetails
        {
            get;
            set;
        }
        public double InvestmentAmmount
        {
            get;
            set;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    #endregion
    #region MonthlyExpense  
    public class MonthlyExpense : ISalary
    {
        public string MonthName
        {
            get;
            set;
        }
        public double MonthlyRent
        {
            get;
            set;
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
#endregion
