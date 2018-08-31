/*
	Author: Hadwig

	Description:
	Execute NewGearPrice DLL function. Need to be executed on server (because of server-side-only dll)

	Parameter(s):
	0: ARRAY - player old loadout in getUnitLoadout/setUnitLoadout format
    1: ARRAY - player new loadout in getUnitLoadout/setUnitLoadout format

	Returns:
	NUMBER - price of loadout change
*/

params["_oldgear", "_newgear"];

//_price = "Economic" callExtension format["[%1,%2]NewGearPrice", _oldgear, _newgear];
_price = 1234; //For testing purposes. TODO: Remove and write normal call to dll.

//Return
_price