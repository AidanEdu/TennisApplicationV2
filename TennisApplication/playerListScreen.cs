﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TennisApplication
{
    public partial class playerListScreen : UserControl
    {
        int toggle = 1;
        public playerListScreen()
        {
            InitializeComponent();
            backPanel.Visible = false;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void addSaveButton_Click(object sender, EventArgs e)
        {
            if (addSaveButton.Text == "Add Player")
            {
                try
                {
                    Player newPlayer = new Player(firstNameTestBox.Text, lastNameTextBox.Text, genderBox.Text, 0, ageBox.Text, Convert.ToInt32(ratingBox.Text), null);
                    Form1.playerList.Add(newPlayer);

                    warningLabel.Text = $"Added: {newPlayer.firstName} {newPlayer.lastName}\n" +
                        $"DOB: {newPlayer.age}\n" +
                        $"Gender: {newPlayer.gender}\n" +
                        $"Rating: {newPlayer.rating}";




                }
                catch
                {
                    warningLabel.Text = "please enter the correct information";
                }

                updateList(",,,,,,");
            }
            else if (addSaveButton.Text == "Add Filter")
            {
                if (ageBox.Text == "Year/Month/Day")
                {
                    ageBox.Text = "";
                }
                if (genderBox.Text == "Use Selection")
                {
                    genderBox.Text = "";
                }
                if (ratingBox.Text == "Use Selection")
                {
                    ratingBox.Text = "";
                }
                updateList($"{firstNameTestBox.Text},{lastNameTextBox.Text},{ageBox.Text},{genderBox.Text},{ratingBox.Text},");
            }

        }

        private void updateList(string filterContent)
        {
            //Filter Format 
            //lkj
            //First,Last,Age,Gender,Wins,Rating;
            List<int> BreakContentIndex = new List<int>();  
            for(int i = 0; i < filterContent.Length; i++)
            {
                if (filterContent.Substring(i, 1) == ",")
                {
                    BreakContentIndex.Add(i);
                }
            }

            List<string> filterMode = new List<string>();
            List<int> playerIndexes = new List<int>();
            foreach (Player player in Form1.playerList)
            {
                playerIndexes.Add(Form1.playerList.IndexOf(player));

                for (int i = 0; i < BreakContentIndex.Count; i++)
                {
                    string data;
                   
                    if (i == 0)
                    {
                        data = filterContent.Substring(0, BreakContentIndex[i]);
                    }
                    else
                    {
                        data = filterContent.Substring(BreakContentIndex[i - 1] + 1, BreakContentIndex[i] - BreakContentIndex[i - 1] - 1);
                    }
                   

                    if (i == 0)
                    {
                        if (data == "" || data == player.firstName) 
                        {

                        }
                        else if (data != player.firstName)
                        {
                            playerIndexes.Remove(Form1.playerList.IndexOf(player)); 
                        }
                    }
                    if (i == 1)
                    {
                        if (data == "" || data == player.lastName)
                        {

                        }
                        else if (data != player.lastName)
                        {
                            playerIndexes.Remove(Form1.playerList.IndexOf(player));
                        }
                    }
                    if (i == 2)
                    {
                        if (data == "" || data == player.age)
                        {

                        }
                        else if (data != player.age)
                        {
                            playerIndexes.Remove(Form1.playerList.IndexOf(player));
                        }
                    }
                    if (i == 3)
                    {
                        if (data == "" || data == player.age)
                        {

                        }
                        else if (data != player.age)
                        {
                            playerIndexes.Remove(Form1.playerList.IndexOf(player));
                        }
                    }
                    if (i == 4)
                    {
                        if (data == "" || data == player.gender)
                        {

                        }
                        else if (data != player.gender)
                        {
                            playerIndexes.Remove(Form1.playerList.IndexOf(player));
                        }
                    }
                    if (i == 5)
                    {
                        if (data == "" || data == player.wins.ToString())
                        {

                        }
                        else if (data != player.wins.ToString())
                        {
                            playerIndexes.Remove(Form1.playerList.IndexOf(player));
                        }
                    }
                    if (i == 6)
                    {
                        if (data == "" || data == player.rating.ToString())
                        {

                        }
                        else if (data != player.rating.ToString())
                        {
                            playerIndexes.Remove(Form1.playerList.IndexOf(player));
                        }
                    }


                }

            }

            listBox1.Items.Clear();
            foreach (int p in playerIndexes)
            {
                listBox1.Items.Add($"{Form1.playerList[p].firstName} {Form1.playerList[p].lastName}");
            }
        }

        #region toggleOpen
        private void filterButton_Click(object sender, EventArgs e)
        {
            toggleMenu("filter", true);
        }

        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            toggleMenu("addPlayer", true);
        }

        public void toggleMenu(string mode, bool open)
        {

            if (open == true)
            {
                backPanel.Visible = true;

                if (mode == "addPlayer")
                {
                    titleLabel.Text = "Player Addition";
                    addSaveButton.Text = "Add Player";
                    warningLabel.Text = $"Please enter player information into the boxes below";
                }

                if (mode == "filter")
                {
                    titleLabel.Text = "Search Filter";
                    addSaveButton.Text = "Add Filter";
                    warningLabel.Text = $"Please enter filter information into the boxes below";
                }

            }
            else
            {
                backPanel.Visible = false;
            }

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            toggleMenu(null, false);
        }

        #endregion


        #region TextChanging
        private void ageBox_Enter(object sender, EventArgs e)
        {
            ageBox.Text = "";
        }
        private void ageBox_Leave(object sender, EventArgs e)
        {
                bool check = true;
            if (ageBox.Text.Length == 10)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (char.IsDigit(ageBox.Text, i) != true && i != 4 && i != 7)
                    {
                        check = false;
                        break;
                    }
                    else if (ageBox.Text.Substring(i, 1) != "/" && (i == 4 || i == 7))
                    {
                        check = false;
                    }
                }
            }
            else
            {
                check = false; 
            }
               

            if (ageBox.Text == "")
                {
                    ageBox.Text = "Year/Month/Days";
                }
                else if (check == false)
                {
                    ageBox.Text = "Year/Month/Days";
                }
                else
                {

                }
        }

        private void genderBox_Enter(object sender, EventArgs e)
        {
            genderBox.Text = "";
        }

        private void genderBox_Leave(object sender, EventArgs e)
        {
            genderBox.Text += "                                      ";
            if (genderBox.Text.Substring(0, 4) == "Male")
            {
                genderBox.Text = "Male";
            }
            else if (genderBox.Text.Substring(0, 6) == "Female")
            {
                genderBox.Text = "Female";
            }
            else if (genderBox.Text.Substring(0, 5) == "Other")
            {
                genderBox.Text = "Other";
            }
            else
            {
                genderBox.Text = "Use Selection";
            }

        }

        private void ratingBox_Enter(object sender, EventArgs e)
        {
            ratingBox.Text = "";
        }

        private void ratingBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ratingBox.Text) >= 1 && Convert.ToInt32(ratingBox.Text) <= 5)
                {

                }
                else
                {
                    ratingBox.Text = "Use Selection";
                }
            }
            catch
            {
                ratingBox.Text = "Use Selection";
            }
        }


        #endregion
    }
}