# Paylocity Coding Challenge

## Business Need
One of the critical functions that we provide for our clients is the ability to pay for their employees’
benefits packages. A portion of these costs are deducted from their paycheck, and we handle that
deduction. Please demonstrate how you would code the following scenario:

* The cost of benefits is $1000/year for each employee
* Each dependent (children and possibly spouses) incurs a cost of $500/year
* Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent

Because this calculation will be needed in multiple places (multiple web applications, mobile devices,
etc...) we will need a well-designed domain API to serve this data in a scalable fashion. Employees may
use one or more devices to choose their benefits package as part of a multi-step process that involves
inputting dependents and need a preview of the costs, and administrators need to preview payroll
before it is run to double check the numbers. The costs may change in between, so the calculation
needs to reflect the current state of the calculation, rather than the state at the time the employee
entered it.

This is of course a contrived example. We want to know how you would design the API and backing data
store, and then implement the class structure and calculations.

You can make the following assumptions:
* All employees are paid $2000 per paycheck before deductions
* There are 26 paychecks in a year
