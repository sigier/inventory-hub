using Inventory_Hub.CoreBusiness;


namespace Inventory_Hub.UseCases.Inventories.Interfaces
{
    public interface IViewInventoryByIdUseCase
    {
        Task<Inventory?> ExecuteAsync(int inventoryId);
    }
}
