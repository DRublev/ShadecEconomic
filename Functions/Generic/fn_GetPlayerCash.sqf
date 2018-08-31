/*
	Author: Hadwig

	Description:
	Execute GetPlayerCash DLL function. Need to be executed on server (because of server-side-only dll)

	Parameter(s):
	0: STRING - player SteamID

	Returns:
	NUMBER - player cash
*/

params["_uid"];

//_cash = "Economic" callExtension format["[%1]GetPlayerCash", _uid];
_cash = 12345; //For testing purposes. TODO: Remove and write normal call to dll.

//return
_cash