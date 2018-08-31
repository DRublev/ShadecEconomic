//Player initialization (client-side)

params ["_player", "_didJIP"];


//Event handler for arsenal opening. Fires on local mashine when player opens ACE arsenal
_EH_ArsenalOpen = ["ace_arsenal_displayOpened",
{
    _uid = getPlayerUID player;
    _return = 12345; //"Economic" callExtension format["[%1]GetPlayerCash", _uid];
    if true then   //Error checks
    {
        _Rsc_layer = ("ArsenalHUD" call BIS_fnc_rscLayer) cutRsc ["ArsenalCaxhTitle", "PLAIN"];    //Create and display new resource layer
        _display = uiNamespace getVariable ["ArsenalHUD",displayNull];    // Get layer display
        _control = _display displayCtrl 7001;    // Get display control for cash text
        _control ctrlSetText format["%1 $",_return];     // Update info in cash text with new information.
    } else {
        hint "Data recieve error!";
    };
}] call CBA_fnc_addEventHandler;


//Event handler for arsenal closing. Fires on local machine when player cloases ACE arsenal.
_EH_ArsenalClose = ["ace_arsenal_displayClosed",
{
    _Rsc_layer = "ArsenalHUD" cutRsc ["Clear", "PLAIN"];  //Switch drawed HUD to clear layer. In Arma HUD hiding looks like this.
}] call CBA_fnc_addEventHandler;

//Load player saved loadout
_gear = getUnitLoadout player;  //"Economic" callExtension "GetPlayerSavedInventory";
player setUnitLoadout [_gear, false]