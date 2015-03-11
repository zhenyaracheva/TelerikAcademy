namespace GSMTaskMain
{
    using System.Text;

    public struct IPhone4S
    {
        public const string Model = "IPhone4S";
        public const string Manufacturer = "Apple";

        public override string ToString()
        {
            var resul = new StringBuilder();

            resul.AppendLine(string.Format("*Model: {0}", Model));
            resul.AppendLine(string.Format("*Manufacturer: {0}", Manufacturer));

            return resul.ToString().Trim();
        }
    }
}
