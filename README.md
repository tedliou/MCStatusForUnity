# MCStatus For Unity

This Unity package allows you to easily retrieve real-time status information for both **Minecraft Java Edition** and **Bedrock Edition** servers. It leverages the `mcstatus.io` API to provide comprehensive server data directly within your Unity projects.

-----

## Installation

Before installing `MCStatusForUnity`, you need to install its dependencies using Unity's Package Manager. Ensure you have Git installed on your computer as these packages are installed via Git URL.

### Dependencies

1.  **C-Sharp-Promise**:

      * Open Unity.
      * Go to `Window > Package Manager`.
      * Click the `+` icon in the top-left corner.
      * Select `Add package from git URL...`.
      * Enter the URL: `https://github.com/Real-Serious-Games/C-Sharp-Promise.git`
      * Click `Add`.

2.  **RestClient**:

      * Open Unity.
      * Go to `Window > Package Manager`.
      * Click the `+` icon in the top-left corner.
      * Select `Add package from git URL...`.
      * Enter the URL: `https://github.com/proyecto26/RestClient.git#upm`
      * Click `Add`.

### MCStatusForUnity Package

Once the dependencies are installed, you can install `MCStatusForUnity`:

1.  Open Unity.
2.  Go to `Window > Package Manager`.
3.  Click the `+` icon in the top-left corner.
4.  Select `Add package from git URL...`.
5.  Enter the URL: `https://github.com/tedliou/MCStatusForUnity.git`
6.  Click `Add`.

-----

## Usage

To use the package, ensure you include the `VerveCode` namespace. You can then call the static `GetServerStatus` method from the `MCStatus` class, specifying the server type (`MCStatusJava` or `MCStatusBedrock`) as the generic parameter.

```csharp
using UnityEngine;
using VerveCode; // Important: Include this namespace

public class MyServerStatusChecker : MonoBehaviour
{
    void Start()
    {
        // Get status for a Minecraft Java Edition server
        MCStatus.GetServerStatus<MCStatusJava>(address: "twilightrpg.net", port: 25565, callback: status =>
        {
            Debug.Log($"Java Server MOTD (Clean): {status.Motd.Clean}");
            Debug.Log($"Java Server Online Players: {status.Players.Online}/{status.Players.Max}");
        });

        // Get status for a Minecraft Bedrock Edition server
        MCStatus.GetServerStatus<MCStatusBedrock>(address: "bedrock.mcfallout.net", port: 19132, callback: status =>
        {
            Debug.Log($"Bedrock Server MOTD (Clean): {status.Motd.Clean}");
            Debug.Log($"Bedrock Server Online Players: {status.Players.Online}/{status.Players.Max}");
        });
    }
}
```

-----

## API Reference

The `MCStatusForUnity` package provides a simple static method to query server status and data structures that mirror the `mcstatus.io` API response.

### `MCStatus.GetServerStatus<T>` Method

This is the primary method for fetching server information.

| Parameter | Type | Description |
| :-------- | :--- | :---------- |
| `address` | `string` | The IP address or hostname of the Minecraft server. |
| `port` | `int` | The port of the Minecraft server. For Java, default is `25565`. For Bedrock, default is `19132`. If `0` is passed, the default will be used based on the generic type `T`. |
| `callback` | `UnityAction<T>` | A callback function that will be invoked with the server status object of type `T` upon successful retrieval, or `null` if an error occurs. |
| `T` | `MCStatusJava` or `MCStatusBedrock` | The generic type parameter determining whether to fetch Java or Bedrock server status. |

### Data Structures

The C\# classes provided in this package are designed to directly map to the JSON response structure from the `mcstatus.io` API. For detailed descriptions of each field, please refer to the official `mcstatus.io` API documentation: [https://mcstatus.io/docs](https://mcstatus.io/docs)

#### `MCStatusBase` (Abstract Base Class)

All specific status classes (`MCStatusJava`, `MCStatusBedrock`) inherit from this base class, providing common properties.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Online` | `bool` | `online` | Whether the server is currently online. |
| `Host` | `string` | `host` | The hostname of the server. |
| `Port` | `int` | `port` | The port of the server. |
| `IpAddress` | `string` | `ip_address` | The resolved IP address of the server. |
| `EulaBlocked` | `bool` | `eula_blocked` | Indicates if the server is blocked by Mojang's EULA. |
| `RetrievedAt` | `long` | `retrieved_at` | Unix timestamp when the status was retrieved. |
| `ExpiresAt` | `long` | `expires_at` | Unix timestamp when the cached status expires. |
| `Motd` | `Motd` | `motd` | Message of the Day details. |

#### `Motd`

Contains different formats of the server's Message of the Day.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Raw` | `string` | `raw` | The raw MOTD string, including formatting codes. |
| `Clean` | `string` | `clean` | The MOTD string with all formatting codes removed. |
| `HTML` | `string` | `html` | The MOTD string formatted as HTML. |

#### `MCStatusBedrock`

Specific status details for Minecraft Bedrock Edition servers.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Version` | `VersionBedrock` | `version` | Version information for the Bedrock server. |
| `Players` | `PlayersBedrock` | `players` | Player count information for the Bedrock server. |
| `Gamemode` | `string` | `gamemode` | The current gamemode of the Bedrock server. |
| `ServerId` | `string` | `server_id` | Unique ID of the Bedrock server. |
| `Edition` | `string` | `edition` | The edition of the Minecraft server (e.g., "MCPE"). |

#### `VersionBedrock`

Version details for Bedrock servers.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Name` | `string` | `name` | The display name of the Bedrock version. |
| `Protocol` | `int?` | `protocol` | The protocol version of the Bedrock server. |

#### `PlayersBedrock`

Player count details for Bedrock servers.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Online` | `int?` | `online` | Number of players currently online. |
| `Max` | `int?` | `max` | Maximum number of players allowed. |

#### `MCStatusJava`

Specific status details for Minecraft Java Edition servers.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Version` | `VersionJava` | `version` | Version information for the Java server. |
| `Players` | `PlayersJava` | `players` | Player count information for the Java server. |
| `Icon` | `string` | `icon` | Base64 encoded server icon (if available). |
| `Mods` | `List<ModJava>` | `mods` | List of mods installed on the server (if available). |
| `Software` | `string` | `software` | The server software name (e.g., "Paper", "Spigot"). |
| `Plugins` | `List<PluginJava>` | `plugins` | List of plugins installed on the server (if available). |
| `SrvRecord` | `SrvRecordJava` | `srv_record` | SRV record details if the server uses one. |

#### `VersionJava`

Version details for Java servers.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `NameRaw` | `string` | `name_raw` | Raw version name. |
| `NameClean` | `string` | `name_clean` | Cleaned version name. |
| `NameHTML` | `string` | `name_html` | HTML formatted version name. |
| `Protocol` | `int` | `protocol` | The protocol version of the Java server. |

#### `PlayersJava`

Player count details for Java servers.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Online` | `int` | `online` | Number of players currently online. |
| `Max` | `int` | `max` | Maximum number of players allowed. |
| `List` | `List<PlayerJava>` | `list` | A sample list of online players (not always exhaustive). |

#### `PlayerJava`

Details for an individual player on a Java server.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `UUID` | `string` | `uuid` | The UUID of the player. |
| `NameRaw` | `string` | `name_raw` | Raw player name. |
| `NameClean` | `string` | `name_clean` | Cleaned player name. |
| `NameHTML` | `string` | `name_html` | HTML formatted player name. |

#### `ModJava`

Details for a mod installed on a Java server.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Name` | `string` | `name` | The name of the mod. |
| `Version` | `string` | `version` | The version of the mod. |

#### `PluginJava`

Details for a plugin installed on a Java server.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Name` | `string` | `name` | The name of the plugin. |
| `Version` | `string` | `version` | The version of the plugin. |

#### `SrvRecordJava`

Details for the SRV record of a Java server.

| Property | Type | JSON Field | Description |
| :------- | :--- | :--------- | :---------- |
| `Host` | `string` | `host` | The host specified in the SRV record. |
| `Port` | `int` | `port` | The port specified in the SRV record. |

-----