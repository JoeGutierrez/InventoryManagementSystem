using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
	public class Inventory
	{
		public int InventoryId { get; set; }

		[ Required ]
		[ StringLength( 150 ) ]
		public string InventoryName { get; set; } = string.Empty; // Added: 06/29/2024. Source: https://www.udemy.com/course/learn-blazor-while-creating-an-inventory-management-system/learn/lecture/44266804 @ 3:39.

		[ Range( 0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0." ) ]
		public int Quantity { get; set; }

		[ Range( 0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0." ) ]
		public double Price { get; set; }
	}
}
