namespace School
{
    using System;

    public class School
    {
        private const int MinStudentSchoolId = 10000;
        private const int MaxStudentSchoolId = 99999;

        private int currentId = MinStudentSchoolId - 1;

        private int currentStudentSchoolId;

        public School()
        {
            this.currentStudentSchoolId = this.GetStudentSchoolId();
        }

        public int GetStudentSchoolId()
        {
            if (this.currentId > School.MaxStudentSchoolId)
            {
                throw new ArgumentOutOfRangeException("Student school id cannot be bigger than " + School.MaxStudentSchoolId);
            }

            return this.currentId++;
        }
    }
}
