using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class DictClass
    {
        private int id;
        private int unit;
        private string name;
        private string info;
        private string pic;
        private string link;

        public DictClass(int id, int unit, string name, string info, string pic, string link)
        {
            this.id = id;
            this.unit = unit;
            this.name = name;
            this.info = info;
            this.pic = pic;
            this.link = link;
        }

        public int Id { get => id; set => id = value; }
        public int Unit { get => unit; set => unit = value; }
        public string Name { get => name; set => name = value; }
        public string Info { get => info; set => info = value; }
        public string Pic { get => pic; set => pic = value; }
        public string Link { get => link; set => link = value; }
    }
}
