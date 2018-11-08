/*
	Author: Hadwig

	Description:
	Execute GetItemPrice DLL function. Need to be executed on server (because of server-side-only dll)

	Parameter(s):
	0: STRING - item class name

	Returns:
	NUMBER - price of item
*/

params["_item"];

_price = "Economic" callExtension format["[%1]GetItemPrice", _item];
missionNamespace setVariable [_item + "_price", _price, true];
publicVariable (_item + "_price");

//Return
_price