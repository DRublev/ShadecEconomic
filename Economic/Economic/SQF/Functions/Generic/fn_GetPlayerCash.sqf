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

_cash = "Economic" callExtension format["[%1]GetPlayerCash", _uid];

//return
_cash