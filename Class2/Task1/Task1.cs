namespace Task1

{
    class JsonIntProperty
    {
        private string name;
        private int val;
        private int setValueCounter = 0;
        private static int instanceCounter = 0;
        public static int InstanceCounter
        {
            get { return instanceCounter; }
        }
        public string Name
        {
            get { return this.name; }
        }
        public int SetValueCounter{
            get { return this.setValueCounter; }
        }
        public int Value
        {
            get { return val; }
            set {
                this.setValueCounter++;
                val = value; }
        }
        public string StringRepresentation
        {
            get { return $"{this.Name}: {this.Value}"; }
            set
            {
                if (!value.Contains(":") || (value.Count(f => f ==':') != 1)) 
                    throw new ArgumentException($"Incorrect JSON property format: \'{value}\'");
                var strValue = value.Split(":");
                if (strValue[0].Trim() == name)
                    if (int.TryParse(strValue[1], out val)) this.setValueCounter++;
                    else throw new FormatException($"For input string: \"{strValue[1].Trim()}\"");
                else throw new ArgumentException("Property name is immutable");
            }
        }
        public JsonIntProperty(string name, int age)
        {
            this.name = name.Trim();
            this.Value = age;
            instanceCounter++;
        }
        public JsonIntProperty(string name)
        {
            this.name = name.Trim();
            this.Value = 0;
            instanceCounter++;
        }
        public override string ToString()
        {
            return this.StringRepresentation;
        }
    }

    public class Task1
    {
        public static void Main(string[] args)
        {
            RunTest();
        }
        
        internal static void RunTest()
        {
            //throw new NotImplementedException("Раскомментируйте код ниже и реализуйте требуемую функциональность в классе JsonIntProperty");
            
            var ageProperty = new JsonIntProperty("age", 21);
            Console.WriteLine(ageProperty);
            Console.WriteLine(ageProperty.StringRepresentation);
            ageProperty.Value += 1;
            Console.WriteLine(ageProperty);
            ageProperty.StringRepresentation = "age: 23";
            Console.WriteLine(ageProperty);
            ageProperty.StringRepresentation = "age   :   24";
            Console.WriteLine(ageProperty);
            try
            {
                ageProperty.StringRepresentation = "value : 10";
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
            }

            try
            {
                ageProperty.StringRepresentation = "age: ?";
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
            }

            try
            {
                ageProperty.StringRepresentation = "age = 10";
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType()}: {e.Message}");
            }

            Console.WriteLine($"JSON value of 'age' has been set {ageProperty.SetValueCounter} time(s)");
            var countProperty = new JsonIntProperty("count");
            Console.WriteLine(countProperty);
            Console.WriteLine($"JSON value of 'count' has been set {countProperty.SetValueCounter} time(s)");
            Console.WriteLine(
                $"Class 'JsonIntProperty' instance has been created {JsonIntProperty.InstanceCounter} time(s)");
        }

    }
}