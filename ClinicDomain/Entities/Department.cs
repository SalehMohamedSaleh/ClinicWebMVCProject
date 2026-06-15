using ClinicDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Entities
{
    public class Department : ISoftDelete
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private readonly HashSet<Doctor> _doctors = new();
        public IReadOnlyCollection<Doctor> Doctors => _doctors;

        public bool IsDeleted { get; private set; }

        public Department(string name)
        {
            Name = string.IsNullOrWhiteSpace(name) ? throw new ArgumentException("اسم القسم مطلوب") : name;
        }

        public void AddDoctor(Doctor doctor) => _doctors.Add(doctor);

        public void Delete()
        {
            if (IsDeleted) throw new InvalidOperationException("القسم محذوف بالفعل.");
            IsDeleted = true;
        }

        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("اسم القسم لا يمكن أن يكون فارغاً.");

            Name = newName;
        }
    }
}
