using System.Linq;
using Network;

namespace Oxide.Plugins 
{
    [Info("NoSteamHydra", "Hydra Host", "1.0.2")]
    [Description("NoSteamFix")]
    class NoSteamHydra : RustPlugin
    {
        
        void OnServerInitialized()
        {
			Server.Command("secure 0");
			Server.Command("encryption 0");
		}

        void OnClientAuth(Connection connection)
        {
            Server.Command("secure 0");
            Server.Command("encryption 0");

                
            NextTick(() =>
            {
                if (BasePlayer.FindByID(connection.userid) != null)
                    BasePlayer.FindByID(connection.userid).OnDisconnected();
                    
                if (ConnectionAuth.m_AuthConnection.Any((Connection item) => item.userid == connection.userid))
                    ConnectionAuth.m_AuthConnection.Remove(connection);
            });
        }
    }
}