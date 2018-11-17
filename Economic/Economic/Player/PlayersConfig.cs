using Economic.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Economic.Player
{
	public static class PlayersConfig
	{
		public const int DefaultBalance = 5000;
		public static readonly string DefaultInventory = "[]";		
		
		public enum Classes
		{
			Pussy,
			Machinegunner,
			Medic,
			Grenadier,
			Rifleman,
			BlastSpecialist,
			Spotter,
			Marksman,
			Sniper,
			AmmoCarrier,
			Engineer
		}

		public static Hashtable Discounts = new Hashtable()
		{
			{ new ItemDiscount() { Item = "CUP_arifle_MG36", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "CUP_arifle_MG36_camo", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_pkm", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_pkp", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m240B", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m240B_CAP", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m240G", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m249", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m249_pip_L", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m249_pip_L_para", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m249_pip_L_vfg", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m249_pip_S", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m249_pip_S_para", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m249_pip_S_vfg", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m249_pip", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_pkm", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_pkp", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_m84", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "rhs_weap_minimi_para_railed", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "UK3CB_BAF_L103A2", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "UK3CB_BAF_L110A1", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "UK3CB_BAF_L110A2", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "UK3CB_BAF_L110A2RIS", Discount = 50 }, Classes.Machinegunner },
			{ new ItemDiscount() { Item = "UK3CB_BAF_L110A3", Discount = 50 }, Classes.Machinegunner }
		};

		public static Hashtable BlacklistedItems = new Hashtable()
		{
			{ Classes.Machinegunner, "" }
		};
	}
}