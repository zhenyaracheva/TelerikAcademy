namespace ComputersLogic
{
    using System.Collections.Generic;

    using ComputersLogic.VideoCardTypes;

    public class Motherboard : IMotherboard
    {
        public Motherboard(Cpu cpu, Ram ram, IVideoCard videoCard)
        {
            cpu.AttachTo(this);
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        public IVideoCard VideoCard { get; set; }

        public Ram Ram { get; set; }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}
