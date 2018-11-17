using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Economic;
using Economic.Player;

namespace EconomicTests
{
	[TestClass]
	public class InventoryManagerTests
	{
		InventoryManager inventoryManager = new InventoryManager();
		string steamId = "129";
		string loadout = "[[\"arifle_MX_GL_F\", \"muzzle_snds_H\", \"acc_pointer_IR\", \"optic_Aco\", [\"30Rnd_65x39_caseless_mag\", 30], [\"1Rnd_HE_Grenade_shell\", 1], \"\"],[],[\"hgun_P07_F\", \"\", \"\", \"\", [\"16Rnd_9x21_Mag\",16],[],\"\"],[\"U_B_CombatUniform_mcam\",[[\"FirstAidKit\",1],[\"30Rnd_65x39_caseless_mag\",30,2],]],[\"V_PlateCarrierGL_rgr\",[[\"30Rnd_65x39_caseless_mag\",30,3]]],[],\"H_HelmetSpecB_blk\",\"G_Tactical_Clear\",[\"Binocular\",\"\",\"\",\"\",[],[],\"\"],,[\"ItemMap\",\"Item\",\"ItemRadio\",\"ItemCompass\",\"ItemWatch\",\"NVGoggles\"]]";

		[TestMethod]
		public void GetPlayerSavedLoadoutTest()
		{
			string actual = inventoryManager.GetPlayerSavedLoadout(steamId);
			actual = actual.Replace('\\', new char());

			Assert.IsTrue(loadout == actual);
		}

		[TestMethod]
		public void SetPlayerSavedLoadoutTest()
		{
			inventoryManager.SetPlayerSavedInventory(steamId, loadout);

			string loadoutAfterSet = inventoryManager.GetPlayerSavedLoadout(steamId)
				.Replace('\\', new char());

			Assert.IsTrue(loadout == loadoutAfterSet);
		}

		[TestMethod]
		public void NewGearCostTest()
		{
			string newLoadout = "[ItemGPS, [ItemGPS]]";
			int expectedCost = 200;

			int actualCost = inventoryManager.NewGearCost("", newLoadout, "129");

			Assert.IsTrue(expectedCost == actualCost);
		}
	}
}
