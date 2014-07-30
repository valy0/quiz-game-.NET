using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiz_Game.Models;

namespace Quiz_Game.Helpers
{
    public class Util
    {
        // class that will return all game modes so we can fill them up in a dropdown
        public static List<SelectListItem> GameModes(bool includeSelected)
        {
            SettingsContext sc = new SettingsContext();
            List<SelectListItem> modes = new List<SelectListItem>();
            bool selected = false;

            // get current game mode will later be used to set the selected option in the dropdown
            int gameMode = sc.QuizSettings.Where(x => x.Name == "GameMode").FirstOrDefault().Value;

            // loop through all game modes
            foreach (GameMode gm in sc.GameModes.OrderBy(x => x.GameModeID))
            {
                if (gm.GameModeID == gameMode)
                    selected = true; // game mode id matches the one in settings
                else
                    selected = false; // game mode id does NOT match the one in settings

                // add game mode to list
                modes.Add(new SelectListItem { Text = gm.Mode, Value = gm.GameModeID.ToString(), Selected = includeSelected ? selected : false });
            }

            return modes;
        }
    }
}