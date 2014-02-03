namespace SpecsFor.SpecFlow.Demo.Domain
{
	public interface IInventory
	{
		bool IsQuantityAvailable(string partNumber, int quantity);
	}
}