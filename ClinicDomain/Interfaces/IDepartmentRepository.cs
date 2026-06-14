using ClinicDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDomain.Interfaces
{
    public interface IDepartmentRepository
    {
        // جلب قسم محدد مع قائمة الأطباء التابعين له
        Task<Department?> GetByIdAsync(int id);

        // إضافة قسم جديد
        Task AddAsync(Department department);

        // جلب كافة الأقسام (مفيدة لقوائم الاختيار في واجهة المستخدم)
        Task<IEnumerable<Department>> GetAllAsync();
    }
}
