namespace Contracts.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Person
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
    }
}