using System.Collections.Generic;
using UnityEngine;

namespace TCS.UnityUtils.Tests {
    public record PlayerData(string Name, int Score);

    public class RecordLoggerTesting : MonoBehaviour {
        void Start() {
            // Instantiate PlayerData records
            var player1 = new PlayerData("Alice", 100);
            var player2 = new PlayerData("Bob", 120);
            var player3 = new PlayerData("Charlie", 90);

            // Display each player’s information in a formatted color
            RecordLogger.Log("Logging Player Data:");
            RecordLogger.Log(player1.ToString().green());
            RecordLogger.Log(player2.ToString().blue());
            RecordLogger.Log(player3.ToString().orange());

            // Log a warning if a player has a high score
            if (player2.Score > 110) {
                RecordLogger.LogWarning("High score alert for", player2.Name.yellow());
            }

            // Comparing players for equality and logging the result
            var areEqual = player1 == player2;
            RecordLogger.Log("Are player1 and player2 equal?".pink(), areEqual.ToString().green());

            // Use a list to log multiple players
            List<PlayerData> players = new() { player1, player2, player3 };
            RecordLogger.Log("Player List:");
            RecordLogger.Log(players.AsString());
        }
    }
}