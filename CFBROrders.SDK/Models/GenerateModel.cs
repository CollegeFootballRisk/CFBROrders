

namespace CFBROrders.SDK.Models
{
    public partial class AuditLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Event { get; set; }
        public DateTime Timestamp { get; set; }
        public string Data { get; set; }
        public string Cip { get; set; }
        public string Ua { get; set; }
    }

    public partial class AwardInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
    }

    public partial class Awards
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AwardId { get; set; }
        public DateTime? AwardDate { get; set; }
    }

    public partial class Bans
    {
        public int Id { get; set; }
        public int? Class { get; set; }
        public string Cip { get; set; }
        public string Uname { get; set; }
        public string Ua { get; set; }
        public string Reason { get; set; }
    }

    public partial class Captchas
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Creation { get; set; }
    }

    public partial class ContinuationPolls
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int? Incrment { get; set; }
        public int? TurnId { get; set; }
    }

    public partial class ContinuationResponses
    {
        public int Id { get; set; }
        public int? PollId { get; set; }
        public int? UserId { get; set; }
        public bool? Response { get; set; }
    }

    public partial class Heat
    {
        public string Name { get; set; }
        public int? Season { get; set; }
        public int? Day { get; set; }
        public long? CumulativePlayers { get; set; }
        public decimal? CumulativePower { get; set; }
    }

    public partial class HeatFull
    {
        public string Name { get; set; }
        public int? Season { get; set; }
        public int? Day { get; set; }
        public long? CumulativePlayers { get; set; }
        public decimal? CumulativePower { get; set; }
        public string Owner { get; set; }
    }

    public partial class Logs
    {
        public int Id { get; set; }
        public string Route { get; set; }
        public string Query { get; set; }
        public string Payload { get; set; }
        public DateTime? Timestamp { get; set; }
    }

    public partial class Moves
    {
        public int? Season { get; set; }
        public int? Day { get; set; }
        public int? Territory { get; set; }
        public int? UserId { get; set; }
        public int? Team { get; set; }
        public int? Player { get; set; }
        public bool? Mvp { get; set; }
        public string Uname { get; set; }
        public int? Turns { get; set; }
        public int? Mvps { get; set; }
        public string Tname { get; set; }
        public decimal? Power { get; set; }
        public decimal? Weight { get; set; }
        public int? Stars { get; set; }
        public int? CurrentStars { get; set; }
    }

    public partial class Odds
    {
        public int? Ones { get; set; }
        public int? Twos { get; set; }
        public int? Threes { get; set; }
        public int? Fours { get; set; }
        public int? Fives { get; set; }
        public int? Players { get; set; }
        public decimal? Teampower { get; set; }
        public decimal? Territorypower { get; set; }
        public decimal? Chance { get; set; }
        public int? Team { get; set; }
        public int? Season { get; set; }
        public int? Day { get; set; }
        public string TerritoryName { get; set; }
        public string TeamName { get; set; }
        public string Color { get; set; }
        public string SecondaryColor { get; set; }
        public string Tname { get; set; }
        public string PrevOwner { get; set; }
        public string Mvp { get; set; }
    }

    public partial class PastTurns
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? Territory { get; set; }
        public bool? Mvp { get; set; }
        public decimal? Power { get; set; }
        public decimal? Multiplier { get; set; }
        public decimal? Weight { get; set; }
        public int? Stars { get; set; }
        public int? Team { get; set; }
        public int? AltScore { get; set; }
        public bool? Merc { get; set; }
        public int? TurnId { get; set; }
    }

    public partial class Players
    {
        public int? Id { get; set; }
        public string Uname { get; set; }
        public string Platform { get; set; }
        public int? CurrentTeam { get; set; }
        public int? Overall { get; set; }
        public int? Turns { get; set; }
        public int? GameTurns { get; set; }
        public int? Mvps { get; set; }
        public int? Streak { get; set; }
        public int? Awards { get; set; }
        public string Tname { get; set; }
    }

    public partial class RegionOwnership
    {
        public long? OwnerCount { get; set; }
        public string Owners { get; set; }
        public int? Day { get; set; }
        public int? Season { get; set; }
        public int? Region { get; set; }
    }

    public partial class Regions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Submap { get; set; }
    }

    public partial class Rollinfo
    {
        public string Rollstarttime { get; set; }
        public string Rollendtime { get; set; }
        public int? Chaosrerolls { get; set; }
        public int? Chaosweight { get; set; }
        public int? Day { get; set; }
        public int? Season { get; set; }
        public string JsonAgg { get; set; }
    }

    public partial class Statistics
    {
        public int? TurnId { get; set; }
        public int? Season { get; set; }
        public int? Day { get; set; }
        public int? Team { get; set; }
        public int? Rank { get; set; }
        public int? Territorycount { get; set; }
        public int? Playercount { get; set; }
        public int? Merccount { get; set; }
        public decimal? Starpower { get; set; }
        public decimal? Efficiency { get; set; }
        public decimal? Effectivepower { get; set; }
        public int? Ones { get; set; }
        public int? Twos { get; set; }
        public int? Threes { get; set; }
        public int? Fours { get; set; }
        public int? Fives { get; set; }
        public string Tname { get; set; }
        public string Logo { get; set; }
        public long? Regions { get; set; }
    }

    public partial class Stats
    {
        public int? Team { get; set; }
        public int? Rank { get; set; }
        public int? Territorycount { get; set; }
        public int? Playercount { get; set; }
        public int? Merccount { get; set; }
        public decimal? Starpower { get; set; }
        public decimal? Efficiency { get; set; }
        public decimal? Effectivepower { get; set; }
        public int? Ones { get; set; }
        public int? Twos { get; set; }
        public int? Threes { get; set; }
        public int? Fours { get; set; }
        public int? Fives { get; set; }
        public int? TurnId { get; set; }
    }

    public partial class TeamPlayerMoves
    {
        public int? Id { get; set; }
        public int? Season { get; set; }
        public int? Day { get; set; }
        public string Team { get; set; }
        public string Player { get; set; }
        public int? Stars { get; set; }
        public bool? Mvp { get; set; }
        public string Territory { get; set; }
        public string Regularteam { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Power { get; set; }
        public decimal? Multiplier { get; set; }
    }

    public partial class Teams
    {
        public int Id { get; set; }
        public string Tname { get; set; }
        public string Tshortname { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Color1 { get; set; }
        public string Color2 { get; set; }
        public string Logo { get; set; }
        public string Seasons { get; set; }
        public int RespawnCount { get; set; }
    }

    public partial class Territories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Region { get; set; }
    }

    public partial class TerritoryAdjacency
    {
        public int? Id { get; set; }
        public int? TerritoryId { get; set; }
        public int? AdjacentId { get; set; }
        public string Note { get; set; }
        public int? MinTurn { get; set; }
        public int? MaxTurn { get; set; }
    }

    public partial class TerritoryNeighborHistory
    {
        public int? TurnId { get; set; }
        public int? Id { get; set; }
        public string Neighbors { get; set; }
    }

    public partial class TerritoryOwnership
    {
        public int Id { get; set; }
        public int? TerritoryId { get; set; }
        public int? OwnerId { get; set; }
        public int? PreviousOwnerId { get; set; }
        public decimal? RandomNumber { get; set; }
        public DateTime? Timestamp { get; set; }
        public int? Mvp { get; set; }
        public int? TurnId { get; set; }
        public bool IsRespawn { get; set; }
    }

    public partial class TerritoryOwnershipWithNeighbors
    {
        public int? TerritoryId { get; set; }
        public int? Day { get; set; }
        public int? Season { get; set; }
        public string Name { get; set; }
        public string Tname { get; set; }
        public int? Region { get; set; }
        public string RegionName { get; set; }
        public string Neighbors { get; set; }
    }

    public partial class TerritoryOwnershipWithoutNeighbors
    {
        public int? TerritoryId { get; set; }
        public int? Day { get; set; }
        public int? Season { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string PrevOwner { get; set; }
        public DateTime? Timestamp { get; set; }
        public decimal? RandomNumber { get; set; }
        public string Mvp { get; set; }
    }

    public partial class TerritoryStats
    {
        public int? Team { get; set; }
        public int? Ones { get; set; }
        public int? Twos { get; set; }
        public int? Threes { get; set; }
        public int? Fours { get; set; }
        public int? Fives { get; set; }
        public decimal? Teampower { get; set; }
        public decimal? Chance { get; set; }
        public int Id { get; set; }
        public int? Territory { get; set; }
        public decimal? TerritoryPower { get; set; }
        public int? TurnId { get; set; }
    }

    public partial class Turninfo
    {
        public int Id { get; set; }
        public int? Season { get; set; }
        public int? Day { get; set; }
        public bool? Complete { get; set; }
        public bool? Active { get; set; }
        public bool? Finale { get; set; }
        public int? Chaosrerolls { get; set; }
        public int? Chaosweight { get; set; }
        public DateTime? Rollendtime { get; set; }
        public DateTime? Rollstarttime { get; set; }
        public bool? Allornothingenabled { get; set; }
        public string Map { get; set; }
    }

    public partial class Turns
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? Territory { get; set; }
        public bool Mvp { get; set; }
        public decimal? Power { get; set; }
        public decimal? Multiplier { get; set; }
        public decimal? Weight { get; set; }
        public int? Stars { get; set; }
        public int? Team { get; set; }
        public int? AltScore { get; set; }
        public bool? Merc { get; set; }
        public int? TurnId { get; set; }
    }

    public partial class Users
    {
        public int Id { get; set; }
        public string Uname { get; set; }
        public string Platform { get; set; }
        public DateTime? JoinDate { get; set; }
        public int CurrentTeam { get; set; }
        public string AuthKey { get; set; }
        public int? Overall { get; set; }
        public int? Turns { get; set; }
        public int? GameTurns { get; set; }
        public int? Mvps { get; set; }
        public int? Streak { get; set; }
        public int? Awards { get; set; }
        public int? RoleId { get; set; }
        public int? PlayingFor { get; set; }
        public string PastTeams { get; set; }
        public int? AwardsBak { get; set; }
        public long? DiscordId { get; set; }
        public bool? IsAlt { get; set; }
        public bool? MustCaptcha { get; set; }
    }

}
