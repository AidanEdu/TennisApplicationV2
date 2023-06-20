using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisApplication
{
    public class Player
    {
        public string firstName, lastName, gender, age;
        public int wins, rating;
        public List<int> gameIndex;

        public Player (string _firstName, string _lastName, string _gender, int _wins, string _age, int _rating, List<int> _gameindex)
        {
           firstName = _firstName;
            lastName = _lastName;
            gender = _gender;   
            wins = _wins;
            age = _age;
            rating = _rating;
            gameIndex = _gameindex;
        }

        /*  public Player(int _x,int _y,int _size,int _speed,int _lives)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            lives = _lives;
        }

        public void Move(string direction, List<Rectangle> r)
        {
        */

    }
}
