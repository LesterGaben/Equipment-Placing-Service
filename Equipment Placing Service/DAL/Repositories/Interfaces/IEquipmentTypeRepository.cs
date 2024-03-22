using Equipment_Placing_Service.DAL.Entities;

namespace Equipment_Placing_Service.DAL.Repositories.Interfaces {
    public interface IEquipmentTypeRepository : IQueryable {
        public Task<EquipmentType> GetByCodeAsync(string code);
        public Task<EquipmentType> GetByIdAsync(int id);
        public Task<List<EquipmentType>> GetAllAsync();
        public Task AddAsync(EquipmentType equipmentType);
        public Task UpdateAsync(EquipmentType equipmentType);
        public Task DeleteAsync(EquipmentType equipmentType);
        public Task DeleteAllAsync();
    }
}
