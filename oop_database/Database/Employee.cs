using System;

namespace Lab
{
    enum JobType
    {
        SA_MAN,
        SA_REP,
        SA_CLERK,
        ST_MAN,
        ST_CLERK,
        SH_MAN,
        SH_CLERK,
        UNKNOWN
    }

    public class Employee
    {
        private uint iD = 0;
        public string ID
        {
            get { return iD.ToString(); }
            set
            {
                if (!uint.TryParse(value, out iD))
                    throw new Exception("The ID value must be a uint!");
            }
        }

        private string lastName = string.Empty;
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.ToLower().IndexOf(Database.SEPARATOR) != -1)
                    throw new Exception("The LastName value must not contain a " +
                        $"({Database.SEPARATOR}) character!");
                lastName = value;
            }
        }

        private string eMail = "@";
        public string Mail
        {
            get { return eMail; }
            set
            {
                var Address = new System.Net.Mail.MailAddress(value);
                if (Address.Address == value)
                    eMail = value;
                else
                    throw new Exception("The Mail string must be an email address!");
            }
        }
        private JobType jobID = JobType.UNKNOWN;
        public string Job
        {
            get { return Enum.GetName(typeof(JobType), jobID); }
            set
            {
                if (!Enum.TryParse(value, out jobID))
                    throw new Exception("The Job value must be a JobID type!");
            }
        }

        private DateTime hireDate = new DateTime();
        public string HireDate
        {
            get { return hireDate.ToShortDateString(); }
            set
            {
                if (!DateTime.TryParseExact(value, "dd'.'MM'.'yyyy",
                       System.Globalization.CultureInfo.InvariantCulture,
                       System.Globalization.DateTimeStyles.None,
                       out hireDate))
                    throw new Exception("The HireDate value must be a DateTime object!");
            }
        }

        public Employee(string iD, string lastName, string mail, string job, string hireDate)
        {
            ID = iD;
            LastName = lastName;
            Mail = mail;
            Job = job;
            HireDate = hireDate;
        }

        public Employee()
        {
            // Nothing . . .
        }

        public Employee(Employee another)
        {
            ID = another.ID;
            LastName = another.LastName;
            Mail = another.Mail;
            Job = another.Job;
            HireDate = another.HireDate;
        }

        public override string ToString()
        {
            return $"{ID}, {LastName}, {Mail}, {Job}, {HireDate}";
        }

        public override int GetHashCode()
        {
            var hashCode = 3301;
            hashCode = (hashCode * 2017) ^ ID.GetHashCode();
            hashCode = (hashCode * 2017) ^ LastName.GetHashCode();
            hashCode = (hashCode * 2017) ^ Mail.GetHashCode();
            hashCode = (hashCode * 2017) ^ Job.GetHashCode();
            hashCode = (hashCode * 2017) ^ HireDate.GetHashCode();
            return hashCode;
        }
    }
}
