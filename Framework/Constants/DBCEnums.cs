/*
 * Copyright (C) 2012-2013 Arctium <http://arctium.org>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;

namespace Framework.Constants
{
    [Flags]
    public enum FactionMasks
    {
        Player          = 0x0001,   // any player
        Alliance        = 0x0002,   // player or creature from alliance team
        Horde           = 0x0004,   // player or creature from horde team
        Monster         = 0x0008    // aggressive creature from monster team
        // if none flags set then non-aggressive creature
    };

    public enum MapTypes : uint     // Lua_IsInInstance
    {
        Common          = 0,        // none
        Instance        = 1,        // party
        Raid            = 2,        // raid
        Battleground    = 3,        // pvp
        Arena           = 4,        // arena
        Scenario        = 5         // added in 5.0.0
    };

    public enum PowerTypes
    {
        Mana            = 0,
        Rage            = 1,
        Focus           = 2,
        Energy          = 3,
        Unused          = 4,
        Runes           = 5,
        RunicPower      = 6,
        SoulShards      = 7,
        Eclipse         = 8,
        HolyPower       = 9,
        AlternatePower  = 10,
        ElusiveBrew     = 11,       // added in 5.0.0 (used by Monk) - Needs confirmation
        Chi             = 12,       // added in 5.0.0 (used by Monk)
        ShadowOrbs      = 13,       // added in 5.0.0 (used by Priest)
        BurningEmbers   = 14,       // added in 5.0.0 (used by Warlock)
        DemonicFury     = 15,       // added in 5.0.0 (used by Warlock)
        ArcaneCharge    = 16,       // added in 5.0.0 (used by Mage)
        MaxPowers       = 17
    };
}
