// Server initialization

//Player disconnect handler
_EH_HandleDisconnect = addMissionEventHandler ["HandleDisconnect",
{
    _gear = str (getUnitLoadout _unit);
    //"Economic" callExtension format["[%1,%2]SetPlayerSavedInventory", _uid, _inventory];
}];

//Initialize item prices (happens once on server start up, can't change item price on fly) TODO: Check if it is local
[[[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14], [0,1,2,3,4,5,6,7]], "priceStat", ["price"], "Price", [false, true], [{}, {
        params["_stats", "_config"];
        _price = [configName(_config)] call Shadec_fnc_GetItemPrice;
        if (_price isEqualTo 0) then {_price = "No price"};
        _price        
    }, {true}], 99999] call ACE_arsenal_fnc_addStat;