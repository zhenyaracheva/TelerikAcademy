namespace StudentGroups
{
    using System;

    public class Group
    {
        private int groupNumber;
        private string departmentName;

        public Group(int initialGroupNumber, string initialDepartmentName)
        {
            this.GroupNumber = initialGroupNumber;
            this.DepartmentName = initialDepartmentName;
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Group cannot be negative or 0.");
                }

                this.groupNumber = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return this.departmentName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Group department cannot be null or empty.");
                }

                this.departmentName = value;
            }
        }

        public override string ToString()
        {
            return this.GroupNumber + " " + this.DepartmentName;
        }
    }
}
