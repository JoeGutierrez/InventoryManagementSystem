﻿using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
	public class Product
	{
		public int ProductId { get; set; }

		[ Required ]
		[ StringLength( 150 ) ]
		public string ProductName { get; set; } = string.Empty; // Added: 06/29/2024. Source: https://www.udemy.com/course/learn-blazor-while-creating-an-Product-management-system/learn/lecture/44266804 @ 3:39.

		[ Range( 0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0." ) ]
		public int Quantity { get; set; }

		[ Range( 0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0." ) ]
		public double Price { get; set; }

		public List<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();

		public void AddInventory( Inventory inventory )
		{
			if( !this.ProductInventories.Any(
				x => x.Inventory is not null &&
				x.Inventory.InventoryName.Equals( inventory.InventoryName )))
			{
				this.ProductInventories.Add( new ProductInventory
				{
					InventoryId = inventory.InventoryId,
					Inventory = inventory,
					InventoryQuantity = 1,
					ProductId = this.ProductId,
					Product = this
				});
			}
		}

		public void RemoveInventory( ProductInventory productInventory )
		{
			this.ProductInventories?.Remove( productInventory );
		}
	}
}
