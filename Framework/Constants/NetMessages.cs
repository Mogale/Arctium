﻿/*
 * Copyright (C) 2012 Arctium <http://>
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
    public enum JAMCCMessage : uint
    {
        AuthChallenge                            = 0xCAF,
        SuspendComms                             = 0x82A,
        ResumeComms                              = 0xE2B,
        DropNewConnection                        = 0xC2F,
        ConnectTo                                = 0x82B,
        Pong                                     = 0x8AE,
        ResetCompressionContext                  = 0xE2F,
        FloodDetected                            = 0xA2A
    }

    [Flags]
    public enum JAMCMessage : uint
    {
        AuthResponse                             = 0xA15,
        WaitQueueUpdate                          = 0xE7C,
        WaitQueueFinish                          = 0x1F8,
        AllAchievementData                       = 0x618,
        AllAccountCriteria                       = 0x5D4,
        RespondInspectAchievements               = 0x7B8,
        AllGuildAchievements                     = 0x9F5,
        SetupCurrency                            = 0x4D0,
        SetCurrency                              = 0x918,
        ResetWeeklyCurrency                      = 0x911,
        GuildSendGuildXP                         = 0xC10,
        GuildSendMaxDailyXP                      = 0x510,
        MessageBox                               = 0x8D1,
        WardenData                               = 0x6BD,
        PhaseShiftChange                         = 0x5F4,
        InitialSetup                             = 0x675,
        DailyQuestsReset                         = 0x331,
        SetQuestCompletedBit                     = 0xE7D,
        ClearQuestCompletedBit                   = 0x430,
        ClearQuestCompletedBits                  = 0xB95,
        AuraPointsDepleted                       = 0x095,
        GuildSendRankChange                      = 0x3B0,
        ReforgeResult                            = 0x95D,
        TradeUpdated                             = 0x2BD,
        TradeStatus                              = 0x5B1,
        EnumCharactersResult                     = 0x33D,
        GenerateRandomCharacterNameResult        = 0xB74,
        GuildCommandResult                       = 0x9FC,
        GuildRoster                              = 0xA75,
        GuildRosterUpdate                        = 0x270,
        CurrencyLootRemoved                      = 0xF1D,
        GuildMemberRecipes                       = 0x1B4,
        GuildKnownRecipes                        = 0x4FC,
        GuildMembersWithRecipe                   = 0x411,
        SetupResearchHistory                     = 0xD7C,
        ResearchComplete                         = 0xF99,
        PetSlotUpdated                           = 0xA5D,
        DifferentInstanceFromParty               = 0xD91,
        UpdateServerPlayerPosition               = 0x71C,
        CategoryCooldown                         = 0xDD9,
        RoleChangedInform                        = 0xE70,
        GuildRewardList                          = 0x55D,
        RolePollInform                           = 0xF15,
        SummonRaidMemberValidateFailed           = 0xC31,
        BattlefieldStatus_NeedConfirmation       = 0xF51,
        BattlefieldStatus_Active                 = 0x23C,
        BattlefieldStatus_Queued                 = 0x8F9,
        BattlefieldStatus_None                   = 0x49C,
        BattlefieldStatus_Failed                 = 0x6B4,
        BattlefieldList                          = 0x530,
        BattlegroundPlayerPositions              = 0x734,
        BattlegroundPlayerJoined                 = 0x0DC,
        BattlegroundPlayerLeft                   = 0x1FD,
        BattlefieldPortDenied                    = 0x01D,
        BFMgrEntryInvite                         = 0xC3D,
        BFMgrEntering                            = 0xEB5,
        BFMgrQueueRequestResponse                = 0xF35,
        BFMgrEjectPending                        = 0xE54,
        BFMgrEjected                             = 0x7F1,
        BFMgrQueueInvite                         = 0xC1D,
        BFMgrExitRequest                         = 0xE78,
        BFMgrStateChanged                        = 0xC75,
        BattlegroundInfoThrottled                = 0x315,
        QuestCompletionNPCResponse               = 0xC9C,
        RequestCemeteryListResponse              = 0x075,
        SetForgeMaster                           = 0xB39,
        CheckWargameEntry                        = 0xA58,
        ShowRatings                              = 0xAD0,
        DBReply                                  = 0x59C,
        HotfixNotify                             = 0x5B0,
        HotfixNotifyBlob                         = 0x9B5,
        BattlefieldStatus_WaitForGroups          = 0x2B0,
        GuildNews                                = 0x7D0,
        GuildNewsDeleted                         = 0xF7C,
        RatedBattlefieldInfo                     = 0x1FC,
        AverageItemLevelInform                   = 0x31D,
        GuildCriteriaUpdate                      = 0x799,
        GuildAchievementEarned                   = 0x474,
        GuildAchievementDeleted                  = 0x694,
        GuildCriteriaDeleted                     = 0x8D9,
        GuildAchievementMembers                  = 0xB71,
        ArenaTeamCommandResult                   = 0x5B4,
        PetAdded                                 = 0x13C,
        GuildRanks                               = 0xD50,
        GuildXPEarned                            = 0xBF9,
        NewWorld                                 = 0x81D,
        AbortNewWorld                            = 0x295,
        GuildMemberUpdateNote                    = 0xAB4,
        GuildInvite                              = 0xD30,
        NotifyMoney                              = 0x99C,
        QuestGiverQuestComplete                  = 0xE35,
        ItemPurchaseRefundResult                 = 0x7B5,
        SetItemPurchaseData                      = 0x4D1,
        ItemExpirePurchaseRefund                 = 0x795,
        InspectHonorStats                        = 0x5D0,
        GuildPartyState                          = 0x8BD,
        PVPLogData                               = 0xC5D,
        RatedBGStats                             = 0x418,
        WargameRequestSuccessfullySentToOpponent = 0x759,
        DisplayGameError                         = 0xA11,
        PVPOptionsEnabled                        = 0xA78,
        RatedBattlegroundRating                  = 0x935,
        SetMaxWeeklyQuantity                     = 0x9D1,
        GuildReputationWeeklyCap                 = 0x61C,
        GuildReputationReactionChanged           = 0xF59,
        PetitionAlreadySigned                    = 0xC39,
        RaidMarkersChanged                       = 0x930,
        CommentatorPartyInfo                     = 0x871,
        StreamingMovies                          = 0x9FD,
        TimeSyncRequest                          = 0x410,
        TimeAdjustment                           = 0x4F1,
        StartTimer                               = 0x9B0,
        DisenchantCredit                         = 0x990,
        SuspendToken                             = 0xB5C,
        ResumeToken                              = 0x998,
        CancelSpellVisual                        = 0x8D8,
        PlaySpellVisual                          = 0xF55,
        CancelOrphanSpellVisual                  = 0x590,
        PlayOrphanSpellVisual                    = 0xF9,
        LFGuildPost                              = 0xE91,
        LFGuildBrowse                            = 0x19,
        LFGuildRecruits                          = 0x45D,
        LFGuildCommandResult                     = 0x570,
        LFGuildApplications                      = 0x130,
        CancelSpellVisualKit                     = 0x35C,
        PlaySpellVisualKit                       = 0x230,
        AddItemPassive                           = 0x7F0,
        RemoveItemPassive                        = 0x439,
        SendItemPassives                         = 0x8DD,
        WorldServerInfo                          = 0x0D9,
        WeeklySpellUsage                         = 0x3B5,
        UpdateWeeklySpellUsage                   = 0x658,
        LastWeeklyReset                          = 0x0FD,
        GuildChallengeUpdate                     = 0xF3D,
        GuildChallengeCompleted                  = 0x4F9,
        LFGuildApplicantListChanged              = 0x355,
        LFGuildApplicationsListChanged           = 0x2D5,
        InspectRatedBGStats                      = 0x2B5,
        MoveSetActiveMover                       = 0x7DC,
        RuneRegenDebug                           = 0xCD0,
        MoveUpdateRunSpeed                       = 0x49D,
        MoveUpdateRunBackSpeed                   = 0x8B5,
        MoveUpdateWalkSpeed                      = 0x3B8,
        MoveUpdateSwimSpeed                      = 0x6B8,
        MoveUpdateSwimBackSpeed                  = 0x7BC,
        MoveUpdateFlightSpeed                    = 0x895,
        MoveUpdateFlightBackSpeed                = 0xB15,
        MoveUpdateTurnRate                       = 0xBB5,
        MoveUpdatePitchRate                      = 0xB70,
        MoveUpdateCollisionHeight                = 0xDD8,
        MoveUpdate                               = 0x294,
        MoveUpdateTeleport                       = 0xE1D,
        MoveUpdateKnockBack                      = 0x175,
        MoveUpdateApplyMovementForce             = 0xD38,
        MoveUpdateRemoveMovementForce            = 0x579,
        MoveSplineSetRunSpeed                    = 0x4B1,
        MoveSplineSetRunBackSpeed                = 0x438,
        MoveSplineSetSwimSpeed                   = 0x970,
        MoveSplineSetSwimBackSpeed               = 0xD70,
        MoveSplineSetFlightSpeed                 = 0xBB0,
        MoveSplineSetFlightBackSpeed             = 0xDD4,
        MoveSplineSetWalkBackSpeed               = 0x539,
        MoveSplineSetTurnRate                    = 0xA34,
        MoveSplineSetPitchRate                   = 0x594,
        MoveSetRunSpeed                          = 0x231,
        MoveSetRunBackSpeed                      = 0x394,
        MoveSetSwimSpeed                         = 0x09D,
        MoveSetSwimBackSpeed                     = 0x475,
        MoveSetFlightSpeed                       = 0x5FD,
        MoveSetFlightBackSpeed                   = 0x159,
        MoveSetWalkSpeed                         = 0xDD1,
        MoveSetTurnRate                          = 0x234,
        MoveSetPitchRate                         = 0x351,
        MoveRoot                                 = 0x955,
        MoveUnroot                               = 0x15C,
        MoveSetWaterWalk                         = 0x21C,
        MoveSetLandWalk                          = 0xD94,
        MoveSetFeatherFall                       = 0x9F4,
        MoveSetNormalFall                        = 0xC9D,
        MoveSetHovering                          = 0x251,
        MoveUnsetHovering                        = 0x3B1,
        MoveKnockBack                            = 0x194,
        MoveTeleport                             = 0x371,
        MoveSetCanFly                            = 0x419,
        MoveUnsetCanFly                          = 0x63D,
        MoveSetCanTurnWhileFalling               = 0x451,
        MoveUnsetCanTurnWhileFalling             = 0x2DD,
        MoveEnableTransitionBetweenSwimAndFly    = 0x459,
        MoveDisableTransitionBetweenSwimAndFly   = 0x0D4,
        MoveDisableGravity                       = 0xDD0,
        MoveEnableGravity                        = 0xC79,
        MoveDisableCollision                     = 0xD54,
        MoveEnableCollision                      = 0x7D4,
        MoveSetCollisionHeight                   = 0x99D,
        MoveSetVehicleRecID                      = 0x631,
        MoveApplyMovementForce                   = 0xEB8,
        MoveRemoveMovementForce                  = 0xDF4,
        MoveSetCompoundState                     = 0xC34,
        MoveSkipTime                             = 0x338,
        MoveSplineRoot                           = 0x75D,
        MoveSplineUnroot                         = 0x39D,
        MoveSplineDisableGravity                 = 0xB55,
        MoveSplineEnableGravity                  = 0x4F8,
        MoveSplineDisableCollision               = 0x034,
        MoveSplineEnableCollision                = 0xA70,
        MoveSplineSetFeatherFall                 = 0x41D,
        MoveSplineSetNormalFall                  = 0x854,
        MoveSplineSetHover                       = 0x4F4,
        MoveSplineUnsetHover                     = 0x698,
        MoveSplineSetWaterWalk                   = 0x211,
        MoveSplineSetLandWalk                    = 0xB31,
        MoveSplineStartSwim                      = 0x7D5,
        MoveSplineStopSwim                       = 0x71D,
        MoveSplineSetRunMode                     = 0x319,
        MoveSplineSetWalkMode                    = 0x531,
        MoveSplineSetFlying                      = 0xD5D,
        MoveSplineUnsetFlying                    = 0x255,
        VendorInventory                          = 0xD3D,
        RestrictedAccountWarning                 = 0xCD8,
        GuildReset                               = 0x1F9,
        SetPlayHoverAnim                         = 0xF58,
        GuildMoveStarting                        = 0x730,
        GuildMoved                               = 0x8FC,
        ClearBossEmotes                          = 0x259,
        LoadCUFProfiles                          = 0x179,
        SuppressNPCGreetings                     = 0x2FC,
        PartyInvite                              = 0x574,
        DumpRideTicketsResponse                  = 0xAB5,
        FeatureSystemStatus                      = 0x7F9,
        GuildNameChanged                         = 0x851,
        RequestPVPRewardsResponse                = 0x23D,
        SpellInterruptLog                        = 0x635,
        GameObjectActivateAnimKit                = 0xB19,
        MapObjEvents                             = 0xA7C,
        MissileCancel                            = 0xCF9,
        VoidStorageFailed                        = 0x83D,
        VoidStorageContents                      = 0xAB1,
        VoidStorageTransferChanges               = 0x8F0,
        VoidTransferResult                       = 0x6D8,
        VoidItemSwapResponse                     = 0x995,
        XPGainAborted                            = 0x398,
        GuildFlaggedForRename                    = 0x050,
        GuildChangeNameResult                    = 0x4D9,
        PrintNotification                        = 0x218,
        ClearCooldowns                           = 0x890,
        FailedPlayerCondition                    = 0x77D,
        CustomLoadScreen                         = 0x6F9,
        TransferPending                          = 0xEBC,
        GuildBankQueryResults                    = 0xED1,
        GuildBankLogQueryResults                 = 0x774,
        GuildBankRemainingWithdrawMoney          = 0x8B8,
        GuildPermissionsQueryResults             = 0x89C,
        GuildEventLogQueryResults                = 0x8B4,
        GuildBankTextQueryResult                 = 0x2F5,
        GuildMemberDailyReset                    = 0x554,
        GameEventDebugLog                        = 0x291,
        ServerPerf                               = 0xF79,
        AreaTriggerMovementUpdate                = 0x898,
        AdjustSplineDuration                     = 0x97D,
        LearnTalentFailed                        = 0x058,
        LFGJoinResult                            = 0xBF8,
        LFGQueueStatus                           = 0x950,
        LFGRoleCheckUpdate                       = 0x8B0,
        LFGUpdateStatusNone                      = 0xABD,
        LFGUpdateStatus                          = 0x154,
        LFGProposalUpdate                        = 0xDD5,
        LFGSearchResults                         = 0x05C,
        ServerInfoResponse                       = 0x0F4,
        LootContents                             = 0xDB1,
        ShowNeutralPlayerFactionSelectUI         = 0xCF1,
        NeutralPlayerFactionSelectResult         = 0x8F5,
        ChatIgnoredAccountMuted                  = 0x115,
        SORStartExperienceIncomplete             = 0xA99,
        AccountInfoResponse                      = 0x659,
        SetDFFastLaunchResult                    = 0x9D0,
        SupercededSpells                         = 0x5D8,
        LearnedSpells                            = 0x6B5,
        UnlearnedSpells                          = 0xA35,
        PetLearnedSpells                         = 0xE71,
        PetUnlearnedSpells                       = 0xB30,
        UpdateActionButtons                      = 0x951,
        DontAutoPushSpellsToActionBar            = 0x318,
        LFGSlotInvalid                           = 0x6D4,
        UpdateDungeonEncounterForLoot            = 0xF9D,
        SceneObjectEvent                         = 0x2DC,
        SendAllItemDurability                    = 0x3D8,
        BattlePetUpdates                         = 0xCFC,
        BattlePetTrapLevel                       = 0x339,
        PetBattleSlotUpdates                     = 0x535,
        BattlePetJournalLockAcquired             = 0x9DD,
        BattlePetJournalLockDenied               = 0xC58,
        BattlePetJournal                         = 0x098,
        BattlePetDeleted                         = 0x434,
        BattlePetsHealed                         = 0xB10,
        BattlePetLicenseChanged                  = 0x3F9,
        PartyUpdate                              = 0x87C,
        ReadyCheckStarted                        = 0x4B0,
        ReadyCheckResponse                       = 0xE98,
        ReadyCheckCompleted                      = 0x17C,
        PetBattleRequestFailed                   = 0xCB0,
        PetBattlePVPChallenge                    = 0xDDD,
        PetBattleFinalizeLocation                = 0x3FC,
        PetBattleFullUpdate                      = 0xD35,
        PetBattleFirstRound                      = 0xBD8,
        PetBattleRoundResult                     = 0x31C,
        PetBattleReplacementsMade                = 0xED4,
        PetBattleFinalRound                      = 0x199,
        PetBattleFinished                        = 0xB75,
        PetBattleChatRestricted                  = 0x874,
        PetBattleMaxGameLengthWarning            = 0xE50,
        StartElapsedTimer                        = 0xE90,
        StopElapsedTimer                         = 0xDBD,
        StartElapsedTimers                       = 0x031,
        ChallengeModeComplete                    = 0x010,
        ChallengeModeRewards                     = 0xAD5,
        IncreaseCastTimeForSpell                 = 0x278,
        ClearAllSpellCharges                     = 0x139,
        ChallengeModeAllMapStats                 = 0x415,
        ChallengeModeMapStatsUpdate              = 0xAF1,
        ChallengeModeRequestLeadersResult        = 0xD31,
        ChallengeModeNewPlayerRecord             = 0xE38,
        RespecWipeConfirm                        = 0xBF4,
        IsQuestCompleteResponse                  = 0x7F4,
        GMCharacterRestoreResponse               = 0x0DD,
        LootResponse                             = 0xD98,
        LootRemoved                              = 0x1F0,
        LootUpdated                              = 0x715,
        CoinRemoved                              = 0xF94,
        AELootTargets                            = 0x954,
        AELootTargetAck                          = 0x59D,
        LootReleaseAll                           = 0x1D5,
        LootRelease                              = 0x670,
        LootMoneyNotify                          = 0xB38,
        StartLootRoll                            = 0x334,
        LootRoll                                 = 0x77C,
        MasterLootCandidateList                  = 0x674,
        LootItemList                             = 0x3B9,
        LootRollsComplete                        = 0xA50,
        LootAllPassed                            = 0x1BD,
        LootRollWon                              = 0x53C,
        SetItemChallengeModeData                 = 0xA30,
        ClearItemChallengeModeData               = 0xBBD,
        ItemPushResult                           = 0xE51,
        DisplayToast                             = 0xD59,
        AreaTriggerDebugSweep                    = 0xB98,
        AreaTriggerDebugPlayerInside             = 0x131,
        ResetAreaTrigger                         = 0x7F8,
        SetPetSpecialization                     = 0x5BC,
        BlackMarketOpenResult                    = 0xED0,
        BlackMarketRequestItemsResult            = 0x751,
        BlackMarketBidOnItemResult               = 0xB18,
        BlackMarketOutbid                        = 0x1DC,
        BlackMarketWon                           = 0x975,
        ScenarioState                            = 0xD18,
        ScenarioProgressUpdate                   = 0x070,
        GroupNewLeader                           = 0xD71,
        SendRaidTargetUpdateAll                  = 0x498,
        SendRaidTargetUpdateSingle               = 0x57C,
        RandomRoll                               = 0xA5C,
        InspectResult                            = 0x4DD,
        ScenarioPOIs                             = 0x739,
        InstanceInfo                             = 0x89D,
        ConsoleWrite                             = 0x47C,
        AccountCriteriaUpdate                    = 0xCF5,
        PlayScene                                = 0x0BC,
        CancelScene                              = 0xC15,
        BattlePetError                           = 0x819,
        PetBattleQueueProposeMatch               = 0xD11,
        PetBattleQueueStatus                     = 0x610,
        MailCommandResult                        = 0x039,
        AddBattlenetFriendResponse               = 0xF14,
        ItemUpgradeResult                        = 0xADD,
        MoveCharacterCheatSuccess                = 0x891,
        MoveCharacterCheatFailure                = 0x875,
        AchievementEarned                        = 0x719,
        AreaShareInfoResponse                    = 0xD5C,
        LFGTeleportDenied                        = 0x9BD,
        AreaShareMappingsResponse                = 0x450,
        BonusRollEmpty                           = 0x511,
        UpdateExpansionLevel                     = 0x079,
        ControlUpdate                            = 0x578,
        ArenaPrepOpponentSpecializations         = 0xE58,
        GMTicketGetTicketResponse                = 0xA18,
        NukeAllObjectsDueToRealmBundlePort       = 0xD51,
        GMNotifyAreaChange                       = 0xEF8,
        ForceObjectRelink                        = 0x391,
        DisplayPromotion                         = 0xA7D,
        ClearedPromotion                         = 0x595,
        ServerFirstAchievements                  = 0xD78,
        CorpseLocation                           = 0xF78,
        CanDuelResult                            = 0x754,
        ImmigrantHostSearchLog                   = 0x778,
        SendKnownSpells                          = 0x155,
        SendSpellHistory                         = 0x815,
        SendSpellCharges                         = 0xE30,
        SendUnlearnSpells                        = 0xDF5,
        RefreshComponent                         = 0xDB9,
        InventoryChangeFailure                   = 0x529,
    }

    [Flags]
    public enum LegacyMessage : uint
    {
        #region Cinematic
        StartCinematic                           = 0x48D,
        #endregion

        SetAddonInfoRequest                      = 0x760,
        UpdateClientCacheVersion                 = 0x72D,
        RealmSplitStateResponse                  = 0x5CC,
        ResponseCharacterCreate                  = 0xF25,
        ResponseCharacterDelete                  = 0xE44,
        MessageOfTheDay                          = 0x849,
        AccountDataInitialized                   = 0xE48,
        UpdateObject                             = 0x120,
        ObjectDestroy                            = 0x34C,
        TutorialFlags                            = 0x6A8,
        UITime                                   = 0,
        LogoutComplete                           = 0x2A0,
        MessageChat                              = 0x009,
        CreatureStats                            = 0xAA4,
        GameObjectStats                          = 0x80D,
        NameCache                                = 0x30D,
        RealmCache                               = 0xD81,
    }

    [Flags]
    public enum ClientMessage : int
    {
        #region Authentication
        TransferInitiate                         = 0x4F57,
        AuthSession                              = 0xC07,
        #endregion

        #region CharacterList
        ReadyForAccountDataTimes                 = 0x5A5,
        EnumCharacters                           = 0x146,
        RequestCharCreate                        = 0xEB3,
        RequestCharDelete                        = 0xC2D,
        RequestRandomCharacterName               = 0x04E,
        SetRealmSplitState                       = 0x261,
        #endregion

        #region WorldEnter
        LoadingScreenNotify                      = 0x006,
        ViolenceLevel                            = 0x056,
        PlayerLogin                              = 0xEBA,
        #endregion

        #region Logout
        Logout                                   = 0x5A0,
        #endregion

        #region Disconnect
        LogDisconnect                            = 0xD47,
        #endregion

        #region Permanent
        Ping                                     = 0xCA7,
        #endregion

        #region Uncategorized
        SuspendCommsAck                          = -1,
        AuthContinuedSession                     = -1,
        EnableNagle                              = -1,
        SuspendTokenResponse                     = -1,
        RequestUITime                            = -1,
        ActivePlayer                             = 0xF84,
        CreatureStats                            = 0x285,
        GameObjectStats                          = 0xBE9,
        NameCache                                = 0x1EC,
        RealmCache                               = 0xA4D,
        ZoneUpdate                               = 0x88D,
        SetSelection                             = 0x17E,
        SetActionbarToggles                      = 0x4B,
        Areatrigger                              = 0x647,
        ObjectUpdateFailed                       = 0x2FB,
        GossipHello                              = 0x764, // unhandled
        Inspect                                  = 0x5A3, // unhandled
        CastSpell                                = 0x14C, // unhandled
        JoinChannel                              = 0x3E7, // unhandled
        #endregion

        #region ChatMessages
        ChatMessageSay                           = 0x67A,
        ChatMessageYell                          = 0xF7F,
        ChatMessageWhisper                       = 0x306,
        #endregion
        #region PlayerMovement
        MoveStartForward                         = 0x0FE,
        MoveStartBackward                        = 0x37A,
        MoveHeartBeat                            = 0xBD2,
        MoveStop                                 = 0x9DF,
        MoveStartTurnLeft                        = 0x46E,
        MoveStartTurnRight                       = 0x9F7,
        MoveStopTurn                             = 0x4CB,
        MoveStartStrafeLeft                      = 0x25E, // unhandled
        MoveStartStrafeRight                     = 0x1FB, // unhandled
        MoveStopStrafe                           = 0xADE, // unhandled
        MoveJump                                 = 0x44B, // unhandled
        MoveFallLand                             = 0x78B, // unhandled
        MoveTurnMouse                            = 0x46F, // unhandled
        #endregion
    }

    [Flags]
    public enum Message : uint
    {
        TransferInitiate                         = 0x4F57,
    }
}
