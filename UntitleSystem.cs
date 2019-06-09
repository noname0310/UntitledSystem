using System.Collections.Generic;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using UnityEngine;
using Oxide.Core;
using Oxide.Core.Configuration;
using Oxide.Core.Plugins;
using Oxide.Core.Libraries.Covalence;
using Oxide.Game.Rust.Cui;
using Rust;

namespace Oxide.Plugins
{
    [Info("UntitleSystem", "noname", "2.3.6")]
    [Description("Serv Plugin For UntitledServer")]
    class UntitleSystem : RustPlugin
    {
        [PluginReference]
        Plugin PlaytimeTracker;

        private const string BasicPanelName = "Basic-Panel";

        DynamicConfigFile dataFile;

        private new void LoadDefaultConfig()
        {
            PrintWarning("Creating a new configuration file");
            Config.Clear();

            Config["ServerName"] = "DefaultServerName(Wiped: {0})";
            Config["UseCustomServerName"] = false;
            Config["MaxExplovesCount"] = 25;
            Config["DefaultCountUIToggle"] = true;
            Config["ExplovesCanUseSec"] = 14400;
            SaveConfig();
        }

        private void OnServerInitialized()
        {
            permission.RegisterPermission("untitlesystem.threeom", this);
            permission.RegisterPermission("untitlesystem.fivem", this);
            permission.RegisterPermission("untitlesystem.halfh", this);
            permission.RegisterPermission("untitlesystem.sixh", this);
            permission.RegisterPermission("untitlesystem.threeh", this);
            permission.RegisterPermission("untitlesystem.oneh", this);

            try
            {
                dataFile = Interface.Oxide.DataFileSystem.GetDatafile("UntitleSystem");
                dataFile["reboot"] = false;
                dataFile["shutdown"] = false;
                dataFile["quit"] = false;
                if (dataFile["LastResetDay"] == null)
                {
                    dataFile["LastResetDay"] = null;
                }
                dataFile.Save();
            }
            catch
            {
                Puts("DataReadError");
            }

            string SetServerNameCommand;

            if (Config["UseCustomServerName"].ToString() == "True")
            {
                if (!(dataFile["LastResetDay"] == null))
                {
                    SetServerNameCommand = @"server.hostname """ + string.Format(Config["ServerName"].ToString(), dataFile["LastResetDay"].ToString()) + @"""";
                    covalence.Server.Command(SetServerNameCommand);
                }
                else
                {
                    SetServerNameCommand = @"server.hostname """ + string.Format(Config["ServerName"].ToString(), "--.--") + @"""";
                    covalence.Server.Command(SetServerNameCommand);
                }
            }

            timer.Every(2, timer_Tick);
            timer.Every(1, Playtimetimer_Tick);
            timer.Every(10, Permissiontimer_Tick);

            if (Config["MaxExplovesCount"] == null)
            {
                Config["MaxExplovesCount"] = 25;
                SaveConfig();
            }

            if (Config["DefaultCountUIToggle"] == null)
            {
                Config["DefaultCountUIToggle"] = true;
                SaveConfig();
            }

            if (Config["ExplovesCanUseSec"] == null)
            {
                Config["ExplovesCanUseSec"] = 14400;
                SaveConfig();
            }
            if (dataFile["ExplovesCount"] == null)
            {
                dataFile["ExplovesCount"] = new Dictionary<string, Dictionary<string, string>>();
                dataFile.Save();
            }

            if (dataFile["ExpUIToggle"] == null)
            {
                dataFile["ExpUIToggle"] = new Dictionary<string, bool>();
                dataFile.Save();
            }

            ConnectedPlayersDataWrite();

            PlayersAddCountUI();
            PlayersUpdateHelpButton();
        }

        private void Unload()
        {
            PlayersDestroyCountUI();
        }

        // 매 2초마다
        private void timer_Tick()
        {
            try
            {
                dataFile = Interface.Oxide.DataFileSystem.GetDatafile("UntitleSystem");
                if (dataFile["quit"].ToString() == "True")
                {
                    //Puts("test");
                    dataFile["quit"] = false;
                    dataFile.Save();
                    covalence.Server.Command("quit");
                }
            }
            catch
            {
                Puts("데이터 파일을 읽는데 실패 하였습니다");
            }
        }

        [ConsoleCommand("reboot")]
        private void SystemReboot(ConsoleSystem.Arg args)
        {
            Puts("rebooting...");
            BasePlayer player = args.Player();
            if (!player)
            {
                Puts("permission accessed");
                try
                {
                    this.covalence.Server.Command("server.save");
                    dataFile["reboot"] = true;
                    dataFile.Save();
                }
                catch
                {
                    Puts("ERROR PLZ TRYAGAIN");
                }
            }
            else
                Puts("permission denal");
        }

        [ConsoleCommand("shutdown")]
        private void SystemShutDown(ConsoleSystem.Arg args)
        {
            Puts("shutdown reserved...");
            BasePlayer player = args.Player();
            if (!player)
            {
                Puts("permission accessed");
                try
                {
                    this.covalence.Server.Command("server.save");
                    dataFile["shutdown"] = true;
                    dataFile.Save();
                }
                catch
                {
                    Puts("ERROR PLZ TRYAGAIN");
                }
            }
            else
                Puts("permission denal");
        }

        private void PlayersDestroyCountUI()
        {
            foreach(BasePlayer player in BasePlayer.activePlayerList as List<BasePlayer>)
            {
                CuiHelper.DestroyUi(player, BasicPanelName);
                CuiHelper.DestroyUi(player, "LabelPanel");
            }
        }

        private void PlayersAddCountUI()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList as List<BasePlayer>)
            {
                if (Convert.ToBoolean(dataFile["ExpNoobToggle", player.UserIDString]) == true)
                {
                    string time = GetDownPlaytimeClock((double)PlaytimeTracker.Call("GetPlayTime", player.UserIDString));
                    UpdateLeftCountUI(player, true, time);
                }
                else
                {
                    UpdateLeftCountUI(player, true);
                }
            }
        }

        private void PlayersUpdateCountUI()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList as List<BasePlayer>)
            {
                CuiHelper.DestroyUi(player, BasicPanelName);
                CuiHelper.DestroyUi(player, "LabelPanel");
                if (Convert.ToBoolean(dataFile["ExpNoobToggle", player.UserIDString]) == true)
                {
                    string time = GetDownPlaytimeClock((double)PlaytimeTracker.Call("GetPlayTime", player.UserIDString));
                    UpdateLeftCountUI(player, true, time);
                }
                else
                {
                    UpdateLeftCountUI(player, true);
                }
            }
        }

        private void PlayersUpdateHelpButton()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList as List<BasePlayer>)
            {
                UpdateHelpButton(player);
            }
        }

        private void PlayerUpdateCountUI(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, BasicPanelName);
            CuiHelper.DestroyUi(player, "LabelPanel");
            UpdateLeftCountUI(player, true);
        }

        private void PlayerUpdateCountUIWithoutImage(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, "LabelPanel");
            UpdateLeftCountUI(player, false);
        }

        private void PlayerUpdateCountUIWithCustomMsg(BasePlayer player, string CustomMsg)
        {
            CuiHelper.DestroyUi(player, BasicPanelName);
            CuiHelper.DestroyUi(player, "LabelPanel");
            UpdateLeftCountUI(player, true, CustomMsg);
        }

        private void PlayerUpdateCountUIWithoutImageWithCustomMsg(BasePlayer player, string CustomMsg)
        {
            CuiHelper.DestroyUi(player, "LabelPanel");
            UpdateLeftCountUI(player, false, CustomMsg);
        }

        private void UpdateLeftCountUI(BasePlayer player) => UpdateLeftCountUIMain(player, true, " ");

        private void UpdateLeftCountUI(BasePlayer player, bool Imageupdate) => UpdateLeftCountUIMain(player, Imageupdate, " ");

        private void UpdateLeftCountUI(BasePlayer player, bool Imageupdate, string CustomMsg) => UpdateLeftCountUIMain(player, Imageupdate, CustomMsg);

        private void UpdateLeftCountUIMain(BasePlayer player, bool Imageupdate, string CustomMsg)
        {
            if (Convert.ToBoolean(dataFile["ExpUIToggle", player.UserIDString]) == true)
            {
                if (dataFile["ExplovesCount", player.UserIDString] == null)
                {
                    SetDefaultDataFormat(player);
                }

                string CountOfLeftExp;
                int FontSize = 15;
                string LabelAnchorMin = "0.4 0";

                if (CustomMsg == " ")
                {
                    if (dataFile["ExplovesCount", player.UserIDString, "LeftCount"].ToString() == "-1")
                        CountOfLeftExp = "0/" + Config["MaxExplovesCount"].ToString();
                    else
                        CountOfLeftExp = dataFile["ExplovesCount", player.UserIDString, "LeftCount"].ToString() + "/" + Config["MaxExplovesCount"].ToString();
                }

                else
                {
                    CountOfLeftExp = CustomMsg;
                    FontSize = 13;
                    LabelAnchorMin = "0.3 0";
                }
                CuiElementContainer LeftExpUI = new CuiElementContainer();
                
                if (Imageupdate == true)
                {
                    string panel = LeftExpUI.Add(new CuiPanel
                    {
                        CursorEnabled = false,
                        Image =
                        {
                            Color = "0 0 0 0.4"
                        },

                        RectTransform =
                        {
                            AnchorMin = "0.28 0.025",
                            AnchorMax = "0.3392 0.06"
                        },
                    }, "Hud", BasicPanelName);

                    LeftExpUI.Add(new CuiElement
                    {
                        Name = "BombImage",
                        Parent = BasicPanelName,
                        Components =
                        {
                            new CuiRawImageComponent { Color = "1 1 1 1", Url = "https://i.imgur.com/t3QdFmG.png" }, // TODO: Add config options
                            new CuiRectTransformComponent { AnchorMin = "0 0.02",
                                                        AnchorMax = "0.32 0.93" } // TODO: Add config options
                        }
                    });
                }

                string labelpanel = LeftExpUI.Add(new CuiPanel
                {
                    CursorEnabled = false,
                    Image =
                    {
                        Color = "0 0 0 0"
                    },

                    RectTransform =
                    {
                        AnchorMin = "0 0",
                        AnchorMax = "1 1"
                    },
                }, BasicPanelName, "LabelPanel");

                LeftExpUI.Add(new CuiLabel
                {
                    Text =
                    {
                        Text = CountOfLeftExp,
                        FontSize = FontSize,
                        Align = TextAnchor.MiddleCenter
                    },
                    RectTransform =
                    {
                        AnchorMin = "0.3 0",
                        AnchorMax = "1.0 1"
                        //AnchorMin = "0.4 0",
                        //AnchorMax = "1.0 1"
                    }
                }, labelpanel);

                CuiHelper.AddUi(player, LeftExpUI);
            }
        }

        private void UpdateHelpButton(BasePlayer player)
        {
            CuiHelper.DestroyUi(player, "HelpBTn");

            if (Convert.ToBoolean(dataFile["ExpUIToggle", player.UserIDString]) == true)
            {
                CuiElementContainer HelpBtnUI = new CuiElementContainer();
                
                string button = HelpBtnUI.Add(new CuiButton
                {
                    Button =
                    {
                        Command = "info",
					    Color = "0.8 0.2 0.1 0.4"
                    },
				    RectTransform =
                    {
                        AnchorMin = "0.28 0.07",
					    AnchorMax = "0.3394 0.105"
                    },
				    Text =
                    {
                        Text = "도움말",
					    FontSize = 18,
					    Align = TextAnchor.MiddleCenter
                    }
                }, "Hud", "HelpBTn");

                CuiHelper.AddUi(player, HelpBtnUI);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////폭발물 제한 로직

        [ConsoleCommand("reset.expcount")]
        private void ResetExpCount(ConsoleSystem.Arg args)
        {
            Puts("reseting...");
            BasePlayer player = args.Player();
            if (!player)
            {
                Puts("permission accessed");
                try
                {
                    dataFile.Remove("ExplovesCount");
                    dataFile.Save();
                    ConnectedPlayersDataWriteWithoutToggleSetting();
                    PlayersUpdateCountUI();
                    covalence.Server.Command("announce.announce 폭발물 개수 제한이 초기화 되었습니다");
                    covalence.Server.Command("say 폭발물 개수 제한이 초기화 되었습니다");
                }
                catch
                {
                    Puts("ERROR PLZ TRYAGAIN");
                }
            }
            else
                Puts("permission denal");
        }

        [ChatCommand("checkexp")]
        private void CheckExploveCount(BasePlayer player, string cmd, string[] args)
        {
            player.ChatMessage("현재 사용가능 폭발물 횟수: " + dataFile["ExplovesCount", player.UserIDString, "LeftCount"] + "번");
        }

        [ChatCommand("expui")]
        private void ExploveCountUIToggle(BasePlayer player, string cmd, string[] args)
        {
            if (Convert.ToBoolean(dataFile["ExpUIToggle", player.UserIDString]) == true)
            {
                dataFile["ExpUIToggle", player.UserIDString] = false.ToString();
                dataFile.Save();
                CuiHelper.DestroyUi(player, BasicPanelName);
                CuiHelper.DestroyUi(player, "LabelPanel");
                player.ChatMessage("폭발물 카운트 UI가 꺼졌습니다");
            }
            else
            {
                dataFile["ExpUIToggle", player.UserIDString] = true.ToString();
                dataFile.Save();
                PlayerUpdateCountUI(player);
                player.ChatMessage("폭발물 카운트 UI가 켜졌습니다");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////api
        void ExploveCountUIEnable(BasePlayer player)
        {
            Puts(player.UserIDString);
            if (Convert.ToBoolean(dataFile["ExpUIToggle", player.UserIDString]) == false)
            {
                dataFile["ExpUIToggle", player.UserIDString] = true.ToString();
                dataFile.Save();
                PlayerUpdateCountUI(player);
                UpdateHelpButton(player);
            }
        }

        void ExploveCountUIDisable(BasePlayer player)
        {
            //Puts(player.UserIDString);
            if (Convert.ToBoolean(dataFile["ExpUIToggle", player.UserIDString]) == true)
            {
                dataFile["ExpUIToggle", player.UserIDString] = false.ToString();
                dataFile.Save();
                CuiHelper.DestroyUi(player, BasicPanelName);
                CuiHelper.DestroyUi(player, "LabelPanel");
                CuiHelper.DestroyUi(player, "HelpBTn");
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////api

        private void Permissiontimer_Tick()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList as List<BasePlayer>)
            {
                if (Convert.ToBoolean(dataFile["ExpNoobToggle", player.UserIDString]) == true)
                {
                    if (!permission.UserHasPermission(player.UserIDString, "gathermanager.use"))
                    {
                        permission.GrantUserPermission(player.UserIDString, "gathermanager.use", this);
                    }
                    if (!permission.UserHasPermission(player.UserIDString, "dmplayers.use"))
                    {
                        permission.GrantUserPermission(player.UserIDString, "dmplayers.use", this);
                    }
                    if (!permission.UserHasPermission(player.UserIDString, "donttargetme.allow"))
                    {
                        permission.GrantUserPermission(player.UserIDString, "donttargetme.allow", this);
                    }
                    if (!permission.UserHasPermission(player.UserIDString, "bedscooldowns.allow"))
                    {
                        permission.GrantUserPermission(player.UserIDString, "bedscooldowns.allow", this);
                    }
                }
                else
                {
                    if (permission.UserHasPermission(player.UserIDString, "gathermanager.use"))
                    {
                        permission.RevokeUserPermission(player.UserIDString, "gathermanager.use");
                    }
                    if (permission.UserHasPermission(player.UserIDString, "dmplayers.use"))
                    {
                        permission.RevokeUserPermission(player.UserIDString, "dmplayers.use");
                    }
                    if (permission.UserHasPermission(player.UserIDString, "donttargetme.allow"))
                    {
                        permission.RevokeUserPermission(player.UserIDString, "donttargetme.allow");
                    }
                    if (permission.UserHasPermission(player.UserIDString, "bedscooldowns.allow"))
                    {
                        permission.RevokeUserPermission(player.UserIDString, "bedscooldowns.allow");
                    }
                }
            }
        }

        private void Playtimetimer_Tick()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList as List<BasePlayer>)
            {
                string time = GetDownPlaytimeClock((double)PlaytimeTracker.Call("GetPlayTime", player.UserIDString));
                if (time == "error")
                {
                    if (Convert.ToBoolean(dataFile["ExpNoobToggle", player.UserIDString]) == true)
                    {
                        dataFile["ExpNoobToggle", player.UserIDString] = false;
                        dataFile.Save();
                        permission.RevokeUserPermission(player.UserIDString, "gathermanager.use");
                        permission.RevokeUserPermission(player.UserIDString, "dmplayers.use");
                        permission.RevokeUserPermission(player.UserIDString, "donttargetme.allow");
                        permission.RevokeUserPermission(player.UserIDString, "bedscooldowns.allow");
                        covalence.Server.Command("say " + player.displayName + "님의 자원배율 5배 효과가 끝났습니다");
                        covalence.Server.Command("say " + player.displayName + "님의 상태이상 제거 효과가 끌났습니다");
                        covalence.Server.Command("say " + player.displayName + "님의 엔피시 타게팅 제거 효과가 끝났습니다");
                        covalence.Server.Command("say " + player.displayName + "님의 침대 쿨타임 제거 효과가 끝났습니다");
                        covalence.Server.Command("say " + player.displayName + "님의 뉴비 집 보호 효과가 끝났습니다");
                        covalence.Server.Command("say " + player.displayName + "님이 폭발물을 " + Convert.ToInt16(Config["MaxExplovesCount"].ToString()) + "번 사용할 수 있게 되었습니다");
                        PlayerUpdateCountUIWithoutImage(player);
                    }
                }
                else
                {
                    PlayerUpdateCountUIWithoutImageWithCustomMsg(player, time);
                }
            }
        }

        private string GetDownPlaytimeClock(double time)
        {
            time = Convert.ToDouble(Config["ExplovesCanUseSec"]) - time;
            if (time > 0)
            {
                TimeSpan dateDifference = TimeSpan.FromSeconds((float)time);
                var days = dateDifference.Days;
                var hours = dateDifference.Hours;
                hours += (days * 24);
                var mins = dateDifference.Minutes;
                var secs = dateDifference.Seconds;
                return string.Format("<color=red>{0:00}:{1:00}:{2:00}</color>", hours, mins, secs);
            }
            else
            {
                return "error";
            }
        }

        private void ConnectedPlayersDataWriteWithoutToggleSetting()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList as List<BasePlayer>)
            {
                if (dataFile["ExplovesCount", player.UserIDString] == null)
                {
                    dataFile["ExplovesCount", player.UserIDString, "Name"] = player.displayName;
                    dataFile["ExplovesCount", player.UserIDString, "LeftCount"] = Config["MaxExplovesCount"].ToString();
                    if (dataFile["ExpUIToggle", player.UserIDString] == null)
                    {
                        dataFile["ExpUIToggle", player.UserIDString] = Config["DefaultCountUIToggle"].ToString().ToString();
                    }
                    dataFile.Save();
                }
            }
        }

        private void ConnectedPlayersDataWrite()
        {
            foreach (BasePlayer player in BasePlayer.activePlayerList as List<BasePlayer>)
            {
                if (dataFile["ExplovesCount", player.UserIDString] == null)
                {
                    SetDefaultDataFormat(player);
                }
            }
        }

        private void SetDefaultDataFormat(BasePlayer player)
        {
            dataFile["ExplovesCount", player.UserIDString, "Name"] = player.displayName;
            dataFile["ExplovesCount", player.UserIDString, "LeftCount"] = Config["MaxExplovesCount"].ToString();
            dataFile["ExpUIToggle", player.UserIDString] = Config["DefaultCountUIToggle"].ToString();
            dataFile.Save();
        }

        void OnPlayerInit(BasePlayer player)
        {
            if (player.IsNpc) return;

            timer.Once(5f, () =>
            {
                if (dataFile["ExplovesCount", player.UserIDString] == null)
                {
                    SetDefaultDataFormat(player);
                }
                if (dataFile["ExpNoobToggle", player.UserIDString] == null)
                {
                    dataFile["ExpNoobToggle", player.UserIDString] = true;
                    dataFile.Save();
                }

                if (Convert.ToBoolean(dataFile["ExpNoobToggle", player.UserIDString]) == false)
                {
                    PlayerUpdateCountUI(player);
                    if (permission.UserHasPermission(player.UserIDString, "gathermanager.use"))
                    {
                        permission.RevokeUserPermission(player.UserIDString, "gathermanager.use");
                    }
                    if (permission.UserHasPermission(player.UserIDString, "dmplayers.use"))
                    {
                        permission.RevokeUserPermission(player.UserIDString, "dmplayers.use");
                    }
                    if (permission.UserHasPermission(player.UserIDString, "donttargetme.allow"))
                    {
                        permission.RevokeUserPermission(player.UserIDString, "donttargetme.allow");
                    }
                    if (permission.UserHasPermission(player.UserIDString, "bedscooldowns.allow"))
                    {
                        permission.RevokeUserPermission(player.UserIDString, "bedscooldowns.allow");
                    }
                }
                else
                {
                    permission.GrantUserPermission(player.UserIDString, "gathermanager.use", this);
                    permission.GrantUserPermission(player.UserIDString, "dmplayers.use", this);
                    permission.GrantUserPermission(player.UserIDString, "donttargetme.allow", this);
                    permission.GrantUserPermission(player.UserIDString, "bedscooldowns.allow", this);
                    string time = GetDownPlaytimeClock((double)PlaytimeTracker.Call("GetPlayTime", player.UserIDString));
                    PlayerUpdateCountUIWithCustomMsg(player, time);
                }
                UpdateHelpButton(player);
            });
        }
        /*
        private void OnPlayerSleepEnded(BasePlayer player)
        {
            if (player.IsNpc) return;

            if (dataFile["ExplovesCount", player.UserIDString] == null)
            {
                SetDefaultDataFormat(player);
            }
            if (dataFile["ExpNoobToggle", player.UserIDString] == null)
            {
                dataFile["ExpNoobToggle", player.UserIDString] = true;
                dataFile.Save();
            }

            if (Convert.ToBoolean(dataFile["ExpNoobToggle", player.UserIDString]) == false)
                PlayerUpdateCountUI(player);
            else
            {
                string time = GetDownPlaytimeClock((double)PlaytimeTracker.Call("GetPlayTime", player.UserIDString));
                PlayerUpdateCountUIWithCustomMsg(player, time);
            }
            UpdateHelpButton(player);
        }
        */
        private object OnEntityTakeDamage(BaseCombatEntity entity, HitInfo info)
        {
            if (entity.name.Contains("deploy") || entity.name.Contains("building"))
            {
                var player = info?.Initiator?.ToPlayer();

                if (!player || !entity.OwnerID.IsSteamId())
                {
                    return null;
                }

                if (Convert.ToInt16(dataFile["ExplovesCount", player.UserIDString, "LeftCount"]) == -1 || Convert.ToBoolean(dataFile["ExpNoobToggle", player.UserIDString]) == true)
                {
                    info.damageTypes.Scale(DamageType.Explosion, 0);
                }
            }
            return null;
        }

        private void ExpThrownDataWrite(BasePlayer player, BaseEntity entity)
        {
            if(entity.ShortPrefabName == "flare.deployed" ||
                entity.ShortPrefabName == "survey_charge.deployed" ||
                entity.ShortPrefabName == "grenade.smoke.deployed" || 
                entity.ShortPrefabName == "grenade.supplysignal.deployed")
            {
                return;
            }

            if (dataFile["ExplovesCount", player.UserIDString] == null)
            {
                SetDefaultDataFormat(player);
            }
            if (Convert.ToBoolean(dataFile["ExpNoobToggle", player.UserIDString]) == true)
            {
                string time = GetDownPlaytimeClock((double)PlaytimeTracker.Call("GetPlayTime", player.UserIDString));
                player.ChatMessage("<color=red>뉴비는 폭발물을 사용할수 없습니다!</color> \n사용 가능하기까지 남은시간 : " + time);
                Puts(player.displayName + " 시간 안넘기고 폭발시도");
                return;
            }
            if (Convert.ToInt16(dataFile["ExplovesCount", player.UserIDString, "LeftCount"]) > 0)
            {
                dataFile["ExplovesCount", player.UserIDString, "LeftCount"] = (Convert.ToInt16(dataFile["ExplovesCount", player.UserIDString, "LeftCount"]) - 1).ToString();
                dataFile.Save();

                player.ChatMessage("앞으로 폭발물을 " + dataFile["ExplovesCount", player.UserIDString, "LeftCount"] + " 번 더 사용하실 수 있습니다");
                Puts(player.displayName + " 폭발물수: " + dataFile["ExplovesCount", player.UserIDString, "LeftCount"]);
            }
            else if (Convert.ToInt16(dataFile["ExplovesCount", player.UserIDString, "LeftCount"]) == 0)
            {
                dataFile["ExplovesCount", player.UserIDString, "LeftCount"] = (Convert.ToInt16(dataFile["ExplovesCount", player.UserIDString, "LeftCount"]) - 1).ToString();
                dataFile.Save();
                player.ChatMessage("<color=red>폭발물 사용가능 횟수를 전부 소비 하셨습니다 내일까지 기다려 주세요!</color>");
                Puts(player.displayName + " 폭발물수: " + dataFile["ExplovesCount", player.UserIDString, "LeftCount"]);
            }
            else if (Convert.ToInt16(dataFile["ExplovesCount", player.UserIDString, "LeftCount"]) == -1)
            {
                player.ChatMessage("<color=red>폭발물 사용가능 횟수를 전부 소비 하셨습니다 내일까지 기다려 주세요!</color>");
                Puts(player.displayName + " 폭발물수: " + dataFile["ExplovesCount", player.UserIDString, "LeftCount"]);
            }

            PlayerUpdateCountUIWithoutImage(player);
        }

        private void OnExplosiveThrown(BasePlayer player, BaseEntity entity) => ExpThrownDataWrite(player, entity);

        private void OnRocketLaunched(BasePlayer player, BaseEntity entity) => ExpThrownDataWrite(player, entity);

        private void OnExplosiveDropped(BasePlayer player, BaseEntity entity) => ExpThrownDataWrite(player, entity);

        /////////////////////////////////////////////////////////////////////////////////////폭발물 제한 로직
    }
}