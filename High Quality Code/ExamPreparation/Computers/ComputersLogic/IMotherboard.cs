namespace ComputersLogic
{
    /// <summary>
    /// Interface that can load and save ram value and deaw on videoCard
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Load value from RAM
        /// </summary>
        /// <returns>Loaded value</returns>
        int LoadRamValue();

        /// <summary>
        /// Save given RAM value
        /// </summary>
        /// <param name="value">The value that have to be saved</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draw on videoCard given data
        /// </summary>
        /// <param name="data">The Data that have to be drawn</param>
        void DrawOnVideoCard(string data);
    }
}
