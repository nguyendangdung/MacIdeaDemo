using System;

namespace MacIdeaDemo
{
    class Text
    {
        public string Name { get; set; }
    }

    class Key
    {
        public string Value { get; set; }
    }

    class MacTag
    {
        public string Value { get; set; }
    }
    class Block
    {
        public Text Text { get; set; }
        public Key Key { get; set; }

        /// <summary>
        /// using an Hash function to return MacTag
        /// </summary>
        /// <returns></returns>
        public MacTag GetMacTag()
        {
            return new MacTag()
            {
                Value = Text.Name + Key.Value
            };
        }
    }


    

    class Program
    {
        static void Main(string[] args)
        {
            string secretkey = "123";
            var originText = new Text()
            {
                Name = "dan nguyen"
            };
            var key = new Key()
            {
                Value = secretkey
            };

            var block = new Block()
            {
                Text = originText,
                Key = key
            };

            var originMac = block.GetMacTag();

            // 
            var backData = SendViaInternet(originText, originMac);

            var textback = (Text)backData.Text;
            var tagBack = (MacTag)backData.MacTag;


            var blockback = new Block()
            {
                Text = textback,
                Key = key
            };

            if (blockback.GetMacTag().Value != tagBack.Value)
            {
                Console.WriteLine("Fake data");
            }
            else
            {
                Console.WriteLine("Good data");
            }


        }


        private static dynamic SendViaInternet(Text origin, MacTag orMacTag)
        {
            var fakeText = new Text()
            {
                Name = "xxxxx"
            };
            var fakeBlock = new Block()
            {
                Text = fakeText,
                Key = new Key()
                {
                    Value = "00000000000"
                }
            };
            return new
            {
                Text = fakeText,
                MacTag = fakeBlock.GetMacTag()
            };
        }
    }
}
