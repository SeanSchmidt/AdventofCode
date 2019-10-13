using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC_Puzzle2
{
    class Program
    {
        static void Main(string[] args)
        {
            int twoLettered = 0, threeLettered = 0, occurances = 0, checksum; // Keep track of two lettered and three lettered counts, occurances of letters in an id, and the total checksum, respectively
            const int Limiter = 1; // Limits the count of two and three lettere occurances per id to one            
            int disFlag = 0; // Flag to exit comparing loop as two non matching letters would not match the rules            
            int likeness = 0; // Used to keep track of how many letters match and add matches to the list           
            int twoCount = 0, threeCount = 0; // Ensures that something like two a's and two c's in an id only gets counted as 1 entry in the two lettered total
            // List of Ids
            var boxIDs = new List<string>() { "ohvflkatysoimjxbunazgwcdpr", "ohoflkctysmiqjxbufezgwcdpr", "ohvflkatysciqwxfunezgwcdpr", "fhvflyatysmiqjxbunazgwcdpr", "ohvhlkatysmiqjxbunhzgwcdxr", "ohvflbatykmiqjxbunezgscdpr", "ohvflkatasaiqjxbbnezgwcdpr", "ohvflkatyymiqjxrunetgwcdpr", "ohvflkatbsmiqhxbunezgwcdpw", "oheflkytysmiqjxbuntzgwcdpr", "ohvflkatrsmiqjibunezgwcupr", "ohvflkaiysmiqjxbunkzgwkdpr", "ohvilkutysmiqjxbuoezgwcdpr", "phvflkatysmkqjxbulezgwcdpr", "ohvflkatnsmiqjxbznezgpcdpr", "ohvylkatysriqjobunezgwcdpr", "ohvflkatytmiqjxbunezrwcypr", "ohvonkatysmiqjxbunezgwxdpr", "ohvflkatgsmoqjxyunezgwcdpr", "ohvflkbtqsmicjxbunezgwcdpr", "ohvflkatysmgqjqbunezgwcdvr", "ohvtlkatyrmiqjxbunezgwcdpi", "ohvflkatyskovjxbunezgwcdpr", "ohvflkayysmipjxbunezgwcdpu", "ohvalkltysmiqjxbunezgecdpr", "ohvflkatysmiqjxiunezgnndpr", "ohvflkatyomiqjxbbnezgwcdpp", "ohvflkatysmiqjxbuoezgncdpy", "omvflkvtysmiqjxwunezgwcdpr", "ohvflkatynmicjxbunezgwpdpr", "ohvflkatyqmaqjxbunezvwcdpr", "ohbfhkatysmiqjxbunezgwcdqr", "ohvflkatesmiqjvbunezpwcdpr", "ohvflkatysmsqjxiunezgwcdhr", "ohvfjkatysmwqjxbunezgwcddr", "ohvflkanysmiqjxbunwkgwcdpr", "ohqflkatysmiqjxbuuezgwcddr", "ohvflkatysmvqjxbznlzgwcdpr", "ohvflkatysmiqjxbunjzwwqdpr", "ohvfjkatysmiqxxbunezgwcupr", "chvfxkatysmiqjxxunezgwcdpr", "uhvflkatitmiqjxbunezgwcdpr", "ohvflbatysmiqjxbuntzgwcdor", "ohvflkmtysmmqjxbunexgwcdpr", "ohvflsatysmyqjxjunezgwcdpr", "ohvfskatysmiqjjbunezgwcdpg", "ohvflkatysniqjxbunexgwcrpr", "ohvfekatysmiqjxbunedswcdpr", "ohvfltatysmjqjxbunezghcdpr", "ohvflkatydmiqjxvunezggcdpr", "oavflkatysmiqjxtunazgwcdpr", "ohvflkltysmiqjxbuzeugwcdpr", "ohbflkatysmiqjybuuezgwcdpr", "ehvfzkatysmiqjxbuhezgwcdpr", "odvflkatssmiqjxbunezgwcdpj", "ohvflkatysmiqjzbufezgwbdpr", "jhvflkdtysmiqqxbunezgwcdpr", "ohvflkatysmiqjwbunengwcnpr", "ohvfskatysmiqjxbxuezgwcdpr", "ohvflkatysmiqjobvnezgwcrpr", "ohvrlkatysmiqjxbwnezgrcdpr", "ofvflkatysmiqjxbunezpwcdwr", "ohvfxdatyomiqjxbunezgwcdpr", "yhvflkatydmiqjxbubezgwcdpr", "ohvflkatysdiqjxbuneztwcspr", "ohvflkatydmiquxbunezgwcbpr", "ohvflkatysmiqcxbukezgwcdwr", "ohvflkntasmiqjxbunezghcdpr", "lhvflkatysmiqjxbunezqwckpr", "ehifikatysmiqjxbunezgwcdpr", "ohvflkatysmiqjcbutezgwcdpm", "ohvflkatjssiqrxbunezgwcdpr", "oyvflkavysmiqjxlunezgwcdpr", "orvflkgtysmiqjxbukezgwcdpr", "ihvflkatysmiqaxbunpzgwcdpr", "ohvflkatusmiqjxbbnezgwchpr", "ohvflkatysbiqjxvuneugwcdpr", "ohvflkatysmiqjcbungzgwcwpr", "ovvflkatysmidjxbunezgscdpr", "ohvflqatysmiljxbunfzgwcdpr", "ghvfokatysmiqjxbunqzgwcdpr", "nxvflkatysmxqjxbunezgwcdpr", "ohvflkatysmiqjxbexezgwrdpr", "ohvfrkatysmhqjxbuntzgwcdpr", "ohvflkvtysmiqjxocnezgwcdpr", "ohvglkgtysmiqjxnunezgwcdpr", "ohvflkatysmnqjxbunecgwqdpr", "oyvflkatysgiqjxbcnezgwcdpr", "ofvflkatysmiqjxbunfzgwcdpg", "otvflkttysmiqjxbunezgwmdpr", "ohvflkvtysmiqjbbunezgzcdpr", "ahvflkatysyiqjxbunezvwcdpr", "ohiflkatysmydjxbunezgwcdpr", "ohvfwkatysmvqjxbunezwwcdpr", "ohvflkatysbiqjxbunergwodpr", "hhvsdkatysmiqjxbunezgwcdpr", "ihvflkwtysmiqjxbunezgacdpr", "ohvfljatysmiqcxbunuzgwcdpr", "ohvflkatysqiqlwbunezgwcdpr", "ohvflkauysmkqjxwunezgwcdpr", "ohvflkatysmoqjqbunezgwodpr", "ohvslkvtysmipjxbunezgwcdpr", "olvflkatysmiujxbunezgwctpr", "osvflxatysmiqjxbenezgwcdpr", "orvflkhtysmiqjxbinezgwcdpr", "ohcflkatystiqjxbunezbwcdpr", "ohcflkatyfmifjxbunezgwcdpr", "ohvflkatdsmiqjxbrnezgwcdpt", "ohvflkatysmiqjxbwnqzawcdpr", "oevflkakysmiqjxbunezgwcdpt", "ofvflkatysmiqjxbunbqgwcdpr", "ohvflkatysmdqjxbunefqwcdpr", "ohvklkalysmiqjxbunezgwcepr", "ocvflhatysmiqjxbunezzwcdpr", "uhvflkatysmiqmxbunezgwcxpr", "ohvflkatyshikjhbunezgwcdpr", "lbvflkatysmoqjxbunezgwcdpr", "ohvflkatssmuqjxbunezgscdpr", "ohvflkatysmifyxbuvezgwcdpr", "ohvfikatysmiqjxbunezgwfupr", "ohvmlkaiysmiqjxqunezgwcdpr", "ohvflkatysmiqjxiunpzgwcdpo", "lhvflkatysmpqjxbenezgwcdpr", "ohvflkatysmiqjobunengwczpr", "ohoflkatysniqjxbunezgccdpr", "ohvfxkatysmiqjgbunyzgwcdpr", "ohvflkytysmiljxbubezgwcdpr", "hhvsdkatysmiqjxjunezgwcdpr", "ohvflkatysmiqjtuunezgwcdpt", "ohvfdkxtysmiqjubunezgwcdpr", "ohxflkatysmiyjxbunezgwcdhr", "ohvflkatysmiqjibunezgwcppd", "ohvflkatysmihjxbunezgwcdhj", "ohvflkatysmiqjxronezgwcdvr", "ofrflxatysmiqjxbunezgwcdpr", "ohvwlkatysmiqjxounezgscdpr", "ohvflkatcodiqjxbunezgwcdpr", "oqvflkatysmiqjxbunebgwmdpr", "ohvflmatysmisjxbunezqwcdpr", "ovvflkatysmiqjxbuxezgwcdpe", "ohvflkatysmdejxbuneztwcdpr", "hhvflkathsmiqjxbwnezgwcdpr", "ohkflkatlsmsqjxbunezgwcdpr", "ohvflkktysmizjxhunezgwcdpr", "ohzflkatysmiqjrbunezgwcdpj", "ohuflwatysmiqjxbunezgwcdgr", "ohvflkatysmiqvxmunpzgwcdpr", "xhvflkwtysmiqjxbunezgwjdpr", "whvflkatysmiqjxbunezgzcopr", "ohvflkayysmiqjxuznezgwcdpr", "khvflkasysmiqjxbunezgwcdpv", "ohvflkatylmiqjxbpnozgwcdpr", "ohvflkgtysziqjxbunezgwgdpr", "ohvfljaiysmiqjxbuvezgwcdpr", "ohvflkxtyslizjxbunezgwcdpr", "ohzflkatysmiqjxbcnezgwcdar", "ohvflkatysmiqjxbisecgwcdpr", "shvflkatyjmiqjkbunezgwcdpr", "mhvflkatysmiqjxvunezgwcdpk", "ohfflkatysmiqjxbunczgwcppr", "ohvflkatysmiqjkzunezgwcdpc", "ohvflkatysmifjxbuneygwctpr", "ohvflkatysmimjbbunezgwcdpe", "ohvflkatjsciqjxbunezgwcdpa", "ohvxlkatysmitjxbunezswcdpr", "ohvslkatfsmiqjxbunezgwudpr", "ohvflkatysmiqexbugezgwcdnr", "onvflkatysmiqjxkunezgtcdpr", "fhsflkalysmiqjxbunezgwcdpr", "oyvflkatysmiqjobxnezgwcdpr", "ohvflkatysmiqjxbunezswgdvr", "phvflkatyymiqjxvunezgwcdpr", "oivflzutysmiqjxbunezgwcdpr", "ohvflkftysmiqjxbunezkwcopr", "ohvflkatysmwnjxbunezgwcdpp", "ohvflkatysmiqkxcunezgwndpr", "phvklkatysmiqjhbunezgwcdpr", "ohvflrawysmiqjxbunhzgwcdpr", "ohvflkatysmiqjxbunecgwcdig", "ohvflpakysmiqjxbunezgwrdpr", "odvflkatykmiqjxbunezglcdpr", "ohtflkatysiiqjxblnezgwcdpr", "lhvfpkatysmiqjxbupezgwcdpr", "ohvflkatdsmiqjpbunezgwcdps", "ohvflkztysmiqjxvunezgwjdpr", "ohvflbatysmxqoxbunezgwcdpr", "ohvklkaigsmiqjxbunezgwcdpr", "ohvfgkawysmiqjxbunezgwcdur", "ohvflkatyskpqjlbunezgwcdpr", "ohvflkatyqmiqjhbupezgwcdpr", "ohqflkatysmiqjxzonezgwcdpr", "ohxfnkatyymiqjxbunezgwcdpr", "ohmflkatpsmiqjxbunezgwcdpw", "ohvflkatysmiqjibnnewgwcdpr", "vevflkatysmiqjxbunezgwcypr", "ohvflkatydmiqwxbungzgwcdpr", "ohsrlkatysmiqjxbcnezgwcdpr", "ohvflkptyvmiqexbunezgwcdpr", "opzflkatysmiqjxrunezgwcdpr", "ohvflkitysmiqjxcunezgwcmpr", "ohvflkatysmhhjxblnezgwcdpr", "ohvflkatysfiqjxbunrzgwmdpr", "ohvflkatyamibjxbunezgwcdpf", "ohvflkalysmigjxbunezggcdpr", "ohvflkatwsmisjxbunezgdcdpr", "dhvflkatysmlqjxbunszgwcdpr", "ohvflkatysmiqjxbueeygwcbpr", "ohvflkatgsmiqjnbunezhwcdpr", "svvflkatysmiqjxbunezgwckpr", "opvflkatysmiqpxbufezgwcdpr", "ohnvlkatysmiqjxbunezglcdpr", "phvflkutysjiqjxbunezgwcdpr", "ohvflabtysmiqjjbunezgwcdpr", "ouvflkatysmiqjsbunezgwcdpk", "osvflkatysmijjxbunezgwcypr", "owvflkatysmiqjxbukxzgwcdpr", "ohvfliatvsmiljxbunezgwcdpr", "ohvflkatysmiqjxbumezbwtdpr", "ohvflkatyfcicjxbunezgwcdpr", "ohvflkatysmiqldbunezgfcdpr", "oqvflkatysmiqixkunezgwcdpr", "ohvflkatysmiqjxbulezgicdpe", "ohvflkatysmiqjxbuniegwcdpl", "ohvflkatysmiqjwbunbzgwcdhr", "ohvflkatysmiqjdbunezgwwdkr", "ohqflkytysmiqjxbunezgwcdpc", "ohvflkatysmigjxbunezqwwdpr", "ohvfloatysmiqjpbumezgwcdpr", "ohvklkathkmiqjxbunezgwcdpr", "ohvflkstjsmiqjxbunezgwctpr", "ohvvlkatysmiqjxbunewgwcdir", "ohnflkatysmiqjxbunszgwcdlr", "ohvflkatysmnqjxbunezgxcdlr", "ohvfrkatysmiqjxbonezgwcdor", "ihvflkatysmiqjxbuneogwcxpr", "ohvflkatysmiqjxbunecgwcccr", "owvflkatysmivjxbunezgwjdpr", "ohvflkgtysmiqjxbunczhwcdpr", "ohyqlkatysmiqjxbunezgwcypr", "ohvflkatysmiqjvbunezuwcdpw", "ohvflkathsmiqmxbuoezgwcdpr", "ehvjlkajysmiqjxbunezgwcdpr", "ohvflkltysmiqjxblnezgwjdpr", "oovflkvtfsmiqjxbunezgwcdpr", "olvfzkatysmiqjxyunezgwcdpr", "ohvflkatysqitjxbunezgncdpr", "yhvflkatysmkqjxbunazgwcdpr", "zlvolkatysmiqjxbunezgwcdpr", "ohvflpatysmiqjxbunezgwcapb", "ohvflkatysmuqjxbunezgfcdur" };
            var closeIds = new List<string>(); // List of Ids matched to rules set
            // Array of the alphabet of which the letter counts are ran
            char[] targets = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            // Loops through all Ids
            // Loops through alphabet
            // Keeps track how many times a letter occurs in an Id
            // For the two lettered count
            // For the three lettered count
            // Used to reset the counts after each id has been letter searched
            void findChars(char[] targets, List<string> list)
            {
                for (var i = 0; i < list.Count; i++)
                {                    
                    for (var j = 0; j < targets.Length; j++)
                    {                        
                        occurances = list[i].Count(x => x == targets[j]);                        
                        if (occurances == 2)
                        {
                            if (twoCount < Limiter)
                            {
                                twoLettered++;
                                twoCount++;
                            }
                        }                        
                        else if (occurances == 3)
                        {
                            if (threeCount < Limiter)
                            {
                                threeLettered++;
                                threeCount++;
                            }
                        }                        
                        if ((twoCount + threeCount) == 2 || j == targets.Length - 1)
                        {
                            twoCount = 0;
                            threeCount = 0;
                            break;
                        }
                    }
                }
                checksum = twoLettered * threeLettered;
                Console.WriteLine("The checksum equals: " + checksum);
            }

            // Holds Id by individual characters
            // Holds another Ids individual characters for comparison
            // Holds the characters that the two nearly identical Ids have in common
            // Loops through Ids from the beginning of the list
            // Loops through Ids from the end of the array to the Id before the Id being compared in the loop above
            // The following two lines take the Id currently taken from the loop and broken down in the respective array
            // Loops through each character in the arrays and compares characters in same location of each Id
            // If the don't match, increase flag so we can exit the comparison quicker if need be
            void findNearlyIdenticalIds(List<string> ids, List<string> closeIds) {
                char[] idBreakdown = new char[26];                
                char[] comparisonIdBreakdown = new char[26]; 
                var sameChars = new List<char>();
                for (var i = 0; i < ids.Count; i++) {                   
                    for (var j = ids.Count - 1; j > i; j--) {                        
                        idBreakdown = ids[i].ToCharArray();
                        comparisonIdBreakdown = ids[j].ToCharArray();                        
                        for (var k = 0; k < (new char[26]).Length; k++) {                            
                            if ((new char[26])[k] != comparisonIdBreakdown[k]) {
                                disFlag++;
                            } else {
                                likeness++;
                            }
                            if (disFlag >= 2) {
                                likeness = 0;
                                disFlag = 0;
                                break;
                            } else if(k == (new char[26]).Length) {
                                likeness = 0;
                                disFlag = 0;
                            }                            
                            if (likeness == (new char[26]).Length - 1) {
                                closeIds.Add(ids[i]);
                                closeIds.Add(ids[j]);
                            }
                        }
                    }
                }
                // Takes those two close Ids and compares them to extract the similar characters
                idBreakdown = closeIds[0].ToCharArray();
                comparisonIdBreakdown = closeIds[1].ToCharArray();
                for(var i = 0; i < (new char[26]).Length; i++) {
                    if((new char[26])[i] == comparisonIdBreakdown[i]) {
                        sameChars.Add((new char[26])[i]);
                    }
                }

                Console.WriteLine("These are the character the two Ids have in common.");
                foreach(var x in sameChars) {
                    Console.Write(x + ", ");
                }
            }

            findChars(targets, boxIDs);
            findNearlyIdenticalIds(boxIDs, closeIds);
        }
    }
}
