namespace TemplateMethodPattern
{
    using System;

    public abstract class MojitoMaker
    {
        public void MakeMojito()
        {
            this.AddGreenSpices();
            this.AddLime();
            this.AddSugar();
            this.SmashMentaSugarLime();
            this.AddSoda();
            this.AddRum();
            this.AddIce();
        }

        protected abstract void AddGreenSpices();

        protected abstract void AddSugar();

        protected abstract void AddLime();

        protected void SmashMentaSugarLime()
        {
            Console.WriteLine("Menta, sugar and lime smashed");
        }

        protected abstract void AddRum();

        protected abstract void AddSoda();

        protected abstract void AddIce();
    }
}
