using System;
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
        List<int> playerIndexes = new List<int>();
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
            bool checkTwo = false; 
            if (addSaveButton.Text == "Add Player")
            {
                foreach (Player p in Form1.playerList)
                {
                    if (firstNameTestBox.Text == p.firstName && lastNameTextBox.Text == p.lastName)
                    {
                        checkTwo = true; 
                    }
                }

                if (checkTwo == false)
                {
                    try
                    {
                       
                        bool check = true;
                        if (dobComboBox.Text.Length == 10)
                        {
                            for (int i = 0; i < 9; i++)
                            {
                                if (char.IsDigit(dobComboBox.Text, i) != true && i != 4 && i != 7)
                                {
                                    check = false;
                                    break;
                                }
                                else if (dobComboBox.Text.Substring(i, 1) != "/" && (i == 4 || i == 7))
                                {
                                    check = false;
                                }
                            }
                        }
                        else
                        {
                            check = false;
                        }

                        if (check == true)
                        {
                            Player newPlayer = new Player(firstNameTestBox.Text, lastNameTextBox.Text, genderBox.Text, 0, dobComboBox.Text, Convert.ToInt32(ratingBox.Text), null);
                            Form1.playerList.Add(newPlayer);

                            warningLabel.Text = $"Added: {newPlayer.firstName} {newPlayer.lastName}\n" +
                                $"DOB: {newPlayer.age}\n" +
                                $"Gender: {newPlayer.gender}\n" +
                                $"Rating: {newPlayer.rating}";
                        }
                        else
                        {
                            warningLabel.Text = "please enter the correct information";
                        }
                    }
                    catch
                    {
                        warningLabel.Text = "please enter the correct information";
                    }


                    updateList(",,,,,,");

                }
                else
                {
                    warningLabel.Text = "A player with this name already exists!";
                }
            }
            else if (addSaveButton.Text == "Search")
            {
                if (dobComboBox.Text == "Year/Month/Days")
                {
                    dobComboBox.Text = "";
                }
                if (genderBox.Text == "Use Selection")
                {
                    genderBox.Text = "";
                }
                if (ratingBox.Text == "Use Selection")
                {
                    ratingBox.Text = "";
                }
                updateList($"{firstNameTestBox.Text},{lastNameTextBox.Text},{dobComboBox.Text},{genderBox.Text},{ratingBox.Text},");
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
            playerIndexes.Clear();
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
                        if (data == "" || data == player.gender)
                        {

                        }
                        else if (data != player.gender)
                        {
                            playerIndexes.Remove(Form1.playerList.IndexOf(player));
                        }
                    }
                    if (i == 4)
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
            toggleMenu("search", true);
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
                    ageTextBox.Visible = false;
                    dobComboBox.Visible = true; 
                    ageLabel.Text = "Date of Birth";
                }

                if (mode == "search")
                {
                    titleLabel.Text = "Search";
                    addSaveButton.Text = "Search";
                    warningLabel.Text = $"Please enter filter information into the boxes below, you may leave fields blank";
                    dobComboBox.Visible = false;
                    ageTextBox.Visible = true;
                    ageLabel.Text = "Age";
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
            dobComboBox.Text = "";
        }
        private void ageBox_Leave(object sender, EventArgs e)
        {
                bool check = true;
            if (dobComboBox.Text.Length == 10)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (char.IsDigit(dobComboBox.Text, i) != true && i != 4 && i != 7)
                    {
                        check = false;
                        break;
                    }
                    else if (dobComboBox.Text.Substring(i, 1) != "/" && (i == 4 || i == 7))
                    {
                        check = false;
                    }
                }
            }
            else
            {
                check = false; 
            }
               

            if (dobComboBox.Text == "")
                {
                    dobComboBox.Text = "Year/Month/Days";
                }
                else if (check == false)
                {
                    dobComboBox.Text = "Year/Month/Days";
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<int> spaceIndex = new List<int>(); 
            warningLabel.Text = $"{listBox1.SelectedItem.ToString()}"; 
            for (int i = 0; i < listBox1.SelectedItem.ToString().Length; i++)
            {
                if (listBox1.SelectedItem.ToString().Substring(i,1) == " ")
                {
                    spaceIndex.Add(i);    
                }
            }

            foreach (Player p in Form1.playerList)
            {
                
            }
        }
        private void dobComboBox_TextChanged(object sender, EventArgs e)
        {
            if (dobComboBox.Text.Length == 2 || dobComboBox.Text.Length == 5 || dobComboBox.Text.Length == 8)
            {
                dobComboBox.Text += "/";
                dobComboBox.SelectionStart = 3;
            }
            
        }
    }
}
    