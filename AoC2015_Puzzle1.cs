using System;

namespace AoC2015_Puzzle1 {
    class AoC2015_Puzzle1 {
        static void Main(string[] args) {
            // Read the input file; Set the direction, position in which he goes into the basement, and the flag of when to stop looking for the position
            string parenthesisGuide = System.IO.File.ReadAllText(@"C:\Users\sschm\Documents\Advent_of_Code\C#\2015\AoC2015_Puzzle1Input.txt");
            int direction = 0;
            int position = -1, pFlag = 0;
            // At each character, if ( then up, if ) then down
            for(var i = 0; i < parenthesisGuide.Length; i++) {
                if(parenthesisGuide[i] == '(') {
                    direction++;
                } else if(parenthesisGuide[i] == ')') {
                    direction--;
                } 
                if(direction < 0 && pFlag == 0) {
                    position = i + 1;
                    pFlag = 1;
                }
            }

            Console.WriteLine("Go to this floor: " + direction);
            Console.WriteLine("Position in which he first goes into the basement: " + position);
        }
    }
}
