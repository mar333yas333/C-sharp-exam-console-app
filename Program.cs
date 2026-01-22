using System;
using System.Collections.Generic;

namespace MID_PROJ{
    public class Program{
        static void Main(string[] args){
            string title = "myoptions";
            string[] options =
            {
                "1",
                "2",
                "3",
                "4",
                "return",
            };
            int selection = Arrow_Menu.arrow_meth(options, title);
        }
    }    
}