﻿using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System.Collections.Generic;

namespace RobnRaid
{
    public class RobCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller
        {
            get { return AllowedCaller.Player; }
        }

        public string Name
        {
            get { return "rob"; }
        }

        public string Help
        {
            get { return "This is a robbing command."; }
        }

        public string Syntax
        {
            get { return "<name> <location>"; }
        }

        public List<string> Aliases
        {
            get { return new List<string>(); }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            if (caller != null)
            {
                UnturnedPlayer player = (UnturnedPlayer)caller;
                if (command.Length == 2)
                {
                    UnturnedPlayer Target = UnturnedPlayer.FromName(command[0]);
                    if (Target != null)
                    {
                        UnturnedChat.Say(RobnRaid.Instance.Translate("rob_translation", player.DisplayName, Target.DisplayName, command[1]), RobnRaid.Instance.color);
                    }
                }
                else
                {
                    UnturnedChat.Say(player, RobnRaid.Instance.Translate("rob_usage"));
                }
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>
                {
                    "rob"
                };
            }
        }
    }
}