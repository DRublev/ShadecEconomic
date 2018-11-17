params ["_player", "_didJIP"];

sleep 5; //Debug only for situation where server = player

//Event handler for arsenal opening. Fires on local mashine when player opens ACE arsenal
_EH_ArsenalOpen = ["ace_arsenal_displayOpened",
{
    params["_arsenal"];
    //Arcenal item prices update
    [[[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14], [0,1,2,3,4,5,6,7]], "priceStat", ["price"], "Price", [false, true], [{}, {
        params["_stats", "_config"];
        _price = missionNamespace getVariable (configName(_config) + "_price");
        if (_price isEqualTo 0) then {_price = "No price"};
        _price        
    }, {true}], 99999] call ACE_arsenal_fnc_addStat;
    //TODO: Show Arsenal HUD
    _display = uiNamespace getVariable ["ArsenalHUD",displayNull];    // Get layer display
    _control = _display displayCtrl 7001;    // Get display control for cash text
    
    //Update info in cash text with new information.
    _cash = missionNamespace getVariable [(getPlayerUID player) + "_cash", "ErrorUp"];
    _control ctrlSetText format["%1 $",_cash];
}] call CBA_fnc_addEventHandler;


//Event handler for arsenal closing. Fires on local machine when player cloases ACE arsenal.
_EH_ArsenalClose = ["ace_arsenal_displayClosed",
{
    // TODO: Hide arsenall HUD
    _display = uiNamespace getVariable ["ArsenalHUD",displayNull];    // Get layer display
    _control = _display displayCtrl 7001;    // Get display control for cash text
}] call CBA_fnc_addEventHandler;

_EH_InventoryOpened = player addEventHandler ["InventoryOpened",
{
    //Player cash HUD update
    _uid = getPlayerUID player;
    _cash = missionNamespace getVariable [_uid + "_cash", "ErrorUp"];
    _display = uiNamespace getVariable ["ArsenalHUD",displayNull];    // Get layer display
    _control = _display displayCtrl 7001;    // Get display control for cash text
    _control ctrlSetText format["%1 $",_cash];     // Update info in cash text with new information.
    
    //Arcenal item prices update
    [[[0,1,2,3,4,5,6,7,8,9,10,11,12,13,14], [0,1,2,3,4,5,6,7]], "priceStat", ["price"], "Price", [false, true], [{}, {
        params["_stats", "_config"];
        _price = missionNamespace getVariable (configName(_config) + "_price");
        if (_price isEqualTo 0) then {_price = "No price"};
        _price        
    }, {true}], 99999] call ACE_arsenal_fnc_addStat;
}];

/*
 Player initialisation
*/

_uid = getPlayerUID player;

//Load player saved loadout
_gear = parseSimpleArray (missionNamespace getVariable [_uid + "_loadout", str(getUnitLoadout "B_Survivor_F")]);
player setUnitLoadout [_gear, false];

_cash = missionNamespace getVariable [_uid + "_cash", "Err"];

_Rsc_layer = ("ArsenalHUD" call BIS_fnc_rscLayer) cutRsc ["ArsenalCaxhTitle", "PLAIN"];    //Create and display new resource layer
_display = uiNamespace getVariable ["ArsenalHUD",displayNull];    // Get layer display
_control = _display displayCtrl 7001;    // Get display control for cash text
_control ctrlSetText format["%1 $",_cash];     // Update info in cash text with new information.