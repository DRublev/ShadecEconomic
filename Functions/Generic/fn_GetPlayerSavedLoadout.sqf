/*
	Author: Hadwig

	Description:
	Execute GetPlayerSavedLoadout DLL function. Need to be executed on server (because of server-side-only dll)

	Parameter(s):
	0: STRING - player SteamID

	Returns:
	STRING - player saved loadout in getUnitLoadout/setUnitLoadout format
*/

params["_uid"];

_gear = "Economic" callExtension format["[%1]GetPlayerSavedLoadout", _uid];
if (_gear isEqualTo "2") then
{
    _gear = str (getUnitLoadout "B_Survivor_F");
};

//Return
_gear