namespace PayrollLibrary
{
    public class HourlyEmployee : Employee
    {
        private double _HourlyRate;
        private double _HoursWorked;

        /// <summary>
        /// Gets or sets the hourly rate for the employee.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the hourly rate is negative.</exception>
        /// <value>The hourly rate.</value>
        /// <example>
        /// <code>
        /// var employee = new HourlyEmployee();
        /// employee.HourlyRate = 10;
        /// </code>
        /// </example>
        public double HourlyRate
        {
            get { return _HourlyRate; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hourly rate cannot be negative.", nameof(value));
                }
                _HourlyRate = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of hours worked by the employee.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the hours worked is negative.</exception>
        public double HoursWorked
        {
            get { return _HoursWorked; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hours worked cannot be negative.", nameof(value));
                }
                _HoursWorked = value;
            }
        }

        public HourlyEmployee(int? id, int? reportsTo, string? name, string? email, string? mobile, int? departmentId, double hourlyRate = 0, double hoursWorked = 0)
            : base(id, reportsTo, name, email, mobile, departmentId)
        {
            _HourlyRate = hourlyRate;
            _HoursWorked = hoursWorked;
        }

        // Add a default constructor
        public HourlyEmployee() : base(null, null, null, null, null, null) { }

        public override double Payment { get { return _HourlyRate * _HoursWorked; } }

        // override the EmployeeDetails property
        /// <summary>
        /// Gets the details of the hourly employee, including the base employee details, hourly rate, and hours worked.
        /// </summary>
        public override string EmployeeDetails
        {
            get
            {
                return base.EmployeeDetails + $", Hourly Rate: {_HourlyRate}, Hours Worked: {_HoursWorked}";
            }
        }
    }
}
