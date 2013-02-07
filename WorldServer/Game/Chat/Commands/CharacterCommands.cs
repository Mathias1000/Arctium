using WorldServer.Game.WorldEntities;
using WorldServer.Network;
using Framework.Constants;
using Framework.Network.Packets;
using WorldServer.Game.Managers;
using Framework.Console;

namespace WorldServer.Game.Chat.Commands
{
    public class CharacterCommands
    {
        [ChatCommand("Level")]
        public static void LevelUP(string[] args, ref WorldClass session)
        {
            int Level = CommandParser.Read<int>(args, 1);

            session.Character.LevelUP(Level);
        }
    }
}
